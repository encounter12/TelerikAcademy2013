namespace ToysStore.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using Migrations;

    public partial class ToysStoreDbContext : DbContext
    {
        public ToysStoreDbContext()
            : base("name=ToysStoreDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ToysStoreDbContext, Configuration>());
        }

        public virtual DbSet<AgeRanx> AgeRanges { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Toy> Toys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeRanx>()
                .HasMany(e => e.Toys)
                .WithRequired(e => e.AgeRanx)
                .HasForeignKey(e => e.AgeRangeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Toys)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("ToysCategories").MapLeftKey("CategoryId").MapRightKey("ToyId"));

            modelBuilder.Entity<Manufacturer>()
                .HasMany(e => e.Toys)
                .WithRequired(e => e.Manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Toy>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }
    }
}
