using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using Shp2Sql.Helpers;

namespace Shp2Sql.Models.Binding
{
	#region Imports

	

	#endregion
	public class ProjectionFile : ImportFile
	{
		public ProjectionFile()
		{
		}

		public ProjectionFile(FileInfo file)
			: base(file)
		{
			ImportFromFile(file);
		}

		public string WellKnownText { get; set; }

		public string RawDatum => Regex.Match(WellKnownText, @"DATUM\[""(?<Value>.*?)""").Groups["Value"].Value;

		public string Datum => RawDatum.TrimStart("GCS_".ToCharArray()).TrimStart("D_".ToCharArray()).Replace("_", " ");

		private int? _srid { get; set; }

		public int SRID
		{
			get
			{
				if (_srid == null
					|| !(_srid > 0))
				{
					int? result;
					using (SqlConnection conn = new SqlConnection(DataHelper.DefaultConnectionString))
					{
						using (SqlCommand cmd = conn.CreateCommand())
						{
							cmd.CommandType = CommandType.Text;
							cmd.CommandText =
								$"SELECT TOP 1 spatial_reference_id FROM sys.spatial_reference_systems A WHERE A.well_known_text LIKE '%DATUM[\"{Datum}\"]%'";

							//LH.WriteLine(cmd.CommandText);

							conn.Open();

							result = (int?) cmd.ExecuteScalar();

							//LH.WriteLine($"SRID: {result}");

							conn.Close();
						}
					}

					_srid = result ?? 4326;
				}

				return (int) _srid;
			}
		}

		public void ImportFromFile(FileInfo file)
		{
			try
			{
				using (StreamReader sr = new StreamReader(file.FullName))
				{
					WellKnownText = sr.ReadToEnd();
					sr.Close();
				}
				LH.Write($"\r{file.Name.Split('.')[0]} has an SRID of {SRID}\t\t\t\t\t");
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}
	}
}