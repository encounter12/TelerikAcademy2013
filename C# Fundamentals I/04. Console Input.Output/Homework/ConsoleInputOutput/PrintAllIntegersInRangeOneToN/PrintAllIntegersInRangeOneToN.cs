using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintAllIntegersInRangeOneToN
{
    class PrintAllIntegersInRangeOneToN
    {
        static void Main()
        {
            Console.WriteLine("Type the integer n:");
            int n = int.Parse(Console.ReadLine()); /*Validation not implemented*/

            Console.WriteLine("All the numbers in the range (1,{0}) are:", n);
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}", i);
            }
        }
    }
}
