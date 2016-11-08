using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shp2Sql.Helpers;

namespace Shp2Sql.Models.Base
{
	#region Imports

	

	#endregion
	#region Imports

	#endregion
	public class BaseModel
	{
		[NotMapped]
		public static LogHelper LH = new LogHelper();

		[Key]
		public long Id { get; set; }
	}
}