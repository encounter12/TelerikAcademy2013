namespace ToysStore.SampleDataGenerator.DataGenerators
{
    using System;

    using ToysStore.Data;
    using ToysStore.SampleDataGenerator.RandomDataGenerators;

    internal class AgeRangesDataGenerator : AbstractDataGenerator
    {
        internal AgeRangesDataGenerator(ToysStoreDbContext dbContext, RandomDataGenerator randomDataGenerator) :
            base(dbContext, randomDataGenerator)
        {

        }

        public override void Generate(int recordsNumber)
        {
            Console.WriteLine("Importing age ranges");

            for (int i = 0; i < recordsNumber; i++)
            {
                var ageRange = new AgeRanx();
                ageRange.MinAge = (short)i;
                ageRange.MaxAge = (short)(i + 2);

                this.DbContext.AgeRanges.Add(ageRange);

                if (i % 100 == 0)
                {
                    this.DbContext.SaveChanges();
                    Console.Write(".");
                }
            }

            this.DbContext.SaveChanges();

            Console.WriteLine("\nAge ranges imported");
        }
    }
}