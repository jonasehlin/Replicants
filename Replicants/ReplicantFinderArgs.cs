namespace Replicants
{
	class ReplicantFinderArgs
	{
		public string Path { get; set; }

		public string SearchPattern { get; private set; }

		public bool OnlyNames { get; private set; }

		public ReplicantFinderArgs(string path, string searchPattern, bool onlyNames)
		{
			Path = path;
			SearchPattern = string.IsNullOrWhiteSpace(searchPattern) ? "*.*" : searchPattern;
			OnlyNames = onlyNames;
		}

		public ReplicantFinderArgs Clone(string newPath)
		{
			return new ReplicantFinderArgs(newPath, SearchPattern, OnlyNames);
		}
	}
}
