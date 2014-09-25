namespace ToysStore.SampleDataGenerator
{
    using ToysStore.Data;
    using RandomDataGenerators;
    using DataGenerators;

    internal class Generator
    {
        private static void Main()
        {
            ToysStoreDbContext dbContext = new ToysStoreDbContext();
            RandomDataGenerator randomDataGenerator = RandomDataGenerator.Instance;

            dbContext.Configuration.AutoDetectChangesEnabled = false;

            // Generate manufacturers
            IDataGenerator manufacturersDataGenerator = new ManufacturersDataGenerator(dbContext, randomDataGenerator);
            manufacturersDataGenerator.Generate(50);

            // Generate categories
            IDataGenerator categoriesDataGenerator = new CategoriesDataGenerator(dbContext, randomDataGenerator);
            categoriesDataGenerator.Generate(100);

            // Generate age ranges
            IDataGenerator ageRangesDataGenerator = new AgeRangesDataGenerator(dbContext, randomDataGenerator);
            ageRangesDataGenerator.Generate(100);
            
            // Generate toys
            IDataGenerator toysDataGenerator = new ToysDataGenerator(dbContext, randomDataGenerator);
            toysDataGenerator.Generate(20000);

            dbContext.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
