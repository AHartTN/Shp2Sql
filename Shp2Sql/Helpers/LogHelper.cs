using System;
using System.Configuration;
using System.IO;
using System.Security.AccessControl;
using System.Text;

namespace Shp2Sql.Helpers
{
	#region Imports

	

	#endregion
	public class LogHelper
	{
		public LogHelper()
		{
			Initialize();
		}

		public static bool Initialize()
		{
			try
			{
				if (string.IsNullOrWhiteSpace(OutputPath)
					|| OutputDirectory == null)
					throw new ArgumentException("An empty or otherwise invalid path was detected for the Output Directory.");
				if (string.IsNullOrWhiteSpace(WorkingPath)
					|| WorkingDirectory == null)
					throw new ArgumentException("An empty or otherwise invalid path was detected for the Working Directory.");
				if (string.IsNullOrWhiteSpace(LogPath))
					throw new ArgumentException("An empty or otherwise invalid path was detected for the Log directory.");
				if (LogFile == null)
					throw new ArgumentException("An empty or otherwise invalid path was detected for the Output Log file.");
				if (ErrorFile == null)
					throw new ArgumentException("An empty or otherwise invalid path was detected for the Output Error file.");

				if (!OutputDirectory.Exists)
					OutputDirectory.Create();
				if (!WorkingDirectory.Exists)
					WorkingDirectory.Create();
				if (!LogDirectory.Exists)
					LogDirectory.Create();
				if (!LogFile.Exists)
					LogFile.Create();
				if (!ErrorFile.Exists)
					ErrorFile.Create();

				return OutputDirectory.Exists && WorkingDirectory.Exists && LogFile.Exists && ErrorFile.Exists;
			}
			catch (Exception e)
			{
				Console.WriteLine($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public void Write(string message, bool toFile = false)
		{
			Console.Write(message);
			if (toFile)
				WriteToFile(message, LogFile);
		}

		public void WriteLine(string message, bool toFile = false)
		{
			Console.WriteLine(message);
			if (toFile)
				WriteToFile(message, LogFile);
		}

		public void Error(string message, bool toFile = false)
		{
			Console.WriteLine(message);
			if (toFile)
				WriteToFile(message, ErrorFile);
		}

		public static void WriteToFile(string message, string filePath)
		{
			WriteToFile(message, new FileInfo(filePath));
		}

		public static void WriteToFile(string message, FileInfo file)
		{
			using (
				FileStream fs = new FileStream(file.FullName,
					FileMode.Append,
					FileSystemRights.AppendData,
					FileShare.ReadWrite,
					4096,
					FileOptions.Asynchronous))
			{
				fs.WriteAsync(Encoding.UTF8.GetBytes(message), 0, message.Length);
				fs.Close();
			}
		}
		#region Properties

		#region Static Properties

		public static string AppName => ConfigurationManager.AppSettings["AppName"];
		public static string OutputPath => Path.Combine(ConfigurationManager.AppSettings["OutputPath"], AppName);
		public static string WorkingPath => Path.Combine(ConfigurationManager.AppSettings["WorkingPath"], AppName);
		public static string LogPath => Path.Combine(OutputPath, "Logs");
		public static DirectoryInfo OutputDirectory => new DirectoryInfo(OutputPath);
		public static DirectoryInfo WorkingDirectory => new DirectoryInfo(WorkingPath);
		public static DirectoryInfo LogDirectory => new DirectoryInfo(LogPath);
		public static FileInfo LogFile => new FileInfo(Path.Combine(LogPath, "Output.txt"));
		public static FileInfo ErrorFile => new FileInfo(Path.Combine(LogPath, "Errors.txt"));

		#endregion Static Properties

		#endregion Properties
	}
}