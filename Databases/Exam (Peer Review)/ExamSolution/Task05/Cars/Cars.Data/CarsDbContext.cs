using System;
using System.Linq;
using System.Data.Entity;
using Cars.Models;
//using Cars.Data.Migrations;

namespace Cars.Data
{
    public class CarsDbContext: DbContext
    {
        public CarsDbContext()
            : base("CarsConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
        }
        
        public IDbSet<Car> Cars { get; set; }

        public IDbSet<City> City { get; set; }
        
        public IDbSet<Dealer> Dealers { get; set; }
        
        public IDbSet<Manufacturer> Manufacturers { get; set; }     

        public IDbSet<Model> Models { get; set; }

        public IDbSet<TransmissionType> TransmissionTypes { get; set; }

    }
}
