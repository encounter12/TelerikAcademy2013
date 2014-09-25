using System;
using System.Linq;
using Cars.Data;
using Cars.Models;

namespace Cars.Importer
{
    class Program
    {
        static void Main()
        {
            var db = new CarsDbContext();

            db.Manufacturers.Any();
        }
    }
}
