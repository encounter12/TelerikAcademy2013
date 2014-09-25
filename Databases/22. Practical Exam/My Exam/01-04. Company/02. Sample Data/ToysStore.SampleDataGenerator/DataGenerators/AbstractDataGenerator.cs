namespace ToysStore.SampleDataGenerator.DataGenerators
{
    using ToysStore.Data;
    using ToysStore.SampleDataGenerator.RandomDataGenerators;

    public abstract class AbstractDataGenerator : IDataGenerator
    {
        protected ToysStoreDbContext DbContext { get; set; }

        public RandomDataGenerator RandomDataGenerator { get; set; }

        public AbstractDataGenerator(ToysStoreDbContext dbContext, RandomDataGenerator randomDataGenerator)
        {
            this.DbContext = dbContext;
            this.RandomDataGenerator = randomDataGenerator;            
        }

        public abstract void Generate(int numberOfRecords);
    }
}
