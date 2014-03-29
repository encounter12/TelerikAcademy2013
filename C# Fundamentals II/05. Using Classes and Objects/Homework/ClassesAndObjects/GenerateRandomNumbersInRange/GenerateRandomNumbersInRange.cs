using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateRandomNumbersInRange
{
    class GenerateRandomNumbersInRange
    {
        /**
         * Write a program that generates and prints to the console 10 random values in the range [100, 200].
         */

        protected static Random generator = new Random();
        
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(RandomNumber());
            }
        }

        public static int RandomNumber()
        {
            return generator.Next(100, 201);
        }
    }
}
