using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Replicants
{
	class FileItem
	{
		static MD5 _md5Provider = new MD5CryptoServiceProvider();
		FileInfo _fileInfo = null;
		byte[] _checkSum;
		byte[] _firstKiloByte;

		/// <summary>
		/// Gets the full file name to the post.
		/// </summary>
		public string Path
		{
			get { return _fileInfo.FullName; }
		}

		public FileInfo Info
		{
			get { return _fileInfo; }
		}

		public byte[] CheckSum
		{
			get
			{
				if (_checkSum == null)
				{
					using (var fs = _fileInfo.OpenRead())
						_checkSum = _md5Provider.ComputeHash(fs);
				}
				return _checkSum;
			}
		}

		public string CheckSumAsString
		{
			get
			{
				var sb = new StringBuilder(CheckSum.Length << 1);

				foreach (byte b in CheckSum)
					sb.Insert(0, b.ToString("x"));

				return sb.ToString();
			}
		}

		public byte[] FirstKiloByte
		{
			get
			{
				if (_firstKiloByte == null)
				{
					int readBytes = 0;
					byte[] bytes = new byte[1024];
					using (var fs = _fileInfo.OpenRead())
						readBytes = fs.Read(bytes, 0, bytes.Length);
					
					_firstKiloByte = new byte[readBytes];
					Array.Copy(bytes, _firstKiloByte, readBytes);
				}
				return _firstKiloByte;
			}
		}

		public FileItem(string path)
		{
			_fileInfo = new FileInfo(path);
		}

		public FileItem(FileInfo info)
		{
			_fileInfo = info;
		}

		public bool Equals(FileItem fileItem)
		{
			if (string.Compare(Path, fileItem.Path, true) == 0)
				return true;

			if (_fileInfo.Exists == false || fileItem._fileInfo.Exists == false)
				return false;
			
			if (_fileInfo.Length != fileItem._fileInfo.Length)
				return false;

			if (_fileInfo.Length == 0)
				return true;

			if (FirstKiloByte.Length != fileItem.FirstKiloByte.Length)
				return false;

			for (int i = 0; i < FirstKiloByte.Length; i++)
			{
				if (FirstKiloByte[i] != fileItem.FirstKiloByte[i])
					return false;
			}

			for (int i = 0; i < CheckSum.Length; i++)
			{
				if (CheckSum[i] != fileItem.CheckSum[i])
					return false;
			}

			return true;
		}

		public override int GetHashCode()
		{
			return (int)(Info.Length);
		}

		public override string ToString()
		{
			return Path;
		}

		public class ContentComparer : IEqualityComparer<FileItem>
		{
			public bool Equals(FileItem x, FileItem y)
			{
				return x.Equals(y);
			}

			public int GetHashCode(FileItem x)
			{
				return x.GetHashCode();
			}
		}

		public class NameComparer : IEqualityComparer<FileItem>
		{
			public bool Equals(FileItem x, FileItem y)
			{
				return string.Compare(x.Info.Name, y.Info.Name, true) == 0;
			}

			public int GetHashCode(FileItem obj)
			{
				return obj.Info.Name.GetHashCode();
			}
		}
	}
}
