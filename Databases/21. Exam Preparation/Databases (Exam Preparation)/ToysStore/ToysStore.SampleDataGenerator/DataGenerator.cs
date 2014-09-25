namespace ToysStore.SampleDataGenerator
{
    using System;
    using System.Linq;

    using ToysStore.Data;

    internal abstract class DataGenerator: IDataGenerator
    {
        private IRandomDataGenerator random;
        private ToysStoreEntities db;
        private int count;

        public DataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toyStoreEntities, int countOfGeneratedObjects)
        {
            this.random = randomDataGenerator;
            this.db = toyStoreEntities;
            this.count = countOfGeneratedObjects;
        }

        protected IRandomDataGenerator Random
        {
            get { return this.random; }
        }

        protected ToysStoreEntities Database
        {
            get { return this.db; }
        }

        protected int Count
        {
            get { return this.count; }
        }

        public abstract void Generate();
    }
}
