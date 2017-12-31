using System.Collections.Generic;

namespace Replicants
{
	class ReplicantFinderArgs
	{
		public IEnumerable<string> Directories { get; set; }
		public string SearchPattern { get; private set; }
		public bool OnlyNames { get; private set; }

		public ReplicantFinderArgs(IEnumerable<string> directories, string searchPattern, bool onlyNames)
		{
			Directories = directories;
			SearchPattern = string.IsNullOrWhiteSpace(searchPattern) ? "*.*" : searchPattern;
			OnlyNames = onlyNames;
		}

		public ReplicantFinderArgs Clone(string newPath)
		{
			return new ReplicantFinderArgs(new[] { newPath }, SearchPattern, OnlyNames);
		}
	}
}
