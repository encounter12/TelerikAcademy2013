namespace ToysStore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ToysStore.Models;
    using Migrations;

    public class ToysStoreEntities : DbContext
    {
        public ToysStoreEntities()
            : base("name=ToysStoreEntities")
        {
            //Database.SetInitializer<ToysStoreEntities>(new CreateDatabaseIfNotExists<ToysStoreEntities>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ToysStoreEntities, Configuration>());
        }

        public virtual IDbSet<Toy> Toys { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }
        public virtual IDbSet<AgeRange> AgeRanges { get; set; }
    }
}