using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FactorialPartialSum
{
    class FactorialPartialSum
    {
        static void Main(string[] args)
        {
            /*Partial Sum involving factorials:
              S = 1 + 1!/X + 2!/X^2 + … + N!/X^N
             */

            double N = 1;  
            double X = 1;
            double XPowerOfN = 1;
            double NFactorial = 1;
           
            double sum = 1;
                                 
            do
            {
                Console.WriteLine("Please, enter a positive integer number N: ");

            } while (!double.TryParse(Console.ReadLine(), out N) || N == 0);
            do
            {
                Console.WriteLine("Please, enter a positive integer number X: ");

            } while (!double.TryParse(Console.ReadLine(), out X) || X == 0);

            for (uint i = 1; i <= N; i++)
            {

                NFactorial *=  i;
                XPowerOfN *= X;
                sum += NFactorial / XPowerOfN;
            }

            Console.WriteLine("S={0}", sum);
        }
    }
}
