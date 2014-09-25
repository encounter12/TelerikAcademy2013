namespace ToysStore.SampleDataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ToysStore.Data;
    using ToysStore.SampleDataGenerator.RandomDataGenerators;

    internal class ToysDataGenerator : AbstractDataGenerator
    {
        internal ToysDataGenerator(ToysStoreDbContext dbContext, RandomDataGenerator randomDataGenerator) :
            base(dbContext, randomDataGenerator)
        {

        }

        public override void Generate(int recordsNumber)
        {
            Console.WriteLine("Importing toys");

            var manufacturersIds = this.DbContext.Manufacturers.Select(manufacturer => manufacturer.Id).ToList();
            var ageRangesIds = this.DbContext.AgeRanges.Select(ageRange => ageRange.Id).ToList();
            var categoriesIds = this.DbContext.Categories.Select(category => category.Id).ToList();

            for (int i = 0; i < recordsNumber; i++)
            {
                var toy = new Toy();
                toy.Name = this.RandomDataGenerator.GetString(5, 20);
                toy.Type = this.RandomDataGenerator.GetString(5, 20);
                toy.Color = this.RandomDataGenerator.GetString(5, 20);
                toy.Price = (decimal)(this.RandomDataGenerator.GetInt(5, 200) + this.RandomDataGenerator.GetDouble());

                // Add manufacturer
                var manufacturerIndex = this.RandomDataGenerator.GetInt(0, manufacturersIds.Count - 1);
                toy.ManufacturerId = manufacturersIds.ElementAt(manufacturerIndex);

                // Add age range
                var ageRangeIndex = this.RandomDataGenerator.GetInt(0, manufacturersIds.Count - 1);
                toy.AgeRangeId = ageRangesIds.ElementAt(ageRangeIndex);

                // Add categories
                var numberOfCategories = this.RandomDataGenerator.GetInt(1, 5);
                var toyCategoriesIds = new HashSet<int>();

                while (toyCategoriesIds.Count != numberOfCategories)
                {
                    var categoryIndex = this.RandomDataGenerator.GetInt(0, categoriesIds.Count - 1);
                    toyCategoriesIds.Add(categoryIndex);
                }

                foreach (var toyCategoryId in toyCategoriesIds)
                {
                    toy.Categories.Add(this.DbContext.Categories.Find(toyCategoryId));
                }
                
                // Save toy
                this.DbContext.Toys.Add(toy);

                if (i % 100 == 0)
                {
                    this.DbContext.SaveChanges();
                    Console.Write(".");
                }
            }

            this.DbContext.SaveChanges();

            Console.WriteLine("\nToys imported");
        }
    }
}