namespace Carbon.Helpers
{
	using System;
	using System.IO;
	using System.Linq;

	public static class DirectoryInfoExtensions
	{
		public static long CalculateSize(this DirectoryInfo source)
		{
			long size = source.EnumerateFiles().Sum(fi => fi.Length);

			foreach (var dir in source.EnumerateDirectories())
			{
				size += dir.CalculateSize();
			}

			return size;
		}

		public static void CopyTo(this DirectoryInfo source, DirectoryInfo target, bool recursive = true)
		{
			#region Preconditions

			if (!source.Exists)
				throw new ArgumentException("Does not exist", paramName: "source");

			if (target.Exists)
				throw new ArgumentException("Already exists", paramName: "target");

			// Sanity check
			if (target.FullName.StartsWith(source.FullName))
				throw new Exception("Recusive extension");

			#endregion

			target.Create();

			foreach (var sourceFile in source.EnumerateFiles())
			{
				var targetPath = Path.Combine(target.ToString(), sourceFile.Name);

				sourceFile.CopyTo(targetPath, false);
			}

			if (recursive)
			{
				foreach (var dir in source.EnumerateDirectories())
				{
					var targetFile = new DirectoryInfo(Path.Combine(target.ToString(), dir.Name));

					dir.CopyTo(targetFile, true);
				}
			}
		}
	}
}