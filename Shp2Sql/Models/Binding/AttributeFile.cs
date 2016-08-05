using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using Shp2Sql.Classes.Helpers;

namespace Shp2Sql.Models.Binding
{
	[Table("AttributeFile")]
	public class AttributeFile : ImportFile
	{
		public AttributeFile() : base()
		{
			ShapeAttributes = new HashSet<ShapeAttribute>();
		}
		public AttributeFile(FileInfo file) : base(file)
		{
			ShapeAttributes = new HashSet<ShapeAttribute>();
			ReadFromFile(file);
		}

		public void ReadFromFile(FileInfo file)
		{
			FileInfo workingFile = CreateWorkingFile(file);

			DataSet rawResults = new DataSet();
			
			using (OleDbConnection conn = new OleDbConnection(DataHelper.GetDbfConnectionString(workingFile.DirectoryName)))
			using (OleDbCommand cmd = conn.CreateCommand())
			{
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = DataHelper.GetDbfSelectString(workingFile);
				cmd.CommandTimeout = 600;


				cmd.Connection.Open();

				var schema = cmd.Connection.GetSchema();
				OleDbDataAdapter da = new OleDbDataAdapter(cmd);
				//da.FillSchema(rawResults, SchemaType.Mapped);
				da.Fill(rawResults);
			}

			// TODO: PROCESS THE DATASET INTO USABLE DATA

			workingFile.Delete();
		}

		public static FileInfo CreateWorkingFile(FileInfo file)
		{
			string workingFilePath = $"{file.DirectoryName}\\ATTRFILE.dbf";
			file.CopyTo(workingFilePath, true);
			FileInfo workingFile = new FileInfo(workingFilePath);
			return workingFile;
		}

		public ICollection<ShapeAttribute> ShapeAttributes { get; set; }
	}
}