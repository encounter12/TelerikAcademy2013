namespace ToysStore.SampleDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ToysStore.Data;
    using ToysStore.Models;

    internal class ManufacturerDataGenerator: DataGenerator, IDataGenerator
    {
        private readonly ILogger consoleLogger;

        public ManufacturerDataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toyStoreEntities, int countOfGeneratedObjects)
            : base(randomDataGenerator, toyStoreEntities, countOfGeneratedObjects)
        {
            this.consoleLogger = new ConsoleLogger();
        }

        public override void Generate()
        {
            var manufacturersToBeAdded = new HashSet<string>();
            while (manufacturersToBeAdded.Count != this.Count)
            {
                manufacturersToBeAdded.Add(this.Random.GetRandomStringWithRandomLength(5, 20));
            }

            int index = 0;

            consoleLogger.LogMessage("Adding manufacturers");
            foreach (var manufacturerName in manufacturersToBeAdded)
            {
                var manufacturer = new Manufacturer
                {
                    Name = manufacturerName,
                    Country = this.Random.GetRandomStringWithRandomLength(2, 20)
                };

                this.Database.Manufacturers.Add(manufacturer);

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                index++;
            }

            Console.WriteLine("\nManufacturers added");
        }
    }
}
