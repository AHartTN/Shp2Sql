using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shp2Sql.Models.Binding
{
	public class ImportFile : BaseFile
	{
		public ImportFile() : base()
		{
		}

		public ImportFile(FileInfo file) : base(file)
		{

		}

		public long ShapeTypeId { get; set; }

		public int FileCode { get; set; }

		public int ContentLength { get; set; }

		public int FileVersion { get; set; }
	}
}
