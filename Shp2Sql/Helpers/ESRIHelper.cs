using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shp2Sql.Enumerators;
using Shp2Sql.Models.Binding;
using Shp2Sql.Models.Entity;

namespace Shp2Sql.Helpers
{
	#region Imports

	

	#endregion
	public class ESRIHelper
	{
		public ESRIHelper()
		{
			CodePageFiles = new HashSet<CodePageFile>();
			ProjectionFiles = new HashSet<ProjectionFile>();
			MetadataFiles = new HashSet<MetadataFile>();

			SetSimpleLogging();
		}

		public static Dictionary<ImportFileType, string> FileTypes => new Dictionary<ImportFileType, string>
		{
			{ImportFileType.CodePage, CodePageExtension},
			{ImportFileType.Projection, ProjectionExtension},
			{ImportFileType.XmlFile, XmlFileExtension},
			{ImportFileType.XmlSchema, XmlSchemaExtension},
			{ImportFileType.Attribute, AttributeExtension},
			{ImportFileType.Shape, ShapeExtension},
			{ImportFileType.Index, IndexExtension},
			{ImportFileType.GeocodingIndex, GeocodingIndexExtension},
			{ImportFileType.ODBGeocodingIndex, ODBGeocodingIndexExtension}
		};
		#region Extensions

		public const string XmlFileExtension = ".xml";
		public const string XmlSchemaExtension = ".xsd";
		public const string CodePageExtension = ".cpg";
		public const string ShapeExtension = ".shp";
		public const string IndexExtension = ".shx";
		public const string ProjectionExtension = ".prj";
		public const string AttributeExtension = ".dbf";
		public const string GeocodingIndexExtension = ".ixs";
		public const string ODBGeocodingIndexExtension = ".mxs";
		public const string DbfAttributeIndexExtension = ".atx";

		public readonly string[] SpatialIndexExtension =
		{
			".sbn",
			".sbx"
		};

		public readonly string[] SpatialIndexReadOnlyExtension =
		{
			".fbn",
			".fbx"
		};

		public readonly string[] AttributeIndexExtension =
		{
			".ain",
			".aih"
		};

		#endregion Extensions
		#region Methods

		public static ImportFileType GetImportFileType(FileInfo file)
		{
			try
			{
				foreach (
					KeyValuePair<ImportFileType, string> type in
						FileTypes.Where(type => file.Name.ToLowerInvariant().EndsWith(type.Value.ToLowerInvariant())))
				{
					return type.Key;
				}
				throw new ArgumentException("The file specified is not a valid import file!");
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static string GetImportFileExtension(ImportFileType fileType)
		{
			try
			{
				string value = FileTypes[fileType];

				if (value == null)
					throw new ArgumentException("The file specified is not a valid import file!");

				return value;
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public void SetSimpleLogging()
		{
			using (ShapefileEntities db = new ShapefileEntities())
			{
				db.Database.Initialize(true);
			}

			using (SqlConnection conn = new SqlConnection(DataHelper.DefaultConnectionString))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandTimeout = DataHelper.DefaultTimeoutSeconds;
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = $"ALTER DATABASE {conn.Database} SET RECOVERY SIMPLE";

					try
					{
						conn.Open();
						cmd.ExecuteNonQuery();
						conn.Close();
					}
					catch (Exception e)
					{
						LH.Error($"\r\n{e.Message}\r\n{e}");
						throw;
					}
					finally
					{
						conn.Close();
					}
				}
			}
		}

		public void ProcessDirectory(string directoryPath, Dictionary<ImportFileType, string> fileTypes = null)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(directoryPath))
					throw new ArgumentException(
						$"\"{directoryPath}\" is an invalid directory path.\r\nThe specified path cannot be empty or null.\r\nPlease specify a valid file path and try again.");

				ProcessDirectory(new DirectoryInfo(directoryPath));
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public void ProcessDirectory(DirectoryInfo directory, Dictionary<ImportFileType, string> fileTypes = null)
		{
			try
			{
				if (directory == null
					|| !directory.Exists)
					throw new Exception(
						"The specified directory does not exist! Unable to process a directory from nothing or a non-existent path.");

				LH.WriteLine($"\r{DateTime.Now} | Processing files in {directory.Name}\t\t\t\t\t");

				fileTypes = fileTypes ?? FileTypes;

				IReadOnlyCollection<FileInfo> files;
				// Kept separate from first definition so we can comment out certain sections to work on only what we want

				//files = directory.GetFiles($"*{fileTypes[ImportFileType.CodePage]}");

				//if (!files.Any())
				//	LH.WriteLine($"\rNo Code Page Files were found. Defaulting to {DefaultCodePage.Encoding.EncodingName}\t\t\t\t\t");
				//else
				//	foreach (FileInfo file in files)
				//		CodePageFiles.Add(new CodePageFile(file));

				//files = directory.GetFiles($"*{fileTypes[ImportFileType.Projection]}");

				//if (!files.Any())
				//	LH.WriteLine($"\rNo Projection Files were found. Defaulting to SRID {DefaultSRID}\t\t\t\t\t");
				//else
				//	foreach (FileInfo file in files)
				//		ProjectionFiles.Add(new ProjectionFile(file));

				files = directory.GetFiles($"*{fileTypes[ImportFileType.XmlFile]}").OrderBy(o => o.Name).ToArray();

				if (!files.Any())
					throw new Exception($"\rNo Metadata Files were found! Unable to generate appropriate schemas!");

				foreach (FileInfo file in files)
					MetadataFiles.Add(new MetadataFile(file));

				//Parallel.ForEach(files, f => MetadataFiles.Add(new MetadataFile(f)));
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		//public void ProcessDirectory(string directoryPath /*, Dictionary<ImportFileType, string> fileTypes = null*/)
		//{
		//	try
		//	{
		//		DirectoryInfo directory = new DirectoryInfo(directoryPath);

		//		if (!directory.Exists)
		//			throw new Exception("The specified directory does not exist!");

		//		SetSimpleLogging();

		//		LH.Write($"\r{DateTime.Now} | Processing all files in {directory.Name}\t\t\t\t\t");

		//		//IReadOnlyCollection<IGrouping<string, FileInfo>> fileGroups = directory.GetFiles("*", SearchOption.AllDirectories)
		//		//	.OrderBy(o => o.Name.Split('_')[3])
		//		//	.ThenByDescending(o => o.Name.Split('_')[2].ToLowerInvariant().Equals("us"))
		//		//	.ThenByDescending(t => t.Name.Split('_')[2].Length == 2)
		//		//	.ThenByDescending(t => t.Name.Split('_')[2].Length > 2)
		//		//	.ThenBy(t => t.Name.Split('_')[3])
		//		//	.ThenBy(t => t.Length)
		//		//	.GroupBy(g => g.Name.Split('.')[0])
		//		//	.ToArray();

		//		IReadOnlyCollection<IGrouping<string, FileInfo>> fileGroups = directory.GetFiles("*", SearchOption.AllDirectories)
		//			.OrderByDescending(o => o.Name.EndsWith(GetImportFileExtension(ImportFileType.CodePage)))
		//			.ThenByDescending(t => t.Name.EndsWith(GetImportFileExtension(ImportFileType.Projection)))
		//			.ThenByDescending(o => o.Name.EndsWith(GetImportFileExtension(ImportFileType.XmlFile)))
		//			.ThenByDescending(t => t.Name.EndsWith(GetImportFileExtension(ImportFileType.XmlSchema)))
		//			.ThenByDescending(t => t.Name.EndsWith(GetImportFileExtension(ImportFileType.Attribute)))
		//			.ThenByDescending(t => t.Name.EndsWith(GetImportFileExtension(ImportFileType.Index)))
		//			.ThenByDescending(t => t.Name.EndsWith(GetImportFileExtension(ImportFileType.Shape)))
		//			// Tiger naming convention ordering
		//			.ThenByDescending(o => o.Name.Split('_')[2].ToLowerInvariant().Equals("us"))
		//			.ThenByDescending(t => t.Name.Split('_')[2].Length.Equals(2))
		//			.ThenByDescending(t => t.Name.Split('_')[2].Length > 2)
		//			.ThenBy(t => t.Name.Split('_')[3])
		//			.ThenBy(t => t.Name)
		//			.ThenBy(t => t.Length)
		//			//.GroupBy(g => g.Name.Split('_')[3]) // state, county, city, place, etc (Tiger naming convention) IE: a_b_state*, a_b_city*
		//			.GroupBy(g => g.Name.Replace(GetImportFileExtension(GetImportFileType(g)), "").Trim('.').Trim()) // Import File grouping by name IE: a.xml, a.dbf, a.shp
		//			.ToArray();

		//		if (!fileGroups.Any()
		//			|| !(fileGroups.Sum(s => s.Count()) > 0))
		//			throw new FileNotFoundException(
		//				"No files/groups were found in the specified directory. Please check the directory and try again.");

		//		foreach (IGrouping<string, FileInfo> fileGroup in fileGroups.Where(w => !w.Any() || w.Any(a => !a.Exists)))
		//		{
		//			LH.Write($"\rSkipping {fileGroup.Key} as it contained no valid files. (How did this happen?)\t\t\t\t\t");
		//		}

		//		//Parallel.ForEach(fileGroups.Where(w => w.Any() && w.All(a => a.Exists)), ProcessFileGroup);
		//		//Parallel.ForEach(fileGroups.Where(w => w.Any()), ProcessFileGroupAsync);

		//		foreach (IGrouping<string, FileInfo> fileGroup in fileGroups.Where(w => w.Any()))
		//		{
		//			// Async group processing causes a read from toooooo many files and results take FOREVER to show up
		//			// We like immediate results so lets leave the file groups synchronous and do the individual files asyncronously
		//			ProcessFileGroup(fileGroup);
		//			//ProcessFileGroupAsync(fileGroup);
		//			LH.Write($"\rParsing of {fileGroup.Key} is complete\t\t\t\t\t");
		//		}
		//	}
		//	catch (Exception e)
		//	{
		//		LH.Error($"\r\n{e.Message}\r\n{e}");
		//		throw;
		//	}
		//}

		public void ProcessFileGroup(IGrouping<string, FileInfo> fileGroup)
		{
			try
			{
				LH.Write($"\rNow handling {fileGroup.Key} files\t\t\t\t\t");

				//Parallel.ForEach(fileGroup, ProcessFile);
				//Parallel.ForEach(fileGroup, ProcessFileAsync);

				foreach (FileInfo file in fileGroup)
				{
					//ProcessFile(file);
					ProcessFileAsync(file);
				}

				LH.Write($"\r{DateTime.Now} | {fileGroup.Key} has finished parsing\t\t\t\t\t");
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public async void ProcessFileGroupAsync(IGrouping<string, FileInfo> fileGroup)
		{
			try
			{
				Task task = Task.Run(() => ProcessFileGroup(fileGroup));
				await task;
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public void ProcessFile(FileInfo file)
		{
			try
			{
				if (file == null
					|| !file.Exists)
					throw new FileNotFoundException("Please specify a valid file and try the ProcessFile method again.");

				LH.Write($"\rProcessing {file.Name}\t\t\t\t\t");

				ImportFileType importFileType = GetImportFileType(file);
				string fileExtension = GetImportFileExtension(importFileType);

				//LH.Write($"\r{file.Name} is a(n) {importFileType} file with an extension of {fileExtension}\t\t\t\t\t");

				switch (importFileType)
				{
					case ImportFileType.CodePage:
						//CodePageFile codePageFile = new CodePageFile(file);
						break;
					case ImportFileType.XmlFile:
						MetadataFile metadataFile = new MetadataFile(file);
						break;
					case ImportFileType.Projection:
						ProjectionFile projectionFile = new ProjectionFile(file);
						break;
					case ImportFileType.Attribute:
						//AttributeFile attributeFile = new AttributeFile(file);
						break;
					case ImportFileType.Index:
						//IndexFile indexFile = new IndexFile(file);
						break;
					case ImportFileType.Shape:
						//ShapeFile shapeFile = new ShapeFile(file);
						//LH.Write($"\rShapeFile Inserted: {shapeFile.Name}\t\t\t\t\t");
						break;
					case ImportFileType.GeocodingIndex:
					case ImportFileType.ODBGeocodingIndex:
						throw new NotImplementedException(
							"We currently do not handle the processing of Geocoding Indexes or ODB Geocoding indexes. (We make our own in SQL Server)");
					case ImportFileType.XmlSchema:
						LH.WriteLine(
							$"\rNo data is contained within {file.Name}. This application generates and utilizes it's own schema XML schema documentation. No actions performed with this file.");
						break;
					default:
						throw new NotImplementedException(
							$"{file.Extension} is not a supported file type. Extensions must match the ESRI Shapefile specifications.");
				}
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public async void ProcessFileAsync(FileInfo file)
		{
			try
			{
				Task task = Task.Run(() => ProcessFile(file));
				await task;
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public async Task<int> ImportData<TContext, TData>(TContext context, TData data) where TContext : DbContext
			where TData : class
		{
			try
			{
				context.Entry(data).State = EntityState.Added;
				context.Set<TData>().Add(data);

				return await context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		#endregion
		#region Properties

		private ICollection<CodePageFile> CodePageFiles { get; set; }
		private ICollection<ProjectionFile> ProjectionFiles { get; set; }
		private ICollection<MetadataFile> MetadataFiles { get; }

		public static CodePageFile DefaultCodePage => new CodePageFile {EncodingValue = Encoding.Default.EncodingName};
		private int DefaultSRID => 4326;
		public static LogHelper LH = new LogHelper();

		#endregion
	}
}