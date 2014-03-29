using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisonByFiveSet
{
    class DivisonByFiveSet
    {
        static void Main()
        {
            /*This program reads two positive integer numbers and prints how many numbers p exist 
             * between them such that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2*/


            //Defines and initializes the variables a and b (the range limits)
            Console.WriteLine("Enter first integer:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second integer:");
            int b = int.Parse(Console.ReadLine());

            //Calculates the number of integers in the range that could be divided by 5 without remainder
            int x = Math.Abs(b - a) / 5;

            if ((a % 5 == 0) || (b % 5 == 0))
            {
                x += 1;
            }

            //Prints the number of integers
            Console.WriteLine("Result: {0}", x);

        }
    }
}
