using System.Collections.Generic;
using System.IO;

namespace Shp2Sql.Helpers
{
	#region Imports

	

	#endregion
	public class FileHelper
	{
		public static IReadOnlyCollection<FileInfo> GetFiles(string directoryPath, bool recursive = true)
		{
			return GetFiles(new DirectoryInfo(directoryPath), recursive);
		}

		public static IReadOnlyCollection<FileInfo> GetFiles(DirectoryInfo directory, bool recursive = true)
		{
			return GetFiles(directory, "*.xml", recursive);
		}

		public static IReadOnlyCollection<FileInfo> GetFiles(string directoryPath, string searchPattern, bool recursive = true)
		{
			return GetFiles(new DirectoryInfo(directoryPath), searchPattern, recursive);
		}

		public static IReadOnlyCollection<FileInfo> GetFiles(DirectoryInfo directory,
			string searchPattern,
			bool recursive = true)
		{
			if (directory == null
				|| !directory.Exists)
				throw new DirectoryNotFoundException(
					"The directory that was specified is invalid. Please check the directory and try to get the files again.");

			return directory.GetFiles(searchPattern, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
		}
	}
}