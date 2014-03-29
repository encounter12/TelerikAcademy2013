using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CalculateFactorialExpression
{
    class CalculateFactorialExpression
    {
        static void Main(string[] args)
        {
            /* Calculate: N!*K! / (K - N)! ; (1 < N < K)
             * Mathematical rationalization:
             * N!*K!/(K - N)! = N!*(К!/(К-N)!)
             * К! /(N-K)! = K*(K-1)*(K-2)* ... *(K-N+1)
             * N!*K!/(K - N)! = N!*(K*(K-1)*(K-2)* ... *(K-N+1))
             * N!*K!/(K - N)! = N!*((K-N+1)*(K-N+2)...*K)
             */

            uint K = 0;
            uint N = 0;            
            BigInteger NFactorial = 1;
            BigInteger NPermutationsOfK = 1; //К!/(N-K)! = K*(K-1)*(K-2)* ... *(K-N+1) = (K-N+1)*(K-N+2)*...*K
            BigInteger result = 0; //N!*K!/(K - N)!

            do
            {
                Console.WriteLine("Please, enter a positive integer number N (N > 1): ");
                
            } while (!uint.TryParse(Console.ReadLine(), out N) || N <= 1);
            do
            {
                Console.WriteLine("Please, enter a positive integer number K (K > N): ");

            } while (!uint.TryParse(Console.ReadLine(), out K) || K <= N);

            //N!
            for (uint i = 1; i <= N; i++)
            {
                NFactorial *= i; 
            }

            //К!/(N-K)! = K*(K-1)*(K-2)* ... *(K-N+1) = (K-N+1)*(K-N+2)*...*K
            for (uint i = K - N + 1; i <= K; i++) 
            {
                NPermutationsOfK *= i;
            }

            result = NFactorial * NPermutationsOfK;
            Console.WriteLine("N!K!/(N-K)! = {0}", result);
        }
    }
}
