using System;
using System.Linq;
using Company.Data;

namespace Company.SampleDataGenerator
{
    internal class DepartmentDataGenerator : DataGenerator, IDataGenerator
    {
        public DepartmentDataGenerator(IRandomDataGenerator randomDataGenerator, Company20140908Entities company20140908Entities, int countOfGeneratedObjects)
            : base(randomDataGenerator, company20140908Entities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding departments");
            
            for (int i = 0; i < this.Count; i++)
            {
                var department = new Department 
                {
                    Name = this.Random.GetRandomStringWithRandomLength(10, 50)
                };

                this.Database.Departments.Add(department);

                if (i % 50 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nDepartments added");
        }
    }
}
