namespace Shp2Sql.Models.Binding
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ShapeType")]
    public partial class ShapeType
    {
        public ShapeType()
        {
            ShapeFiles = new List<ShapeFile>();
            Shapes = new List<Shape>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public List<ShapeFile> ShapeFiles { get; set; }
        public List<IndexFile> IndexFiles { get; set; } 
        public List<Shape> Shapes { get; set; }
    }
}
