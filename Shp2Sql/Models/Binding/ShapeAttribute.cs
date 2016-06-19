namespace Shp2Sql.Models.Binding
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ShapeAttribute")]
    public partial class ShapeAttribute
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
