using System.ComponentModel.DataAnnotations.Schema;
using Shp2Sql.Models.Base;

namespace Shp2Sql.Models.Binding
{
	#region Imports

	

	#endregion
	#region Imports

	#endregion
	[Table("ShapeIndex")]
	public class ShapeIndex : BaseModel
	{
		public long IndexFileId { get; set; }

		public int RecordNumber { get; set; }

		public int Offset { get; set; }

		public int ContentLength { get; set; }

		public IndexFile IndexFile { get; set; }
	}
}