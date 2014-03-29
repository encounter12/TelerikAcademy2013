using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NFactorialTrailingZeros
{
    class NFactorialTrailingZeros
    {
        static BigInteger CalculateNFactorial(uint n)
        {
            BigInteger nFactorial = 1;
            for (int i = 1; i <= n; i++)
            {
                nFactorial *= i;
            }
            return nFactorial;
        }

        static uint FactorialTrailingZeros(uint n)
        {
            //http://en.wikipedia.org/wiki/Trailing_zero

            //Find k value, it should satisify the inequality: 5^k > n >= 5^(k-1);
            int exponentK = 0;            
            while (Math.Pow(5, exponentK) <= n)
            {
                exponentK++;
            }

            exponentK--;

            uint trailingZeros = 0;

            //f(n) = sum(from i=1 to k) [n/5^i];
            for (int i = 1; i <= exponentK; i++)
            {
                trailingZeros += n / (uint)Math.Pow(5, i);
            }

            return trailingZeros;
        }
        

        static void Main()
        {
            uint n;
            do
            {
                Console.WriteLine("Please enter non-negative integer N:");
            } while (!uint.TryParse(Console.ReadLine(), out n));

            /*BigInteger nFactorial = CalculateNFactorial(n);
            Console.WriteLine("{0}! = {1}", n, nFactorial);*/

            Console.WriteLine("{0}! has {1} trailing zeros", n, FactorialTrailingZeros(n));

        }
    }
}
