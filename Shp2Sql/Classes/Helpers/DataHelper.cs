using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Shp2Sql.Classes.Helpers
{
	public class DataHelper
	{
		public const string DbfConnectionStringTemplate = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=dBASE IV;";

		public static string GetDbfConnectionString(string filePath)
		{
			if (!filePath.EndsWith("\\"))
				filePath += "\\";

			return string.Format(DbfConnectionStringTemplate, filePath);
		}

		public static string GetDbfSelectString(FileInfo file)
		{
			//return $"SELECT * FROM [{file.Name}]";
			//return $"SELECT * FROM [{file.Name.Replace($".{file.Extension.Trim('.')}", "")}]";

			return $"SELECT * FROM {file.Name.Substring(0,8)}";
		}
		public static DataTable CreateDataTable<T>(IEnumerable<T> list)
		{
			var type = typeof(T);
			var properties = type.GetProperties();

			var dataTable = new DataTable();
			foreach (var info in properties)
				dataTable.Columns.Add(new DataColumn(info.Name, info.PropertyType));

			foreach (var entity in list)
			{
				var values = new object[properties.Length];
				for (var i = 0; i < properties.Length; i++)
					values[i] = properties[i].GetValue(entity);
				dataTable.Rows.Add(values);
			}

			return dataTable;
		}
	}
}