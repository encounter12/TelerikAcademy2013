using System;
using System.Linq;

namespace Company.SampleDataGenerator
{
    internal class RandomDataGenerator : IRandomDataGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmonpqrstuvwxyz";

        private static IRandomDataGenerator randomDataGenerator;
        private Random random;

        private RandomDataGenerator()
        {
            this.random = new Random();
        }

        public static IRandomDataGenerator Instance
        {
            get
            {
                if (randomDataGenerator == null)
                {
                    randomDataGenerator = new RandomDataGenerator();
                }

                return randomDataGenerator;
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            //var result = new StringBuilder(length); // slower
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = Letters[this.GetRandomNumber(0, Letters.Length - 1)];
            }

            //return result.ToString(); // slower
            return new string(result);
        }

        public string GetRandomStringWithRandomLength(int min, int max)
        {
            return this.GetRandomString(this.GetRandomNumber(min, max));
        }
    }
}
