namespace Cars.DataImporter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Xml.Linq;

    using Cars.Data;
    using Cars.Models;

    using Newtonsoft.Json;
    using System.Data.Entity.Validation;    

    public class DataImporter
    {
        public static void Main()
        {
            var db = new CarsDbContext();

            // Task 06. JSON Data Import
            ImportJsonData(db);

            // Task 07. Queries - unfinished
            // Search(db);
        }

        public static void ImportJsonData(CarsDbContext db)
        {            
            db.Configuration.AutoDetectChangesEnabled = false;

            for (int i = 0; i < 5; i++)
            {
                var fileName = string.Format("data.{0}.json", i);

                // Read the file as one string. 
                string jsonCars = File.ReadAllText(@"..\..\..\Data.Json.Files\" + fileName);

                ImportJsonCars(db, jsonCars);
            }

            db.Configuration.AutoDetectChangesEnabled = true;
        }

        public static void ImportJsonCars(CarsDbContext db, string jsonCars)
        {
            var cars = JsonConvert.DeserializeObject<IEnumerable<Car>>(jsonCars);

            Console.WriteLine("Cars import started");

            var counter = 0;
            foreach (var car in cars)
            {
                counter++;

                // Reuse cities and manufacturers if they exist
                car.Manufacturer = GetManufacturer(db, car.ManufacturerName);
                car.Dealer.Cities.Add(GetCity(db, car.Dealer.City));

                db.Cars.Add(car);

                // http://stackoverflow.com/questions/5400530/validation-failed-for-one-or-more-entities-while-saving-changes-to-sql-server-da
                try
                {
                    // save immediately to ensure cities and manufacturers uniqueness
                    db.SaveChanges();

                    if (counter % 100 == 0)
                    {
                        Console.Write(".");
                    }
                }
                catch (DbEntityValidationException validationException)
                {
                    foreach (var validationErrors in validationException.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }

            Console.WriteLine("\nCars import finished");
        }

        public static Manufacturer GetManufacturer(CarsDbContext db, string name)
        {
            var manufacturer = db.Manufacturers.FirstOrDefault(m => m.Name == name);

            if (manufacturer == null)
            {
                manufacturer = new Manufacturer
                {
                    Name = name
                };
            }

            return manufacturer;
        }

        public static City GetCity(CarsDbContext db, string name)
        {
            var city = db.Cities.FirstOrDefault(c => c.Name == name);

            if (city == null)
            {
                city = new City
                {
                    Name = name
                };
            }

            return city;
        }

        public static void Search(CarsDbContext db)
        {
            var searchColumns = new Dictionary<string, string>();
            searchColumns.Add("Id", "c.Id");
            searchColumns.Add("Year", "c.Year");
            searchColumns.Add("Price", "c.Price");
            searchColumns.Add("Model", "c.Model");
            searchColumns.Add("Manufacturer", "m.Name");
            searchColumns.Add("Dealer", "d.Name");
            searchColumns.Add("City", "ct.Name");

            var conditions = new Dictionary<string, string>();
            conditions.Add("Equals", "=");
            conditions.Add("GreaterThan", ">");
            conditions.Add("LessThan", "<");
            conditions.Add("Contains", "LIKE");

            var xmlQueries = XElement.Load(@"..\..\..\Queries.xml").Elements();

            foreach (var xmlQuery in xmlQueries)
            {
                var carsQuery = db.Cars.AsQueryable();

                var whereConditions = new List<Dictionary<string, string>>();
                foreach (var xmlWhere in xmlQuery.Element("WhereClauses").Elements("WhereClause"))
                {
                    var where = new Dictionary<string, string>();
                    where.Add("PropertyName", xmlWhere.Attribute("PropertyName").Value);
                    where.Add("Condition", xmlWhere.Attribute("Type").Value);
                    where.Add("PropertyValue", xmlWhere.Value);

                    whereConditions.Add(where);
                }

                var orderBy = xmlQuery.Element("OrderBy").Value;
            }      
        }
    }
}
