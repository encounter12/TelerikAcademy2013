namespace ToysStore.SampleDataGenerator.DataGenerators
{
    using ToysStore.SampleDataGenerator.RandomDataGenerators;

    public interface IDataGenerator
    {
        RandomDataGenerator RandomDataGenerator { get; set; }

        void Generate(int numberOfRecords);
    }
}
