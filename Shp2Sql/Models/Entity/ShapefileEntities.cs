using System.Data.Entity;
using Shp2Sql.Helpers;
using Shp2Sql.Models.Binding;

namespace Shp2Sql.Models.Entity
{
	#region Imports

	

	#endregion
	public class ShapefileEntities : DbContext
	{
		public ShapefileEntities()
			: base("name=DefaultConnection")
		{
			Configuration.AutoDetectChangesEnabled = false;
			Configuration.ValidateOnSaveEnabled = false;
			Database.CommandTimeout = DataHelper.DefaultTimeoutSeconds;
		}

		public DbSet<AttributeFile> AttributeFiles { get; set; }
		public DbSet<CodePageFile> CodePageFiles { get; set; }
		public DbSet<IndexFile> IndexFiles { get; set; }
		public DbSet<MetadataFile> MetadataFiles { get; set; }
		public DbSet<ProjectionFile> ProjectionFiles { get; set; }
		public DbSet<Shape> Shapes { get; set; }
		public DbSet<ShapeAttribute> ShapeAttributes { get; set; }
		public DbSet<ShapeFile> ShapeFiles { get; set; }
		public DbSet<ShapeIndex> ShapeIndexes { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AttributeFile>()
				.HasMany(e => e.ShapeAttributes)
				.WithRequired(e => e.AttributeFile)
				.HasForeignKey(fk => fk.AttributeFileId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<IndexFile>()
				.HasMany(e => e.ShapeIndexes)
				.WithRequired(e => e.IndexFile)
				.HasForeignKey(fk => fk.IndexFileId)
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
				.HasForeignKey(fk => fk.ShapeFileId)
				.WillCascadeOnDelete(false);
		}
	}
}