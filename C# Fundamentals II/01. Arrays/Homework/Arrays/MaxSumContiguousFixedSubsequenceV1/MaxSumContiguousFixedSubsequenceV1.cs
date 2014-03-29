using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumContiguousFixedSubsequenceV1
{
    class MaxSumContiguousFixedSubsequenceV1
    {
        static int MaxSumContiguousFixedSubsequence(int[] numbers, int k, out int maxSumStartIndex)
        {
            int currentSum = 0;
            int maxSum = 0;
            maxSumStartIndex = 0;

            for (int i = 0; i <= numbers.Length - k; i++)
            {
                for (int m = i; m < i + k; m++)
                {
                    currentSum += numbers[m];
                }
                if (i == 0)
                {
                    maxSum = currentSum;
                }
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
             * Additional info: this problem is known as: "K-Maximum Subarray Problem" / "k maximum-sums problems"
             */

            Console.WriteLine("Enter positive integer N:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter positive integer K (K<N):");
            int k = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            Console.WriteLine("Enter the array numbers:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("numbers[{0}] = ", i);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int maxSumStartIndex;
            int maxSum = MaxSumContiguousFixedSubsequence(numbers, k, out maxSumStartIndex);

            Console.WriteLine("The Maximum Sum Contiguous Subsequence consisting of K elements is:");
            Console.Write("{");
            for (int i = maxSumStartIndex; i < maxSumStartIndex + k; i++)
            {
                Console.Write(numbers[i]);
                if (i < maxSumStartIndex + k - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("}} = {0}", maxSum); 
            Console.WriteLine();
        }
    }
}
