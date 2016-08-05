using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shp2Sql.Models.Binding
{
	[Table("ShapeType")]
	public class ShapeType
	{
		public ShapeType()
		{
			ShapeFiles = new HashSet<ShapeFile>();
			Shapes = new HashSet<Shape>();
		}

		public long Id { get; set; }

		[Required]
		[StringLength(128)]
		public string Name { get; set; }

		[StringLength(1024)]
		public string Description { get; set; }

		public ICollection<ShapeFile> ShapeFiles { get; set; }
		public ICollection<IndexFile> IndexFiles { get; set; }
		public ICollection<Shape> Shapes { get; set; }
	}
}