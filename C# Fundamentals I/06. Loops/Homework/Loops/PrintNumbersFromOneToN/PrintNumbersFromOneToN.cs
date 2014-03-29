using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    class PrintNumbersFromOneToN
    {
        static void PrintOneToN(uint upperLimitN)
        {
            for (int i = 1; i <= upperLimitN; i++)
            {
                Console.Write(i + " ");
            }
        }

        static void Main()
        {
            //This program prints all the positive integers from 1 to N;

            uint upperLimitN = 0;
            bool userInputCorrect = false;

            do
            {
                Console.WriteLine("Enter number N:");
                userInputCorrect = uint.TryParse(Console.ReadLine(), out upperLimitN);
                if (!userInputCorrect)
                {
                    Console.WriteLine("You have entered incorrect number. Press any key to re-enter...");
                    Console.ReadKey();
                }
            } while (!userInputCorrect);

            Console.WriteLine("The positive integer numbers from 1 to N are:");

            PrintOneToN(upperLimitN);

            Console.WriteLine();
        }
    }
}
