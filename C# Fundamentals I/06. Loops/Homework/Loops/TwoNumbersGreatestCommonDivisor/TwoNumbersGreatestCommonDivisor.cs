using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoNumbersGreatestCommonDivisor
{
    class TwoNumbersGreatestCommonDivisor
    {
        static int GreatestCommonDivisor(int numberOne, int numberTwo)
        {
            int remainder;
            while (numberTwo != 0)
            {
                remainder = numberOne % numberTwo;
                numberOne = numberTwo;
                numberTwo = remainder;
            }
            return numberOne;
        }
        static void Main(string[] args)
        {
            /*This program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm*/
 
            int numberOne = 0;
            int numberTwo = 0;
            do
            {
                Console.WriteLine("Enter integer number 1:");
            } while (!int.TryParse(Console.ReadLine(), out numberOne));
            do
            {
                Console.WriteLine("Enter integer number 2:");
            } while (!int.TryParse(Console.ReadLine(), out numberTwo));
                           
            Console.WriteLine("The greatest common divisor of {0} and {1} is: {2}", numberOne, numberTwo, GreatestCommonDivisor(numberOne, numberTwo));
        }
    }
}
