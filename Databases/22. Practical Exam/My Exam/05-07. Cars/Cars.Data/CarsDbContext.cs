namespace Cars.Data
{
    using System.Data.Entity;

    using Cars.Models;
    using Migrations;

    public class CarsDbContext : DbContext
    {
        public CarsDbContext()
            : base("CarsConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
        }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<City> Cities { get; set; }
    }
}
