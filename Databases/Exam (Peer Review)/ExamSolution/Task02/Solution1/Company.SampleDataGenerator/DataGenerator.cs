using System;
using System.Linq;
using Company.Data;

namespace Company.SampleDataGenerator
{
    internal abstract class DataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private Company20140908Entities db;
        private int count;

        public DataGenerator(IRandomDataGenerator randomDataGenerator, Company20140908Entities company20140908Entities, int countOfGeneratedObjects)
        {
            this.random = randomDataGenerator;
            this.db = company20140908Entities;
            this.count = countOfGeneratedObjects;
        }

        protected IRandomDataGenerator Random
        {
            get { return this.random; }
        }

        protected Company20140908Entities Database
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
