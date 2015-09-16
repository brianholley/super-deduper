using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;

namespace FileDupeFinder
{
	class FilesystemCrawl
	{
		private readonly List<string> _files;
		private readonly Dictionary<long, List<string>> _sizes = new Dictionary<long, List<string>>();
		private readonly Dictionary<string, List<string>> _duplicates = new Dictionary<string, List<string>>();

		private int _totalWork;
		private int _completeWork;

		public FilesystemCrawl(string path)
		{
			try
			{
				var fileEnum = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
				_files = fileEnum.ToList();

				_totalWork = _files.Count*2;

				if (OnProgress != null)
					OnProgress(_totalWork, _completeWork);

				new Thread(ProcessFiles).Start();
			}
			catch (Exception e)
			{
				Debug.WriteLine("Exception during init: {0}", e);
				if (OnFinished != null)
					OnFinished();
			}
		}

		private void ProcessFiles()
		{
			DetermineFileSizes();
			GenerateFileHashes();

			if (OnFinished != null)
				OnFinished();
		}

		private void DetermineFileSizes()
		{
			foreach (string path in _files)
			{
				long size = GetFileSize(path);

				if (!_sizes.ContainsKey(size))
					_sizes[size] = new List<string> { path };
				else
					_sizes[size].Add(path);

				_completeWork++;
				if (OnProgress != null)
					OnProgress(_totalWork, _completeWork);
			}
		}

		private void GenerateFileHashes()
		{
			foreach (var filesOfSameSize in _sizes.Values)
			{
				if (filesOfSameSize.Count > 1)
				{
					var hashes = new Dictionary<string, string>();
					foreach (var path in filesOfSameSize)
					{
						string hash = GetFileHash(path);

						if (hashes.ContainsKey(hash))
						{
							if (_duplicates.ContainsKey(hash))
							{
								_duplicates[hash].Add(path);
							}
							else
							{
								_duplicates.Add(hash, new List<string>());
								_duplicates[hash].Add(hashes[hash]);
								_duplicates[hash].Add(path);
							}
						}
						else
						{
							hashes.Add(hash, path);
						}
					}
				}

				_completeWork += filesOfSameSize.Count;
				if (OnProgress != null)
					OnProgress(_totalWork, _completeWork);
			}
		}

		private long GetFileSize(string path)
		{
			return new FileInfo(path).Length;
		}

		private string GetFileHash(string path)
		{
			try
			{
				FileStream fs = new FileStream(path, FileMode.Open);
				byte[] hash = MD5.Create().ComputeHash(fs);
				fs.Close();
				return Convert.ToBase64String(hash);
			}
			catch (Exception e)
			{
				Debug.WriteLine("File failed: {0}, {1}", path, e);
				return Guid.NewGuid().ToString("N");
			}
		}

		public Action<int, int> OnProgress { get; set; }
		public Action OnFinished { get; set; }

		public Dictionary<string, List<string>> Duplicates { get { return _duplicates; } }
	}
}
