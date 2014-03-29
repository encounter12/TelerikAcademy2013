using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayGreaterNumberV3
{
    class DisplayGreaterNumberV3
    {
        static void Main()
        {
            Console.WriteLine("This program reads two integer numbers from the console and displays the greater of them");
            Console.WriteLine("Enter the first number:");

            /*Validation has not been performed*/

            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number:");
            int b = int.Parse(Console.ReadLine());

            //The bigger number is find via bitwise operations
            int max = a - ((a - b) & ((a - b) >> 31));
            Console.WriteLine("The greater number is: {0}", max);
        }
    }
}
