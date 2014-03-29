using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CalculateNthCatalanNumber
{
    class CalculateNthCatalanNumber
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 90;

            /*In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:
             * Cn = 2n!/(n+1)!*n! for n >= 0;
             * This program calculates the Nth Catalan number by given N.
             */

            ulong n;
            do
            {
                Console.WriteLine("Please enter integer n (n >= 0):");
            } while (!ulong.TryParse(Console.ReadLine(), out n));

            BigInteger nthCatalanNumber;

            /*Mathematical rationalization: 
             * Cn = 2n!/(n+1)!*n! =  (n+2)*(n+3)*...*2n/n!
             */
           

            //(n+2)*(n+3)*...*2n
            BigInteger NPlusTwoToDoubleN = 1u;
            for (ulong i = n+2; i <= 2*n; i++)
            {
                NPlusTwoToDoubleN *= i;
            }

            //n!
            BigInteger NFactorial = 1u;
            for (ulong i = 1; i <= n; i++)
            {
                NFactorial *= i;
            }

            nthCatalanNumber = NPlusTwoToDoubleN / NFactorial;

            Console.WriteLine("The {0} Catalan number is: Cn = 2n!/(n+1)!*n! = C{0} = (2*{0})!/({0}+1)!*{0}! = {1}", n, nthCatalanNumber);
        }
    }
}
