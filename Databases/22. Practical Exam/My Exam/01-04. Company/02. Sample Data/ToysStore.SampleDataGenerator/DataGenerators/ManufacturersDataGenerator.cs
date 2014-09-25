namespace ToysStore.SampleDataGenerator.DataGenerators
{
    using System;
    using System.Text;

    using ToysStore.Data;
    using ToysStore.SampleDataGenerator.RandomDataGenerators;

    internal class ManufacturersDataGenerator : AbstractDataGenerator
    {
        internal ManufacturersDataGenerator(ToysStoreDbContext dbContext, RandomDataGenerator randomDataGenerator) :
            base(dbContext, randomDataGenerator)
        {

        }

        public override void Generate(int recordsNumber)
        {
            Console.WriteLine("Importing manufacturers");

            var stringBuilder = new StringBuilder();
            
            for (int i = 0; i < recordsNumber; i++)
            {
                stringBuilder.Clear();
                stringBuilder.Append(this.RandomDataGenerator.GetString(5, 20));
                stringBuilder.Append(i);

                var manufacturer = new Manufacturer();
                manufacturer.Name = stringBuilder.ToString();
                manufacturer.Country = this.RandomDataGenerator.GetString(3, 20);

                this.DbContext.Manufacturers.Add(manufacturer);

                if (i % 100 == 0)
                {
                    this.DbContext.SaveChanges();
                    Console.Write(".");
                }
            }

            this.DbContext.SaveChanges();

            Console.WriteLine("\nManufacturers imported");
        }
    }
}