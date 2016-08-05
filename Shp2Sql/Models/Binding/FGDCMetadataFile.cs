using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Shp2Sql.Classes.Helpers;

namespace Shp2Sql.Models.Binding
{
	public class FGDCMetadataFile : ImportFile
	{
		public FGDCMetadataFile() : base()
		{

		}
		public FGDCMetadataFile(FileInfo file) : base(file)
		{
			ReadFromFile(file);
		}

		public void ReadFromFile(FileInfo file)
		{
			XmlDocument document = XMLHelper.GetXmlDocument(file.FullName);
		}
	}
}
