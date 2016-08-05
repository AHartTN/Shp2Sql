using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shp2Sql.Classes.Helpers
{
	public class StringHelper
	{
		public static string GetProgressString(long charIndex, long fileLength, string name)
		{
			decimal percentage = 100 * (charIndex / fileLength);
			return $"\r{DateTime.Now}\t{charIndex} of {fileLength} ({percentage}%): {name}\t\t";
		}
	}
}
