using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesWithSpecifiedAccuracy
{
    class SeriesWithSpecifiedAccuracy
    {
        static void Main()
        {
            Console.WindowWidth = 90;
            Console.WriteLine("This program calculates the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...");
            double sum = 1;
            double previousSum;
            uint counter = 1;
            do
            {
                counter++;
                previousSum = sum;
                sum += Math.Pow(-1, counter) / counter;
            
            } while ((sum - previousSum) >= 0.001);

            Console.WriteLine("Sum = {0}, n = {1}", sum, counter);
        }
    }
}
