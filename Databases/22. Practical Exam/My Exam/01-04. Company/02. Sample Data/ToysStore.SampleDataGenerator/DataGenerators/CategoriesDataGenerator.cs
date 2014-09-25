namespace ToysStore.SampleDataGenerator.DataGenerators
{
    using System;
    using System.Text;

    using ToysStore.Data;
    using ToysStore.SampleDataGenerator.RandomDataGenerators;

    internal class CategoriesDataGenerator : AbstractDataGenerator
    {
        internal CategoriesDataGenerator(ToysStoreDbContext dbContext, RandomDataGenerator randomDataGenerator) :
            base(dbContext, randomDataGenerator)
        {

        }

        public override void Generate(int recordsNumber)
        {
            Console.WriteLine("Importing categories");

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < recordsNumber; i++)
            {
                stringBuilder.Clear();
                stringBuilder.Append(this.RandomDataGenerator.GetString(5, 10));
                stringBuilder.Append(i);

                var category = new Category();
                category.Name = stringBuilder.ToString();

                this.DbContext.Categories.Add(category);

                if (i % 100 == 0)
                {
                    this.DbContext.SaveChanges();
                    Console.Write(".");
                }
            }

            this.DbContext.SaveChanges();

            Console.WriteLine("\nCategories imported");
        }
    }
}