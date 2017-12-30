using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Replicants
{
	class ReplicantFinder : BackgroundWorker
	{
		internal FileItemMap Replicants;

		public ReplicantFinder()
		{
			WorkerReportsProgress = true;
			WorkerSupportsCancellation = true;
		}
	}
}
