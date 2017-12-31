using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace Replicants
{
	class ReplicantFinder : BackgroundWorker
	{
		internal FileItemMap Replicants;

		internal long? _minSize, _maxSize;

		public ReplicantFinder()
		{
			WorkerReportsProgress = true;
			WorkerSupportsCancellation = true;
			DoWork += ReplicantFinder_DoWork;
		}

		private void ReplicantFinder_DoWork(object sender, DoWorkEventArgs e)
		{
			FindReplicant((ReplicantFinderArgs)e.Argument);
		}

		private void FindReplicant(ReplicantFinderArgs args)
		{
			if (CancellationPending)
				return;

			try
			{
				foreach (var dir in args.Directories)
				{
					Trace.WriteLine($"Folder {dir}...");
					foreach (var filePath in Directory.GetFiles(dir, args.SearchPattern))
					{
						try
						{
							var fileInfo = new FileInfo(filePath);
							if (_minSize.HasValue && fileInfo.Length < _minSize.Value)
								continue;
							if (_maxSize.HasValue && fileInfo.Length > _maxSize.Value)
								continue;

							var fileItem = new FileItem(fileInfo);
							var source = Replicants.Add(fileItem);
							if (source != null)
								ReportProgress(0, new ReplicantEventArgs(source, fileItem));

							if (CancellationPending)
								return;
						}
						catch (Exception ex)
						{
							Trace.WriteLine(ex.Message);
						}
					}

					foreach (var subDirPath in Directory.GetDirectories(dir))
						FindReplicant(args.Clone(subDirPath));
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}
		}
	}
}
