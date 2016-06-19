namespace Shp2Sql.Models.Entity
{
    using System.Data.Entity;
    using System.Linq;
    using Shp2Sql.Models.Binding;

    public partial class ShapefileEntities : DbContext
    {
        public ShapefileEntities()
            : base("name=DefaultConnection")
        {
            if (!ShapeTypes.Any())
                Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT ShapeType ON
INSERT INTO ShapeType (Id, Name, [Description]) VALUES (0, 'Null', null),
														(1, 'Point', null),
														(3, 'Polyline', null),
														(5, 'Polygon', null),
														(8, 'MultiPoint', null),
														(11, 'PointZ', null),
														(13, 'PolylineZ', null),
														(15, 'PolygonZ', null),
														(18, 'MultiPointZ', null),
														(21, 'PointM', null),
														(23, 'PolylineM', null),
														(25, 'PolygonM', null),
														(28, 'MultiPointM', null),
														(31, 'MultiPatch', null)
SET IDENTITY_INSERT ShapeType OFF");
            if (!PartTypes.Any())
                Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT PartType ON
INSERT INTO PartType (Id, Name, [Description]) VALUES	(-1, 'Unassigned', 'There is no assigned part type'),
														(0, 'Triangle Strip', null),
														(1, 'Triangle Fan', null),
														(2, 'Outer Ring', null),
														(3, 'Inner Ring', null),
														(4, 'First Ring', null),
														(5, 'Ring', null)
SET IDENTITY_INSERT ShapeType OFF");
        }

        public DbSet<AttributeFile> AttributeFiles { get; set; }
        public DbSet<IndexFile> IndexFiles { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartType> PartTypes { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Shape> Shapes { get; set; }
        public DbSet<ShapeAttribute> ShapeAttributes { get; set; }
        public DbSet<ShapeFile> ShapeFiles { get; set; }
        public DbSet<ShapeIndex> ShapeIndexes { get; set; }
        public DbSet<ShapeType> ShapeTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttributeFile>()
                .HasMany(e => e.ShapeAttributes)
                .WithRequired(e => e.AttributeFile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IndexFile>()
                .HasMany(e => e.ShapeIndexes)
                .WithRequired(e => e.IndexFile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Part>()
                .HasMany(e => e.Points)
                .WithRequired(e => e.Part)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartType>()
                .HasMany(e => e.Parts)
                .WithRequired(e => e.PartType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shape>()
                .HasMany(e => e.Parts)
                .WithRequired(e => e.Shape)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShapeAttribute>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ShapeAttribute>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<ShapeFile>()
                .HasMany(e => e.Shapes)
                .WithRequired(e => e.ShapeFile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShapeType>()
                .HasMany(e => e.IndexFiles)
                .WithRequired(e => e.ShapeType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShapeType>()
                .HasMany(e => e.ShapeFiles)
                .WithRequired(e => e.ShapeType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShapeType>()
                .HasMany(e => e.Shapes)
                .WithRequired(e => e.ShapeType)
                .WillCascadeOnDelete(false);
        }
    }
}
