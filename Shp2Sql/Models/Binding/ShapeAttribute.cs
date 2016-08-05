using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shp2Sql.Models.Binding
{
	[Table("ShapeAttribute")]
	public class ShapeAttribute
	{
		public long Id { get; set; }

		public long AttributeFileId { get; set; }

		public int RecordNumber { get; set; }

		[Required]
		[StringLength(256)]
		public string Name { get; set; }

		[Required]
		public string Value { get; set; }

		public AttributeFile AttributeFile { get; set; }
	}
}