using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Replicants
{
	class FileItemMap : Dictionary<FileItem, FileItemCollection>
	{
		public FileItemMap()
			: base(new FileItem.ContentComparer())
		{
		}

		public FileItemMap(IEqualityComparer<FileItem> comparer)
			: base(comparer)
		{
		}

		public FileItem Add(FileItem item)
		{
			FileItemCollection items;
			if (!TryGetValue(item, out items))
			{
				items = new FileItemCollection();
				Add(item, items);
			}
			items.Add(item);
			return items.Count == 1 ? null : items[0];
		}
	}
}
