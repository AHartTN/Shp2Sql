namespace Shp2Sql.Models.Binding
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PartType")]
    public partial class PartType
    {
        public PartType()
        {
            Parts = new List<Part>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public List<Part> Parts { get; set; }
    }
}
