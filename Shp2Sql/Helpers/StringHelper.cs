using System;

namespace Shp2Sql.Helpers
{
	#region Imports

	

	#endregion
	public static class StringHelper
	{
		public static LogHelper LH = new LogHelper();

		public static string GetProgressString(long charIndex, long fileLength, string name)
		{
			try
			{
				decimal rawValue = (decimal) charIndex/fileLength;
				string percentage = rawValue.ToString("P4");
				return $"\r{DateTime.Now} | {charIndex} of {fileLength} ({percentage}%): {name}\t\t\t\t\t";
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}
	}
}