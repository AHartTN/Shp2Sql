using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shp2Sql.Models.Binding
{
	[Table("PartType")]
	public class PartType
	{
		public PartType()
		{
			Parts = new HashSet<Part>();
		}

		public long Id { get; set; }

		[Required]
		[StringLength(128)]
		public string Name { get; set; }

		[StringLength(1024)]
		public string Description { get; set; }

		public ICollection<Part> Parts { get; set; }
	}
}