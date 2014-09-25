using System;
using System.Linq;
using Company.Data;

namespace Company.SampleDataGenerator
{
    class ProjectDataGenerator : DataGenerator, IDataGenerator
    {
        public ProjectDataGenerator(IRandomDataGenerator randomDataGenerator, Company20140908Entities company20140908Entities, int countOfGeneratedObjects)
            : base(randomDataGenerator, company20140908Entities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            var projectIds = this.Database.Projects.Select(p => p.Id).ToList();
            
            Console.WriteLine("Adding projects");
            
            for (int i = 0; i < this.Count; i++)
            {
                var project = new Project
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 50),
                    Id = projectIds[this.Random.GetRandomNumber(0, projectIds.Count - 1)]
                };

                this.Database.Projects.Add(project);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nProjectss added");
        }

    }
}
