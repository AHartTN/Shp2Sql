using System.ComponentModel.DataAnnotations.Schema;

namespace Shp2Sql.Models.Binding
{
	[Table("ShapeIndex")]
	public class ShapeIndex
	{
		public long Id { get; set; }

		public long IndexFileId { get; set; }

		public int RecordNumber { get; set; }

		public int Offset { get; set; }

		public int ContentLength { get; set; }

		public IndexFile IndexFile { get; set; }
	}
}