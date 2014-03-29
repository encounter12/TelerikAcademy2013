using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FibonacciSequencePartialSum
{
    class FibonacciSequencePartialSum
    {
        static void Main(string[] args)
        {
            ulong n = 0; //n - nth term
            do
            {
                Console.WriteLine("Please enter positive integer N (N > 2):");
            } while (!ulong.TryParse(Console.ReadLine(), out n) || n <= 2);

            ulong[] fibonacciSequence = new ulong[n];
            fibonacciSequence[0] = 0;
            fibonacciSequence[1] = 1;
            ulong partialSum = 1;

            for (ulong i = 2; i < n; i++)
            {
                fibonacciSequence[i] = fibonacciSequence[i-1] + fibonacciSequence[i-2];
                partialSum += fibonacciSequence[i];
            }

            Console.WriteLine("The Fibonacci Sequence Partial Sum is S = {0}", partialSum);
            
        }
    }
}
