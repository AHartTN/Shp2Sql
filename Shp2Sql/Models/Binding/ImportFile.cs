using System.IO;
using Shp2Sql.Enumerators;
using Shp2Sql.Models.Base;

namespace Shp2Sql.Models.Binding
{
	#region Imports

	

	#endregion
	public class ImportFile : BaseFile
	{
		public ImportFile()
		{
		}

		public ImportFile(FileInfo file)
			: base(file)
		{
		}

		public ShapeType ShapeType { get; set; }

		public int? FileCode { get; set; }

		public int? ContentLength { get; set; }

		public int? FileVersion { get; set; }
	}
}