using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumContiguousFixedSubsequenceV2
{
    class MaxSumContiguousSubsequenceKV2
    {
        static int MaxSumContiguousFixedSubsequence(int[] numbers, int k, out int maxSumStartIndex)
        {
            int currentSum = 0;
            maxSumStartIndex = 0;

            for (int i = 0; i < k; i++)
            {
                currentSum += numbers[i];
            }
            int maxSum = currentSum;

            for (int i = 1; i <= numbers.Length - k; i++)
            {
                currentSum = currentSum - numbers[i - 1] + numbers[i + k - 1];                 
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxSumStartIndex = i;
                }
                currentSum = 0;
            }

            return maxSum;
        }
        static void Main()
        {
            /* Problem: Write a program that reads two integer numbers N and K and an array of N elements from the console. 
            * Find in the array those K elements that have maximal sum.
            * Additional info: Тhis problem is known as: "K-Maximum Subarray Problem" / "k maximum-sums problems"
            */

            Console.WriteLine("Enter the array elements number N:");
            int arrayLengthN = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter positive integer K (K<N):");
            int sequenceLengthK = int.Parse(Console.ReadLine());

            int[] numbers = new int[arrayLengthN];

            Console.WriteLine("Enter the array numbers:");
            for (int i = 0; i < arrayLengthN; i++)
            {
                Console.Write("numbers[{0}] = ", i);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int maxSumStartIndex;
            int maxSum = MaxSumContiguousFixedSubsequence(numbers, sequenceLengthK, out maxSumStartIndex);

            Console.WriteLine("The first Maximum Sum Contiguous Subsequence consisting of K elements is:");
            Console.Write("{");
            for (int i = maxSumStartIndex; i < maxSumStartIndex + sequenceLengthK; i++)
            {
                Console.Write(numbers[i]);
                if (i < maxSumStartIndex + sequenceLengthK - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("}} = {0}", maxSum);
            Console.WriteLine();
        }
    }
}
