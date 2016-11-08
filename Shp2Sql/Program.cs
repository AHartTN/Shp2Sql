using Shp2Sql.Helpers;

namespace Shp2Sql
{
	#region Imports

	using System;
	using System.Configuration;

	#endregion
	public class Program
	{
		public static string SourcePath = ConfigurationManager.AppSettings["SourcePath"];

		private static readonly ESRIHelper esriHelper = new ESRIHelper();

		public static void Main(string[] args)
		{
			Initialize();

			esriHelper.ProcessDirectory(SourcePath);

			foreach (string arg in args)
				esriHelper.ProcessDirectory(arg);

			Console.ReadKey(true);
		}

		public static void Initialize()
		{
			Console.BufferHeight = short.MaxValue - 1;
			Console.BufferWidth = 10240;
		}
	}
}