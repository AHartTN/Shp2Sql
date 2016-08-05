using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Shp2Sql.Classes.Helpers
{
	public class XMLHelper
	{
		#region Properties
		public static string XSDDirectory => ConfigurationManager.AppSettings["XSDDirectory"];
		public static string XSDFileName => ConfigurationManager.AppSettings["XSDFileName"];
		public static string OutputPath => ConfigurationManager.AppSettings["OutputPath"];
		public static DirectoryInfo OutputDirectory => new DirectoryInfo(OutputPath);
		public static string XSDFullPath => $"{Path.Combine(XSDDirectory, XSDFileName)}";
		public static string OutputArgument => $"/o:{OutputPath}";
		public static string LanguageArgument => "/l:cs";
		public static string ClassArgument => "/c";
		public static string DatasetArgument => $"/d";
		public static string EnableLinqDataSetArgument => $"/enableLinqDataSet";
		public static string EnableDataBindingArgument => $"/enableDataBinding";
		public static string OrderArgument => $"/order";
		public static string NoLogoArgument => $"/nologo";
		#endregion Properties

		public static IEnumerable<FileInfo> GetXMLFiles(string directoryPath)
		{
			if (string.IsNullOrWhiteSpace(directoryPath))
				throw new ArgumentNullException(nameof(directoryPath), "The directory you have specified does not exist or is invalid.");

			return GetXMLFiles(new DirectoryInfo(directoryPath));
		}
		public static IEnumerable<FileInfo> GetXMLFiles(DirectoryInfo directory)
		{
			if (directory == null || !directory.Exists)
				throw new DirectoryNotFoundException($"The specified directory does not exist.");

			var result = directory.EnumerateFiles("*.xml", SearchOption.AllDirectories);

			return result;
		} 
		public static string[] GetXSDArguments(string inputFilePath)
		{
			if (inputFilePath.Contains(" "))
				inputFilePath = $"\"{inputFilePath}\"";

			return new[] { inputFilePath, OutputArgument, LanguageArgument, ClassArgument, /*DatasetArgument,*/ EnableLinqDataSetArgument, EnableDataBindingArgument, OrderArgument, NoLogoArgument };
		}

		public static bool CallXSD(string[] arguments)
		{
			return EXEHelper.RunCommand(XSDFullPath, arguments);
		}
		public static async Task<bool> CallXSDAsync(string[] arguments)
		{
			return await EXEHelper.RunCommandAsync(XSDFullPath, arguments);
		}

		public static XmlDocument GetXmlDocument(string filePath)
		{
			XmlDocument result = new XmlDocument();
			result.Load(filePath);
			return result;
		}

		public static async Task GetSchemas(string directoryPath)
		{
			await GetSchemas(new DirectoryInfo(directoryPath));
		}

		public static async void GetSchemas(DirectoryInfo directory)
		{
			var files = GetXMLFiles(directory);

			foreach (var file in files)
			{
				await GetClasses(file);
				// GetClasses(file);
			}

			return null;
		}

		public static async Task GetClasses(FileInfo file)
		{
			// file should be an XML file at this point
			// Generate Schemas (XSD) from all XML files
			CallXSD(GetXSDArguments(file.FullName));

			// XML Files might generate multiple schema files. We need to process all of them in order to proceed
			// Files will match the filename with an optional suffix of _app# appended to the file name or something similar
			var searchQuery = file.Name.Replace(file.Extension, "").Trim('.');

			// Delete the XML file as it's no longer necessary
			// We're keeping it for now because we're working from a source directory and not copying it to a working directory
			// Only the XSD/CS files are copied to the output directory and need to be deleted afterwards.
			//file.Delete();

			// Retrieve all of the new schema files for the XML file we just generated schemas for
			var schemaFiles = OutputDirectory.EnumerateFiles($"{searchQuery}*", SearchOption.AllDirectories);

			// Process each schema file
			foreach (var schemaFile in schemaFiles)
			{
				// Generate C# class(es) for each schema file that gets generated
				// Presumably this would be one file for each model type involved with the XML file
				// Do i await here or just let it run? Which one lets me process each file rapidly one over the other?
				var result = await GenerateClassesFromSchemaAsync(schemaFile);
				//var result = GenerateClassesFromSchemaAsync(schemaFile);
			}
		}

		public static IEnumerable<FileInfo> GenerateClassesFromSchema(FileInfo file)
		{
			// file should be an XSD schema file at this point
			// Generate Classes from Schema (XSD) Files
			CallXSD(GetXSDArguments(file.FullName));

			// Delete the no longer necessary schema file
			file.Delete();

			if(file.Exists)
				throw new Exception($"{file.FullName} did not get removed properly!");

			return OutputDirectory.EnumerateFiles($"{file.Name.Replace(file.Extension, "").Trim('.')}*.cs", SearchOption.AllDirectories);
		}

		public static async Task<IEnumerable<FileInfo>> GenerateClassesFromSchemaAsync(FileInfo schemaFile)
		{
			Task<IEnumerable<FileInfo>> task = Task.Run(() => GenerateClassesFromSchema(schemaFile));
			return await task;
		}
	}
}
