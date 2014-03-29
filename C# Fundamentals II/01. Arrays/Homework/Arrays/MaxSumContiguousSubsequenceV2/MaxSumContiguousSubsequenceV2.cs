using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumTest2
{
    
    class MaxSumContiguousSubsequenceV2
    {
        static private int maxSumStartIndex = 0;
        static private int maxSumEndIndex = -1;

        public static int MaxSumContiguousSubsequence(int[] numbers) //this method implements the Kadane's linear time algorithm
        {
            int maxSum = int.MinValue;
            int currentSum = 0;
            int currentSumStartIndex = 0;

            for (int index = 0; index < numbers.Length; index++)
            {
                currentSum += numbers[index];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxSumStartIndex = currentSumStartIndex;
                    maxSumEndIndex = index;
                }
                if (currentSum < 0)
                {
                    currentSum = 0;
                    currentSumStartIndex = index + 1;                    
                }
            }

            return maxSum;
        }
        static void Main(string[] args)
        {
            /*Problem: "Write a program that finds the sequence of maximal sum in given array"
             This excercise is known as: "Maximum Subarray Problem" or "Maximum Contiguous Subsequence Sum" or "Maximum Sum Contiguous Subsequence Problem"
             * http://en.wikipedia.org/wiki/Maximum_subarray_problem
             */

            Console.WriteLine("Enter the array elements number N:");
            int arrayLengthN = int.Parse(Console.ReadLine());

            int[] numbers = new int[arrayLengthN];

            Console.WriteLine("Enter the array numbers:");
            for (int i = 0; i < arrayLengthN; i++)
            {
                Console.Write("numbers[{0}] = ", i);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int maxSum = MaxSumContiguousSubsequence(numbers);

            Console.WriteLine("The First Maximum Sum Contiguous Subsequence is:");
            Console.Write("{");
            for (int i = maxSumStartIndex; i <= maxSumEndIndex; i++)
            {
                Console.Write(numbers[i]);
                if (i < maxSumEndIndex)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("}} = {0}", maxSum);
            Console.WriteLine();
        }
    }
}
