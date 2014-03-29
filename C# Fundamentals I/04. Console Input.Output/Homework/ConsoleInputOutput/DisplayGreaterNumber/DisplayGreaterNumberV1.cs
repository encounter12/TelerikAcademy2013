using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayGreaterNumberV1
{
    class DisplayGreaterNumberV1
    {
        static void Main()
        {
            Console.WriteLine("This program reads two numbers from the console and displays the greater of them");
            Console.WriteLine("Enter the first number:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number:");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("The bigger number is: {0}", Math.Max(a,b));

        }
    }
}
