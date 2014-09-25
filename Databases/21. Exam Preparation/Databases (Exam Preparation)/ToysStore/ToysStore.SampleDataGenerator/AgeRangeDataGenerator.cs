namespace ToysStore.SampleDataGenerator
{
    using System;
    using System.Linq;
    using ToysStore.Data;
    using ToysStore.Models;

    internal class AgeRangeDataGenerator: DataGenerator, IDataGenerator
    {
        private readonly ILogger consoleLogger;

        public AgeRangeDataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toyStoreEntities, int countOfGeneratedObjects)
            : base(randomDataGenerator, toyStoreEntities, countOfGeneratedObjects)
        {
            this.consoleLogger = new ConsoleLogger();
        }

        public override void Generate()
        {
            consoleLogger.LogMessage("Adding age ranges");
            int count = 0;
            for (int i = 0; i < this.Count / 5; i++)
            {
                for (int j = i + 1; j < i + 5; j++)
                {
                    var ageRange = new AgeRange()
                    {
                        MinimumAge = i,
                        MaximumAge = j
                    };

                    this.Database.AgeRanges.Add(ageRange);
                    count++;

                    if (count % 100 == 0)
                    {
                        this.Database.SaveChanges();
                    }

                    if (count == this.Count)
                    {
                        consoleLogger.LogMessage("Age ranges added");
                        return;
                    }
                    count++;
                }
            }
        }
    }
}
