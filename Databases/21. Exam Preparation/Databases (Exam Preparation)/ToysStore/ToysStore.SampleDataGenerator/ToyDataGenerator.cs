namespace ToysStore.SampleDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ToysStore.Data;
    using ToysStore.Models;

    internal class ToyDataGenerator: DataGenerator, IDataGenerator
    {
        private readonly ILogger consoleLogger;

        public ToyDataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toyStoreEntities, int countOfGeneratedObjects)
            : base(randomDataGenerator, toyStoreEntities, countOfGeneratedObjects)
        {
            this.consoleLogger = new ConsoleLogger();
        }

        public override void Generate()
        {
            consoleLogger.LogMessage("Adding toys");
            var ageRangeIds = this.Database.AgeRanges.Select(a => a.Id).ToList();
            var manufacturerIds = this.Database.Manufacturers.Select(m => m.Id).ToList();
            var categoryIds = this.Database.Categories.Select(c => c.Id).ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var toy = new Toy
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 50),
                    Type = this.Random.GetRandomStringWithRandomLength(5, 50),
                    Price = this.Random.GetRandomNumber(10, 500),
                    Color = this.Random.GetRandomNumber(1, 5) == 5 ? null : this.Random.GetRandomStringWithRandomLength(5, 20),
                    ManufacturerId = manufacturerIds[Random.GetRandomNumber(0, manufacturerIds.Count - 1)],
                    AgeRangeId = ageRangeIds[this.Random.GetRandomNumber(0, ageRangeIds.Count - 1)]
                };

                if (categoryIds.Count > 0)
                {
                    var uniqueCategoryIds = new HashSet<int>();
                    var categoriesInToy = this.Random.GetRandomNumber(1, Math.Min(10, categoryIds.Count));

                    while (uniqueCategoryIds.Count != categoriesInToy)
                    {
                        uniqueCategoryIds.Add(this.Random.GetRandomNumber(0, categoryIds.Count - 1));
                    }

                    foreach (var uniqueCategoryId in uniqueCategoryIds)
                    {
                        toy.Categories.Add(this.Database.Categories.Find(uniqueCategoryId));
                    }
                }

                if (i % 100 == 0)
                {
                    consoleLogger.LogMessage(".");
                    this.Database.SaveChanges();
                }

                this.Database.Toys.Add(toy);
            }

            consoleLogger.LogMessage("Toys added");
        }
    }
}