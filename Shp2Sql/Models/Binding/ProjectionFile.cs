using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shp2Sql.Models.Binding
{
	public class ProjectionFile : ImportFile
	{
		public ProjectionFile() : base()
		{
			
		}

		public ProjectionFile(FileInfo file) : base(file)
		{
			ReadFromFile(file);
		}

		public void ReadFromFile(FileInfo file)
		{
			
		}
	}
}
