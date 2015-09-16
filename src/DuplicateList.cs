using System.Collections.Generic;
using System.IO;

namespace FileDupeFinder
{
	public class DuplicateList
	{
		public struct Duplicate
		{
			public string Filepath;
			public string DisplayPath;
		}
		
		private List<Duplicate> _list = new List<Duplicate>();
		private readonly string _basePath;

		public DuplicateList(string basePath)
		{
			_basePath = basePath;
		}

		public void AddFile(string path)
		{
			var dupe = new Duplicate {Filepath = path, DisplayPath = DisplayPathForFile(path)};
			_list.Add(dupe);
		}

		public List<Duplicate> GetDuplicates()
		{
			_list.Sort((a, b) =>
			{
				string filenameA = Path.GetFileNameWithoutExtension(a.Filepath);
				string filenameB = Path.GetFileNameWithoutExtension(b.Filepath);
				return System.String.Compare(filenameA, filenameB, System.StringComparison.Ordinal);
			});
			return _list;
		}

		public override string ToString()
		{
			return _list[0].DisplayPath;
		}

		private string DisplayPathForFile(string path)
		{
			return path.Substring(_basePath != null ? _basePath.Length : 0).TrimStart('\\');
		}
	}
}