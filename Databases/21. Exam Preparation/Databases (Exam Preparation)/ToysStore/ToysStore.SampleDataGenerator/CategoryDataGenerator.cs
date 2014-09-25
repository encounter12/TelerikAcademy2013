namespace ToysStore.SampleDataGenerator
{
    using System;
    using System.Linq;

    using ToysStore.Data;
    using ToysStore.Models;
    
    internal class CategoryDataGenerator: DataGenerator, IDataGenerator
    {
        private readonly ILogger consoleLogger;

        public CategoryDataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toyStoreEntities, int countOfGeneratedObjects)
            : base(randomDataGenerator, toyStoreEntities, countOfGeneratedObjects)
        {
            this.consoleLogger = new ConsoleLogger();
        }

        public override void Generate()
        {
            consoleLogger.LogMessage("Adding categories");
            for (int i = 0; i < this.Count; i++)
            {
                var category = new Category
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 20)
                };
                this.Database.Categories.Add(category);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nCategories added");
        }
    }
}
