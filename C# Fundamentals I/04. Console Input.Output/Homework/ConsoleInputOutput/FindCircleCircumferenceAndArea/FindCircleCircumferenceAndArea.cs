using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCircleCircumferenceAndArea
{
    class FindCircleCircumferenceAndArea
    {
        static void Main()
        {
            Console.WriteLine("FIND CIRCLE'S CIRCUMFERENCE AND AREA");
            Console.WriteLine("This program reads circle's radius r and prints its circumference C and Area");

            bool userInputCorrect = false;
            double r = 0d;            
            do
            {
                Console.Write("Please enter the circle radius R = ");
                userInputCorrect = (double.TryParse(Console.ReadLine(), out r)) && (r>=0);
                if (!userInputCorrect)
                {
                    Console.WriteLine("You have entered incorrect type. Please, re-enter.");
                    Console.ReadLine();
                }

            } while (!userInputCorrect);

            double circumference = Math.PI * 2 * r;
            double area = Math.PI * Math.Pow(r, 2);

            Console.WriteLine("Circumference = Pi * 2 * R = {0}", circumference);
            Console.WriteLine("Area = Pi * R^2 = {0}", area);
        }
    }
}
