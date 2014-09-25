namespace ToysStore.SampleDataGenerator.RandomDataGenerators
{
    using System;

    public class RandomDataGenerator
    {
        public const string AllAlphaNumeric = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        public const string SmallLetters = "abcdefghijklmnopqrstuvwxyz";

        public const string BigLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public const string Numerics = "1234567890";

        public const string AllLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static RandomDataGenerator instance;

        private readonly Random random;

        private RandomDataGenerator()
        {
            this.random = new Random();
        }

        public static RandomDataGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RandomDataGenerator();
                }

                return instance;
            }
        }

        public string GetStringExact(int length, string charsToUse = AllLetters)
        {
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = charsToUse[this.random.Next(0, charsToUse.Length)];
            }

            return new string(result);
        }

        public string GetString(int min, int max, string charsToUse = AllLetters)
        {
            return this.GetStringExact(this.random.Next(min, max + 1), charsToUse);
        }

        public int GetInt(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public double GetDouble()
        {
            return this.random.NextDouble();
        }

        public bool GetChance(int percent)
        {
            return this.random.Next(0, 101) <= percent;
        }
    }
}