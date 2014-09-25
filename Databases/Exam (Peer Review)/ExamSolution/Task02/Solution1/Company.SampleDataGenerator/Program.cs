using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data;

namespace Company.SampleDataGenerator
{
    class Program
    {
        private static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var db = new Company20140908Entities();

            // this accelerates the addition of new entries to empty tables <= EF does not check for changes!
            //db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>
            {
                new DepartmentDataGenerator(random, db, 100),
                new ReportDataGenerator(random, db, 250000),
                new ProjectDataGenerator(random, db, 1000),
                new EmployeeDataGenerator(random, db, 5000)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }

            //db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
