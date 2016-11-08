using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Shp2Sql.Models.Base;

namespace Shp2Sql.Helpers
{
	#region Imports

	

	#endregion
	public static class EXEHelper
	{
		public static LogHelper LH = new LogHelper();
		public static string OutputPath => ConfigurationManager.AppSettings["OutputPath"];
		public static DirectoryInfo OutputDirectory => new DirectoryInfo(OutputPath);
		public static string WorkingPath => ConfigurationManager.AppSettings["WorkingPath"];
		public static DirectoryInfo WorkingDirectory => new DirectoryInfo(WorkingPath);

		public static async Task<bool> RunCommandAsync(string command,
			IReadOnlyCollection<string> args,
			RunCommandOptions options = null)
		{
			try
			{
				LH.Write("\rRunning Command from string (Async)\t\t\t\t\t");
				Task<bool> task = Task.Run(() => RunCommand(command, args, options));
				return await task;
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static async Task<bool> RunCommandAsync(FileInfo command,
			IReadOnlyCollection<string> args,
			RunCommandOptions options = null)
		{
			try
			{
				LH.Write("\rRunning Command from File Info (Async)\t\t\t\t\t");
				Task<bool> task = Task.Run(() => RunCommand(command, args, options));
				return await task;
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static bool RunCommand(string commandPath, IReadOnlyCollection<string> args, RunCommandOptions options = null)
		{
			try
			{
				LH.Write("\rRunning Command from string\t\t\t\t\t");
				return RunCommand(new FileInfo(commandPath), args, options);
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static bool RunCommand(FileInfo command, IReadOnlyCollection<string> args, RunCommandOptions options = null)
		{
			try
			{
				if (command == null
					|| !command.Exists)
					throw new FileNotFoundException("The file specified does not exist.");

				LH.Write($"\rExecuting Command: {command.Name}\t\t\t\t\t");

				options = options ?? new RunCommandOptions();

				string commandPath = command.FullName.Contains(" ")
					? $"\"{command.FullName}\""
					: command.FullName;

				LH.Write("\rInstantiating ProcessStartInfo Object\t\t\t\t\t");
				ProcessStartInfo psi = new ProcessStartInfo(command.FullName)
				{
					CreateNoWindow = options.CreateNoWindow,
					UseShellExecute = options.UseShellExecute,
					RedirectStandardError = options.RedirectStandardError,
					RedirectStandardInput = options.RedirectStandardInput,
					RedirectStandardOutput = options.RedirectStandardOutput,
					WindowStyle = options.WindowStyle,
					Arguments = string.Join(" ", args),
					FileName = commandPath,
					WorkingDirectory = WorkingPath
				};

				//Debug.WriteLine($"Command: {psi.FileName} {psi.Arguments}");

				LH.Write("\rBeginning Process Execution\t\t\t\t\t");
				using (Process process = new Process())
				{
					process.ErrorDataReceived += Process_ErrorDataReceived;
					process.OutputDataReceived += Process_OutputDataReceived;
					process.StartInfo = psi;

					bool startResult = process.Start();

					LH.Write($"\rCommand process has started: {process.StartTime}\t\t\t\t\t");
					if (startResult)
					{
						StreamReader output = process.StandardOutput;
						StreamReader error = process.StandardError;

						bool hasTerminated = false;
						Stopwatch sw = Stopwatch.StartNew();

						while (!hasTerminated)
						{
							process.Refresh();
							hasTerminated = process.HasExited;
							if (sw.Elapsed.Seconds >= 10)
								break;
						}
						sw.Stop();
						process.WaitForExit();

						if (process.ExitCode != 0)
							LH.Error($"\r{error.ReadToEnd()}", true);
						else
							LH.WriteLine($"\r{output.ReadToEnd()}", true);

						LH.Write($"\rProcess has exited: Code {process.ExitCode} | {process.ExitTime}\t\t\t\t\t");
					}

					LH.Write("\rEnding Process Execution\t\t\t\t\t");
					return true;
					//return process.ExitCode == 0;
				}
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		private static void Process_OutputDataReceived(object sender, DataReceivedEventArgs args)
		{
			try
			{
				LH.Write($"\r{args.Data}\t\t\t\t\t");
				throw new NotImplementedException();
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		private static void Process_ErrorDataReceived(object sender, DataReceivedEventArgs args)
		{
			try
			{
				LH.Write($"\rERROR:\r\n{args.Data}\t\t\t\t\t");
				throw new NotImplementedException();
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}
	}
}