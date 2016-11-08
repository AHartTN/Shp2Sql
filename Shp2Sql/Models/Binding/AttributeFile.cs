using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.IO;
using Shp2Sql.Helpers;

namespace Shp2Sql.Models.Binding
{
	#region Imports

	

	#endregion
	[Table("AttributeFile")]
	public class AttributeFile : ImportFile
	{
		public AttributeFile()
		{
			ShapeAttributes = new HashSet<ShapeAttribute>();
		}

		public AttributeFile(FileInfo file)
			: base(file)
		{
			ShapeAttributes = new HashSet<ShapeAttribute>();
			ImportFromFile(file);
		}

		public ICollection<ShapeAttribute> ShapeAttributes { get; set; }

		public void ImportFromFile(FileInfo file)
		{
			try
			{
				DataSet rawResults = new DataSet();

				DataHelper.FillDataSetFromDbf(file, ref rawResults);

				// TODO: PROCESS THE DATASET INTO USABLE DATA
				//foreach (DataTable table in rawResults.Tables)
				//{
				//	LH.WriteLine($"\rTABLE: {table.TableName}" +
				//					  $"\r\nCase Sensitive: {table.CaseSensitive}" +
				//					  $"\r\nChild Relations: {table.ChildRelations}" +
				//					  $"\r\nColumns: {table.Columns}" +
				//					  $"\r\nConstraints: {table.Constraints}" +
				//					  $"\r\nDataset: {table.DataSet}" +
				//					  $"\r\nDefault View: {table.DefaultView}" +
				//					  $"\r\nDisplay Expression: {table.DisplayExpression}" +
				//					  $"\r\nExtended Properties: {table.ExtendedProperties}" +
				//					  $"\r\nHas Errors: {table.HasErrors}" +
				//					  $"\r\nIs Initialized: {table.IsInitialized}" +
				//					  $"\r\nLocale: {table.Locale}" +
				//					  $"\r\nMinimum Capacity: {table.MinimumCapacity}" +
				//					  $"\r\nNamespace: {table.Namespace}" +
				//					  $"\r\nParent Relations: {table.ParentRelations}" +
				//					  $"\r\nPrefix: {table.Prefix}" +
				//					  $"\r\nPrimary Key: {table.PrimaryKey}" +
				//					  $"\r\nRemoting Format: {table.RemotingFormat}" +
				//					  $"\r\nRows: {table.Rows}" +
				//					  $"\r\nSite: {table.Site}");

				//	foreach (DataColumn column in table.Columns)
				//	{
				//		LH.WriteLine($"\rCOLUMN: {column.ColumnName}" +
				//						  $"\r\nAllow DBNull: {column.AllowDBNull}" +
				//						  $"\r\nAuto Increment: {column.AutoIncrement}" +
				//						  $"\r\nAuto Increment Seed: {column.AutoIncrementSeed}" +
				//						  $"\r\nAuto Increment Step: {column.AutoIncrementStep}" +
				//						  $"\r\nCaption: {column.Caption}" +
				//						  $"\r\nColumnMapping: {column.ColumnMapping}" +
				//						  $"\r\nDatatype: {column.DataType}" +
				//						  $"\r\nDateTime Mode: {column.DateTimeMode}" +
				//						  $"\r\nDefault Value: {column.DefaultValue}" +
				//						  $"\r\nExpression: {column.Expression}" +
				//						  $"\r\nExtended Properties: {column.ExtendedProperties}" +
				//						  $"\r\nMax Length: {column.MaxLength}" +
				//						  $"\r\nNamespace: {column.Namespace}" +
				//						  $"\r\nOrdinal: {column.Ordinal}" +
				//						  $"\r\nPrefix: {column.Prefix}" +
				//						  $"\r\nReadonly: {column.ReadOnly}" +
				//						  $"\r\nTable: {column.Table}" +
				//						  $"\r\nUnique: {column.Unique}");
				//	}

				//	foreach (DataRow row in table.Rows)
				//	{
				//		LH.WriteLine($"Row:" +
				//						  $"\r\nHas Errors: {row.HasErrors}" +
				//						  $"\r\nItem Array: {row.ItemArray}" +
				//						  $"\r\nRow Error: {row.RowError}" +
				//						  $"\r\nRow State: {row.RowState}" +
				//						  $"\r\nTable: {row.Table}" +
				//						  $"\r\nValues: {string.Join(" | ", row.ItemArray)}");
				//	}
				//}
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}
	}
}