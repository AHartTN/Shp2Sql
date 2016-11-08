using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using Shp2Sql.Enumerators;
using Shp2Sql.Helpers;
using Shp2Sql.Models.Entity;

namespace Shp2Sql.Models.Binding
{
	#region Imports

	

	#endregion
	[Table("IndexFile")]
	public class IndexFile : ImportFile
	{
		public IndexFile()
		{
			ShapeIndexes = new HashSet<ShapeIndex>();
		}

		public IndexFile(FileInfo file)
			: base(file)
		{
			ShapeIndexes = new HashSet<ShapeIndex>();
			ImportFromFile(file);
		}

		public double XMin { get; set; }

		public double YMin { get; set; }

		public double XMax { get; set; }

		public double YMax { get; set; }

		public double? ZMin { get; set; }

		public double? ZMax { get; set; }

		public double? MMin { get; set; }

		public double? MMax { get; set; }

		public ICollection<ShapeIndex> ShapeIndexes { get; set; }

		public void ImportFromFile(FileInfo file)
		{
			try
			{
				using (BinaryReader br = new BinaryReader(file.OpenRead()))
				{
					long streamLength = br.BaseStream.Length;
					FileCode = NumericsHelper.ReverseInt(br.ReadInt32());

					for (int i = 0; i < 5; i++)
						br.ReadInt32(); // Skip 5 empty Integer (4-byte) slots

					ContentLength = NumericsHelper.ReverseInt(br.ReadInt32()); // Big Endian, Reverse for actual value
					FileVersion = br.ReadInt32();
					ShapeType = (ShapeType) br.ReadInt32();
					XMin = br.ReadDouble();
					YMin = br.ReadDouble();
					XMax = br.ReadDouble();
					YMax = br.ReadDouble();
					ZMin = br.ReadDouble();
					ZMax = br.ReadDouble();
					MMin = br.ReadDouble();
					MMax = br.ReadDouble();

					int rowsAffected;
					using (ShapefileEntities db = new ShapefileEntities())
					{
						db.Entry(this).State = EntityState.Added;
						rowsAffected = db.SaveChanges();
					}

					if (!(rowsAffected > 0)
						|| !(Id > 0))
						throw new Exception(
							"The index file was not added to the database properly. No ID is present to assign to the child index records. Unable to proceed!");

					List<ShapeIndex> shapeIndices = new List<ShapeIndex>();
					int counter = 0;
					while (br.PeekChar() > -1)
					{
						LH.Write(StringHelper.GetProgressString(br.BaseStream.Position, streamLength, file.Name));
						shapeIndices.Add(new ShapeIndex
						{
							IndexFileId = Id,
							RecordNumber = ++counter,
							Offset = NumericsHelper.ReverseInt(br.ReadInt32()),
							ContentLength = NumericsHelper.ReverseInt(br.ReadInt32())
						});
					}

					LH.Write(StringHelper.GetProgressString(br.BaseStream.Position, streamLength, file.Name));

					using (SqlBulkCopy sbc = new SqlBulkCopy(DataHelper.DefaultConnectionString))
					{
						sbc.BatchSize = DataHelper.DefaultBatchSize;
						sbc.BulkCopyTimeout = DataHelper.DefaultTimeoutSeconds;
						sbc.DestinationTableName = "ShapeIndex";
						sbc.EnableStreaming = true;
						sbc.SqlRowsCopied += DataHelper.SqlBulkCopy_SqlRowsCopied;
						sbc.NotifyAfter = DataHelper.DefaultBatchSize;

						sbc.ColumnMappings.Add("Id", "Id");
						sbc.ColumnMappings.Add("IndexFileId", "IndexFileId");
						sbc.ColumnMappings.Add("RecordNumber", "RecordNumber");
						sbc.ColumnMappings.Add("Offset", "Offset");
						sbc.ColumnMappings.Add("ContentLength", "ContentLength");

						try
						{
							DataTable shapeIndicesData = DataHelper.CreateDataTable(shapeIndices);
							sbc.WriteToServerAsync(shapeIndicesData);
						}
						catch (Exception e)
						{
							LH.Error($"\r\n{e.Message}\r\n{e}");
							throw;
						}
						finally
						{
							sbc.Close();
						}
					}
				}
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}
	}
}