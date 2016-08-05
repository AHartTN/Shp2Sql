using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shp2Sql.Models.Binding
{
	public class ISOEAMetadataFile : ImportFile
	{
		public ISOEAMetadataFile() : base()
		{

		}
		public ISOEAMetadataFile(FileInfo file) : base(file)
		{
			ReadFromFile(file);
		}

		public void ReadFromFile(FileInfo file)
		{

		}
	}
}
