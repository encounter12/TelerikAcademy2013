using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NFactorialDividedByKFactorial
{
    class NFactorialDividedByKFactorial
    {
        static void Main()
        {
            bool userInputCorrect = false;
            uint N = 0;
            uint K = 0;
            do
            {
                Console.WriteLine("Please enter positive integer number N (> 2):");
                userInputCorrect = uint.TryParse(Console.ReadLine(), out N);

                Console.WriteLine("Please enter positive integer number K (1 < K < N):");
                userInputCorrect = uint.TryParse(Console.ReadLine(), out K);
                if ((N <= 2 || K <= 1 || K >= N) || !userInputCorrect)
                {
                    userInputCorrect = false;
                    Console.WriteLine("You have entered incorrect parameters. Press any key to re-enter...");
                    Console.ReadKey();
                }               

            } while (!userInputCorrect);

            // Mathematical rationalization - the quotient is: N! / K! = (K+1)*(K+2)*...*N;

            BigInteger quotient = 1;
            for (uint i = K + 1; i <= N; i++)
            {
                quotient*= i;
            }

            Console.WriteLine("N!/K! = {0}!/{1}! = {2}", N, K, quotient);
        }
    }
}
