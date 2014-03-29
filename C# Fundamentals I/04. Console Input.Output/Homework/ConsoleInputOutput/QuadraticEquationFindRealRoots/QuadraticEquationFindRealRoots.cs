using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquationFindRealRoots
{
    class QuadraticEquationFindRealRoots
    {
        static void Main()
        {
            Console.WriteLine("This program reads the coefficients of quadratic equation: " + 
                "a(x)^2 + bx + c = 0 and prints its real roots (if any)");
            Console.WriteLine("Enter quadratic coefficient a:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter linear coefficient b:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter constant term c:");
            double c = double.Parse(Console.ReadLine());

            double D = Math.Pow(b, 2) - 4 * a * c;
            double x1 = 0;
            double x2 = 0;
            double x = 0;

            if (D>0)
            {
                x1 = (- b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
                x2 = (- b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);

                Console.WriteLine("The real roots are: x1 = {0}, x2 = {1}", x1, x2);
            }
            else if (D == 0)
            {
                x = -b / (2 * a);
                Console.WriteLine("The only real root is: {0}", x);
            }
            else
            {
                Console.WriteLine("The equation has no real roots");
            }
           
        }
    }
}
