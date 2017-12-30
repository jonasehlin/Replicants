using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Replicants
{
	class ReplicantEventArgs
	{
		public FileItem Source { get; private set; }

		public FileItem Replicant { get; private set; }

		public ReplicantEventArgs(FileItem source, FileItem replicant)
		{
			Source = source;
			Replicant = replicant;
		}
	}
}
