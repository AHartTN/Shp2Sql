using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using Shp2Sql.Classes.Helpers;
using Shp2Sql.Enumerators;
using Shp2Sql.Models.Binding;

namespace Shp2Sql
{
	public class ESRIHelper
	{
		static ESRIHelper()
		{
			IndexFiles = new HashSet<IndexFile>();
			ShapeFiles = new HashSet<ShapeFile>();
			AttributeFiles = new HashSet<AttributeFile>();
			FGDCMetadataFiles = new HashSet<FGDCMetadataFile>();
			ISOMetadataFiles = new HashSet<ISOMetadataFile>();
			ISOEAMetadataFiles = new HashSet<ISOEAMetadataFile>();
			ProjectionFiles = new HashSet<ProjectionFile>();
		}

		public static Dictionary<ImportFileType, string> FileTypes = new Dictionary<ImportFileType, string>
			{
				{ImportFileType.Shape, ShapeFormatExtension},
				{ImportFileType.Attribute, AttributeFormatExtension},
				{ImportFileType.Index, ShapeIndexFormatExtension},
				{ImportFileType.FGDCMetadata, FGDCMetadataExtension},
				{ImportFileType.ISOMetadata, ISO191Extension},
				{ImportFileType.ISOEAMetadata, ISO191EAExtension},
				{ImportFileType.Projection, ProjectionFormatExtension},
			};

		public static ICollection<IndexFile> IndexFiles { get; set; }
		public static ICollection<ShapeFile> ShapeFiles { get; set; }
		public static ICollection<AttributeFile> AttributeFiles { get; set; }
		public static ICollection<FGDCMetadataFile> FGDCMetadataFiles { get; set; }
		public static ICollection<ISOMetadataFile> ISOMetadataFiles { get; set; }
		public static ICollection<ISOEAMetadataFile> ISOEAMetadataFiles { get; set; }
		public static ICollection<ProjectionFile> ProjectionFiles { get; set; }

		public static void ProcessDirectory(string directoryPath, Dictionary<ImportFileType, string> fileTypes = null)
		{
			var directoryInfo = new DirectoryInfo(directoryPath);

			if (!directoryInfo.Exists)
				throw new Exception("The specified directory does not exist!");

			ProcessXMLSchemas(directoryInfo);

			fileTypes = fileTypes ?? FileTypes;

			Console.WriteLine($"{DateTime.Now}\tProcessing all files in {directoryInfo.FullName} with the following Import types:\r\n{string.Join(" | ", fileTypes.Keys)}\r\n({string.Join(" | ", fileTypes.Values)})");

			foreach (var fileType in fileTypes)
			{
				var files = directoryInfo.EnumerateFiles($"*.{fileType.Value.Trim().Trim('.')}", SearchOption.AllDirectories)
										 .OrderByDescending(o => o.Length)
										 .Select((f, i) => new { File = f, Index = i })
										 .ToArray();

				if (files.Any())
				{
					var fileCount = files.Length;
					var resultSize = files.Sum(s => s.File.Length);
					var averageFileSize = files.Average(a => a.File.Length);
					var medianFileSize = files.Median(m => m.File.Length);
					long totalProgress = 0;
					var totalProgressPercentage = 0.0m;

					Console.WriteLine($"{DateTime.Now}\tProcessing {fileCount} {fileType} file{(files.Length == 1 ? "" : "s")}");

					foreach (var result in files)
					{
						var fileSizePercentage = 100 * (result.File.Length / resultSize);
						var averageFileSizeDifference = 100 * (result.File.Length / averageFileSize);
						var medianFileSizeDifference = 100 * (result.File.Length / medianFileSize);

						Console.Write($"\r{DateTime.Now} | {totalProgress} of {resultSize} ({totalProgressPercentage}%) | {result.File.Length} ({fileSizePercentage}%)\t{result.File.Name}");

						ProcessFile(result.File, fileType.Key, fileType.Value);

						totalProgress += result.File.Length;
						totalProgressPercentage += fileSizePercentage;

						Console.Write($"\r{DateTime.Now} | {totalProgress} of {resultSize} ({totalProgressPercentage}%) | {result.File.Length} ({fileSizePercentage}%)\t{result.File.Name}");
					}
				}
				else
					Console.WriteLine($"No {fileType.Key} files were found in {directoryPath}");
			}
		}

		public static void ProcessFile(FileInfo file, ImportFileType fileType, string extension)
		{
			Console.WriteLine($"\r{DateTime.Now}\tParsing {fileType} data from {file.Name}");

			if (!file.Exists || !(file.Length > 0))
				throw new FileNotFoundException($"The {fileType} file you specified either does not exist or was an empty file. Please ensure the file exists and that it contains data.", file.FullName);

			if (!file.Name.ToLowerInvariant().EndsWith(extension.ToLowerInvariant()))
				throw new FileLoadException($"The file you specified does not have a corresponding extension that matches. This application requires that the extensions match the GIS Standards for {fileType} files.", file.FullName);

			switch (fileType)
			{
				case ImportFileType.Index:
					IndexFiles.Add(new IndexFile(file));
					break;
				case ImportFileType.Shape:
					ShapeFiles.Add(new ShapeFile(file));
					break;
				case ImportFileType.Attribute:
					AttributeFiles.Add(new AttributeFile(file));
					break;
				case ImportFileType.FGDCMetadata:
					FGDCMetadataFiles.Add(new FGDCMetadataFile(file));
					break;
				case ImportFileType.ISOMetadata:
					ISOMetadataFiles.Add(new ISOMetadataFile(file));
					break;
				case ImportFileType.ISOEAMetadata:
					ISOEAMetadataFiles.Add(new ISOEAMetadataFile(file));
					break;
				case ImportFileType.Projection:
					ProjectionFiles.Add(new ProjectionFile(file));
					break;
				default:
					throw new Exception($"An unknown import file type was detected ({fileType}). Unable to proceed!");
			}

			Console.WriteLine($"\r{DateTime.Now}\t{file.Name} has finished parsing. Beginning Import");
			// TODO: IMPORT DATA!!!
		}

		public static void ProcessXMLSchemas(DirectoryInfo directory)
		{
			XMLHelper.GetSchemas(directory);
		}

		private static void ImportData()
		{
			if (IndexFiles.Any())
			{

			}

			if (ShapeFiles.Any())
			{

			}

			if (AttributeFiles.Any())
			{

			}

			if (FGDCMetadataFiles.Any())
			{

			}

			if (ISOMetadataFiles.Any())
			{

			}

			if (ISOEAMetadataFiles.Any())
			{

			}

			if (ProjectionFiles.Any())
			{

			}

		}

		#region Extensions

		public const string AttributeFormatExtension = "dbf";
		public const string ProjectionFormatExtension = "prj";
		public const string ShapeFormatExtension = "shp";
		public const string ISO191EAExtension = "shp.ea.iso.xml";
		public const string ISO191Extension = "shp.iso.xml";
		public const string FGDCMetadataExtension = "shp.xml";
		public const string ShapeIndexFormatExtension = "shx";

		public const string GeocodingIndexExtension = "ixs";
		public const string ODBGeocodingIndexExtension = "mxs";
		public const string DbfAttributeIndexExtension = "atx";
		public const string CodePageExtension = "cpg";

		public static readonly string[] SpatialIndexExtension =
		{
			"sbn",
			"sbx"
		};

		public static readonly string[] SpatialIndexReadOnlyExtension =
		{
			"fbn",
			"fbx"
		};

		public static readonly string[] AttributeIndexExtension =
		{
			"ain",
			"aih"
		};

		#endregion Extensions
	}
}