using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;

namespace Shp2Sql.Models.Binding
{
	#region Imports

	

	#endregion
	public class CodePageFile : ImportFile
	{
		public CodePageFile()
		{
		}

		public CodePageFile(FileInfo file)
			: base(file)
		{
			ImportFromFile(file);
		}

		public string EncodingValue { get; set; }

		[NotMapped]
		public Encoding Encoding => Encoding.GetEncoding(EncodingValue ?? "UTF8");

		public void ImportFromFile(FileInfo file)
		{
			try
			{
				using (StreamReader sr = new StreamReader(file.OpenRead()))
				{
					EncodingValue = sr.ReadToEnd();
					LH.Write($"\r{file.Name.Split('.')[0]} has an encoding type of {EncodingValue}\t\t\t\t\t");
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