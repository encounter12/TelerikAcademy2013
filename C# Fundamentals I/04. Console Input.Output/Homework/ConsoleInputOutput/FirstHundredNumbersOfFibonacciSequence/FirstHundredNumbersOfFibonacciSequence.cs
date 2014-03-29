using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FirstHundredNumbersOfFibonacciSequence
{
    class FirstHundredNumbersOfFibonacciSequence
    {
        static void Main()
        {
            BigInteger nMinusTwo = 0;
            BigInteger nMinusOne = 1;
            BigInteger n = 0;
            int m = 100;
            Console.WriteLine("This program prints the first 100 terms of the Fibonacci sequence");
            Console.Write("Press any key to see the numbers...");
            Console.ReadLine();

            Console.WriteLine("{0}\n{1}", nMinusTwo, nMinusOne);

            for (int i = 2; i < m; i++)
            {
                n = nMinusOne + nMinusTwo;
                Console.WriteLine("{0}", n);

                nMinusTwo = nMinusOne;
                nMinusOne = n;

            }
            Console.WriteLine();
        }
    }
}
