using System;

namespace Shp2Sql.Helpers
{
	#region Imports

	

	#endregion
	#region Using Directives

	#endregion
	/// <summary>A class designed for aiding with common funtions regarding numerical values.</summary>
	public class NumericsHelper
	{
		/// <summary>Convert an integer's byte order</summary>
		/// <param name="source">The integer to reverse</param>
		/// <returns>The reversed integer (Small if source was big and visa-versa)</returns>
		public static int ReverseInt(int source)
		{
			byte[] fileCodeBytes = BitConverter.GetBytes(source);
			Array.Reverse(fileCodeBytes);
			//string fileCodeByteString = fileCodeBytes.ToString();
			return BitConverter.ToInt32(fileCodeBytes, 0);
		}
	}
}