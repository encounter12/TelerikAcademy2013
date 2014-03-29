using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print1ToNNotDivisibleBy3And7
{
    class Print1ToNNotDivisibleBy3And7
    {
        static void PrintOneToNNotDivisibleBy3And7(uint upperLimitN)
        {
            for (uint i = 1; i <= upperLimitN; i++)
            {
                if (i%21 != 0)
                {
                    Console.Write(i + " ");
                }                
            }
        }
        static void Main()
        {
            //This program prints all the positive integers from 1 to N that are not divisible by 3 and 7;

            uint upperLimitN = 0;
            bool userInputCorrect = false;

            do
            {
                Console.WriteLine("Enter positive integer number N:");
                userInputCorrect = uint.TryParse(Console.ReadLine(), out upperLimitN);
                if (!userInputCorrect)
                {
                    Console.WriteLine("You have entered incorrect number. Press any key to re-enter...");
                    Console.ReadKey();
                }
            } while (!userInputCorrect);

            Console.WriteLine("The positive integer numbers from 1 to N that are not divisible by 3 and 7 are:");

            PrintOneToNNotDivisibleBy3And7(upperLimitN);

            Console.WriteLine();
        }
    }
}
