using System.Collections.Generic;

namespace Replicants
{
	class FileItemCollection : List<FileItem>
	{
		public override string ToString()
		{
			return "Count = " + Count;
		}
	}
}
