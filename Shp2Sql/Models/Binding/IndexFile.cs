namespace Shp2Sql.Models.Binding
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IndexFile")]
    public partial class IndexFile
    {
        public IndexFile()
        {
            ShapeIndexes = new List<ShapeIndex>();
        }

        public long Id { get; set; }

        public long ShapeTypeId { get; set; }

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

        public int FileCode { get; set; }

        public int ContentLength { get; set; }

        public int FileVersion { get; set; }

        public double XMin { get; set; }

        public double YMin { get; set; }

        public double XMax { get; set; }

        public double YMax { get; set; }

        public double? ZMin { get; set; }

        public double? ZMax { get; set; }

        public double? MMin { get; set; }

        public double? MMax { get; set; }

        public ShapeType ShapeType { get; set; }

        public List<ShapeIndex> ShapeIndexes { get; set; }
    }
}
