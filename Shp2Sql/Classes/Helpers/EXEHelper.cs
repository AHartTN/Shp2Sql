using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shp2Sql.Classes.Helpers
{
	public class EXEHelper
	{
		public class RunCommandOptions
		{
			public RunCommandOptions()
			{
				CreateNoWindow = true;
				UseShellExecute = false;
				RedirectStandardError = true;
				RedirectStandardInput = true;
				RedirectStandardOutput = true;
				WindowStyle = ProcessWindowStyle.Hidden;
			}
			public bool CreateNoWindow { get; set; }
			public bool UseShellExecute { get; set; }
			public bool RedirectStandardError { get; set; }
			public bool RedirectStandardInput { get; set; }
			public bool RedirectStandardOutput { get; set; }
			public ProcessWindowStyle WindowStyle { get; set; }

			public static RunCommandOptions GetDefaults()
			{
				return new RunCommandOptions()
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					RedirectStandardError = true,
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					WindowStyle = ProcessWindowStyle.Hidden
				};
			}
		}

		public static async Task<bool> RunCommandAsync(string command, string[] args, RunCommandOptions options = null)
		{
			Task<bool> test = Task.Run(() => RunCommand(command, args, options));
			bool result = await test;

			//if (!result)
			//	throw new Exception($"The Asynchronous call to run the application has failed.\r\nCommand: {command}\r\nArguments: {string.Join(" ", args)}");

			return result;
		}

		public static async Task<bool> RunCommandAsync(FileInfo command, string[] args, RunCommandOptions options = null)
		{
			Task<bool> test = Task.Run(() => RunCommand(command, args, options));
			bool result = await test;

			//if (!result)
			//	throw new Exception($"The Asynchronous call to run the application has failed.\r\nCommand: {command}\r\nArguments: {string.Join(" ", args)}");

			return result;
		}

		public static bool RunCommand(string commandPath, string[] args, RunCommandOptions options = null)
		{
			return RunCommand(new FileInfo(commandPath), args, options);
		}

		public static bool RunCommand(FileInfo command, string[] args, RunCommandOptions options = null)
		{
			if (command == null || !command.Exists)
				throw new FileNotFoundException("The file specified does not exist.", command?.FullName ?? "NULL COMMAND FILEINFO");

			options = options ?? RunCommandOptions.GetDefaults();

			ProcessStartInfo psi = new ProcessStartInfo(command.FullName)
			{
				CreateNoWindow = options.CreateNoWindow,
				UseShellExecute = options.UseShellExecute,
				RedirectStandardError = options.RedirectStandardError,
				RedirectStandardInput = options.RedirectStandardInput,
				RedirectStandardOutput = options.RedirectStandardOutput,
				WindowStyle = options.WindowStyle,
				Arguments = string.Join(" ", args),
				FileName = command.FullName,
				WorkingDirectory = command.DirectoryName ?? ".",
			};

			try
			{
				using (Process process = new Process())
				{
					process.ErrorDataReceived += Process_ErrorDataReceived;
					process.OutputDataReceived += Process_OutputDataReceived;
					process.Exited += Process_Exited;
					process.StartInfo = psi;
					bool startResult = process.Start();

					if (startResult)
						process.WaitForExit();
				}

				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		private static void Process_Exited(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private static void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			Console.Write(e.Data);
			throw new NotImplementedException();
		}

		private static void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
		{
			Console.Write($"ERROR: {e.Data}");
			throw new NotImplementedException();
		}
	}
}
