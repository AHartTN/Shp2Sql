namespace Shp2Sql.Models.Binding
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AttributeFile")]
    public partial class AttributeFile
    {
        public AttributeFile()
        {
            ShapeAttributes = new List<ShapeAttribute>();
        }

        public long Id { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime CreationTimeUtc { get; set; }

        [Required]
        [StringLength(1024)]
        public string DirectoryName { get; set; }

        [Required]
        [StringLength(8)]
        public string Extension { get; set; }

        [Required]
        [StringLength(1024)]
        public string FullName { get; set; }

        public bool IsReadOnly { get; set; }

        public DateTime LastAccessTime { get; set; }

        public DateTime LastAccessTimeUtc { get; set; }

        public DateTime LastWriteTime { get; set; }

        public DateTime LastWriteTimeUtc { get; set; }

        public long FileLength { get; set; }

        [Required]
        [StringLength(1024)]
        public string Name { get; set; }

        public List<ShapeAttribute> ShapeAttributes { get; set; }
    }
}
