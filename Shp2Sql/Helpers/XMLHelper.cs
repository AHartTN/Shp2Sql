using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Shp2Sql.Enumerators;

namespace Shp2Sql.Helpers
{
	#region Imports

	

	#endregion
	public class XMLHelper
	{
		public static bool ProcessFile(string xmlFilePath)
		{
			try
			{
				return ProcessFile(new FileInfo(xmlFilePath));
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static bool ProcessFile(FileInfo xmlFile)
		{
			try
			{
				LH.Write($"\rProcessing {xmlFile.Name} as an XML file\t\t\t\t\t");
				IReadOnlyCollection<FileInfo> schemas = GenerateSchema(xmlFile);

				if (!schemas.Any())
					//throw new FileLoadException($"FAILED TO LOAD XML SCHEMA: {xmlFile.Name}");
					// TODO: GET THE XSLT(?) TRANSFORMATIONS WORKING SO WE CAN GET THE DBF.*.XML FILES PROCESSED AS WELL
					return false;

				IReadOnlyCollection<FileInfo> classes = GenerateClass(schemas);

				if (classes == null
					|| !classes.Any())
					return false;

				// TODO: Figure out and implement what to do with the class files at this point!

				//Parallel.ForEach(schemas, schema => schema.Delete());

				return true;
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static async Task<bool> ProcessFileAsync(string xmlFilePath)
		{
			try
			{
				Task<bool> task = Task.Run(() => ProcessFile(xmlFilePath));
				return await task;
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static async Task<bool> ProcessFileAsync(FileInfo xmlFile)
		{
			try
			{
				Task<bool> task = Task.Run(() => ProcessFile(xmlFile));
				return await task;
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static IReadOnlyCollection<FileInfo> GenerateSchema(string xmlFilePath)
		{
			try
			{
				LH.Write($"\rGenerating Schema (string): {xmlFilePath}\t\t\t\t\t");
				return GenerateSchema(new FileInfo(xmlFilePath));
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static IReadOnlyCollection<FileInfo> GenerateSchema(FileInfo xmlFile)
		{
			try
			{
				LH.Write($"\rGenerating Schema (FileInfo): {xmlFile.Name}\t\t\t\t\t");

				IReadOnlyCollection<string> args = GetXSDArguments(xmlFile);
				bool result = CallXSD(args);

				if (!result)
					throw new FileLoadException($"The call to XSD failed on the file:\r\n{xmlFile.FullName}");

				ImportFileType importType = ESRIHelper.GetImportFileType(xmlFile);
				string fileExtension = ESRIHelper.GetImportFileExtension(importType);

				string fileName = xmlFile.Name.Replace(fileExtension, "")
					.Trim('.')
					.Trim();

				IReadOnlyCollection<FileInfo> results = WorkingDirectory.GetFiles($"{fileName}*{ESRIHelper.XmlSchemaExtension}",
					SearchOption.AllDirectories);

				return results;
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static async Task<IReadOnlyCollection<FileInfo>> GenerateSchemaAsync(string xmlFilePath)
		{
			try
			{
				Task<IReadOnlyCollection<FileInfo>> task = Task.Run(() => GenerateSchema(xmlFilePath));
				return await task;
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static async Task<IReadOnlyCollection<FileInfo>> GenerateSchemaAsync(FileInfo xmlFile)
		{
			try
			{
				Task<IReadOnlyCollection<FileInfo>> task = Task.Run(() => GenerateSchema(xmlFile));
				return await task;
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static IReadOnlyCollection<FileInfo> GenerateClass(IReadOnlyCollection<string> schemaFilePaths)
		{
			try
			{
				LH.Write($"\rGenerating Class (string)\t\t\t\t\t");
				return GenerateClass(schemaFilePaths.Select(s => new FileInfo(s)).ToArray());
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static IReadOnlyCollection<FileInfo> GenerateClass(IReadOnlyCollection<FileInfo> schemaFiles)
		{
			try
			{
				IReadOnlyCollection<string> args = GetXSDArguments(schemaFiles, ImportFileType.XmlSchema, true);
				List<string> cleanArgs = args.ToList();
				cleanArgs.Remove(DatasetArgument);
				args = cleanArgs.AsReadOnly();

				FileInfo firstSchemaFile = schemaFiles.FirstOrDefault();

				if (firstSchemaFile == null
					|| !firstSchemaFile.Exists)
					throw new FileNotFoundException("The first schema file in the collection does not exist or was not found");

				ImportFileType importType = ESRIHelper.GetImportFileType(firstSchemaFile);
				string fileExtension = ESRIHelper.GetImportFileExtension(importType);

				string fileName = firstSchemaFile.Name.Replace(fileExtension, "")
					.Trim('.')
					.Replace(".", "_")
					.Trim();

				LH.Write($"\rGenerating Classes (FileInfo): {fileName}\t\t\t\t\t");
				bool result = CallXSD(args);

				if (!result)
					throw new FileLoadException(
						$"The call to XSD failed on the files:\r\n{fileName}");

				IReadOnlyCollection<FileInfo> results = OutputDirectory.GetFiles($"{fileName}*.cs", SearchOption.AllDirectories);

				int resultCount = results.Count;
				LH.Write(
					$"\r{resultCount} Class{(resultCount == 1 ? "" : "es")} Generated for {fileName}\t\t\t\t\t");

				return results;
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static async Task<IReadOnlyCollection<FileInfo>> GenerateClassAsync(IReadOnlyCollection<string> schemaFilePaths)
		{
			try
			{
				Task<IReadOnlyCollection<FileInfo>> task = Task.Run(() => GenerateClass(schemaFilePaths));
				return await task;
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static async Task<IReadOnlyCollection<FileInfo>> GenerateClassAsync(IReadOnlyCollection<FileInfo> schemaFiles)
		{
			try
			{
				Task<IReadOnlyCollection<FileInfo>> task = Task.Run(() => GenerateClass(schemaFiles));
				return await task;
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}
		#region Properties

		public const string LanguageArgument = "/l:cs";
		public const string ClassArgument = "/c";
		public const string DatasetArgument = "/d";
		public const string EnableLinqDataSetArgument = "/enableLinqDataSet";
		public const string EnableDataBindingArgument = "/enableDataBinding";
		public const string OrderArgument = "/order";
		public const string NoLogoArgument = "/nologo";
		public static string XSDDirectory => ConfigurationManager.AppSettings["XSDDirectory"];
		public static string XSDFileName => ConfigurationManager.AppSettings["XSDFileName"];
		public static string XSDFullPath => Path.Combine(XSDDirectory, XSDFileName);
		public static string AppName => ConfigurationManager.AppSettings["AppName"];
		public static string OutputPath => Path.Combine(ConfigurationManager.AppSettings["OutputPath"], AppName);
		public static string WorkingPath => Path.Combine(ConfigurationManager.AppSettings["WorkingPath"], AppName);
		public static string LogPath => Path.Combine(OutputPath, "Logs");
		public static DirectoryInfo OutputDirectory => new DirectoryInfo(OutputPath);
		public static DirectoryInfo WorkingDirectory => new DirectoryInfo(WorkingPath);
		public static DirectoryInfo LogDirectory => new DirectoryInfo(LogPath);
		public static string SchemaOutputArgument => $"/o:\"{WorkingPath}\"";
		public static string ClassOutputArgument => $"/o:\"{OutputPath}\"";
		public static LogHelper LH = new LogHelper();

		#endregion Properties
		#region XSD Utility Helpers

		public static bool CallXSD(IReadOnlyCollection<string> arguments)
		{
			try
			{
				LH.Write("\rCalling XSD\t\t\t\t\t");
				return EXEHelper.RunCommand(XSDFullPath, arguments);
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static async Task<bool> CallXSDAsync(IReadOnlyCollection<string> arguments)
		{
			try
			{
				LH.Write("\rCalling XSD (Async)\t\t\t\t\t");
				return await EXEHelper.RunCommandAsync(XSDFullPath, arguments);
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static IReadOnlyCollection<string> GetXSDArguments(string inputFilePath,
			ImportFileType fileType = ImportFileType.XmlFile)
		{
			try
			{
				return GetXSDArguments(new FileInfo(inputFilePath), fileType);
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static IReadOnlyCollection<string> GetXSDArguments(FileInfo inputFile,
			ImportFileType fileType = ImportFileType.XmlFile)
		{
			try
			{
				string filePathString = inputFile.FullName.Contains(" ")
					? $"\"{inputFile.FullName}\""
					: inputFile.FullName;

				return new[]
				{
					filePathString,
					fileType == ImportFileType.XmlFile ? SchemaOutputArgument : ClassOutputArgument,
					LanguageArgument,
					ClassArgument,
					//DatasetArgument,
					//EnableLinqDataSetArgument,
					//EnableDataBindingArgument,
					//OrderArgument,
					NoLogoArgument
				};
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static IReadOnlyCollection<string> GetXSDArguments(IReadOnlyCollection<string> inputFilePaths,
			ImportFileType fileType = ImportFileType.XmlFile)
		{
			try
			{
				return GetXSDArguments(inputFilePaths.Select(s => new FileInfo(s)).ToArray(), fileType);
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static IReadOnlyCollection<string> GetXSDArguments(IReadOnlyCollection<FileInfo> inputFiles,
			ImportFileType fileType = ImportFileType.XmlFile,
			bool reverseOrder = false)
		{
			try
			{
				string[] filePaths = inputFiles.Select(s => s.FullName)
					.Select(filePath => filePath.Contains(" ") ? $"\"{filePath.Trim('"').Trim()}\"" : filePath.Trim())
					.ToArray();

				if (reverseOrder)
					Array.Reverse(filePaths);

				string filePathsString = string.Join(" ", filePaths);

				return new[]
				{
					filePathsString,
					fileType == ImportFileType.XmlFile ? SchemaOutputArgument : ClassOutputArgument,
					LanguageArgument,
					ClassArgument,
					//DatasetArgument,
					//EnableLinqDataSetArgument,
					//EnableDataBindingArgument,
					//OrderArgument,
					NoLogoArgument
				};
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		#endregion
		#region XML Helpers

		public static IReadOnlyCollection<FileInfo> GetXMLFiles(string directoryPath)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(directoryPath))
					throw new ArgumentNullException(nameof(directoryPath),
						"The directory you have specified does not exist or is invalid.");

				return GetXMLFiles(new DirectoryInfo(directoryPath));
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static IReadOnlyCollection<FileInfo> GetXMLFiles(DirectoryInfo directory)
		{
			try
			{
				if (directory == null
					|| !directory.Exists)
					throw new DirectoryNotFoundException($"The specified directory does not exist.");

				return directory.GetFiles("*.xml", SearchOption.AllDirectories)
					.OrderBy(o => o.Name.Split('.')[0])
					.ThenByDescending(t => t.Length)
					.ToArray();
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static XmlDocument GetXmlDocument(string filePath)
		{
			try
			{
				XmlDocument result = new XmlDocument();
				result.Load(filePath);
				return result;
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static XmlDocument GetXmlDocument(FileInfo file)
		{
			try
			{
				return GetXmlDocument(file.FullName);
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		#endregion XML Helpers
	}
}