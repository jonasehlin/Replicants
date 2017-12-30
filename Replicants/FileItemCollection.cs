using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
