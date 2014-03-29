using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumContiguousSubsequence
{
    class MaxSumContiguousSubsequenceV1
    {
        static int MaxSumContiguousSubseq(int[] numbers, out int maxSumStartIndex, out int maxSumLength)
        {
            int currentSum = 0;
            maxSumStartIndex = 0;
            int maxSum = int.MinValue;
            maxSumLength = 1;
            int i;

            for (i = 1; i <= numbers.Length; i++)  //increases the subsequence length i;
            {                
                for (int s = 0; s <= numbers.Length - i; s++) //iterates through the array from 0 to the array elements number minus the subsequence length i
                {
                    for (int j = s; j < s + i; j++) //calcuates the current subsequence sum
                    {
                        currentSum += numbers[j];
                    }                                       
                    if (currentSum > maxSum) //if the current subsequence sum is bigger than the previous one it becomes the maximum sum
                    {
                        maxSum = currentSum;
                        maxSumStartIndex = s;
                        maxSumLength = i;
                    }
                    currentSum = 0;
                }                
            }            
            return maxSum;
        }
        static void Main()
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

            int maxSumStartIndex;
            int maxSumLength;

            int maxSum = MaxSumContiguousSubseq(numbers, out maxSumStartIndex, out maxSumLength);

            Console.WriteLine("The First Maximum Sum Contiguous Subsequence is:");
            Console.Write("{");
            for (int i = maxSumStartIndex; i < maxSumStartIndex + maxSumLength; i++)
            {
                Console.Write(numbers[i]);
                if (i < maxSumStartIndex + maxSumLength - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("}} = {0}", maxSum);
            Console.WriteLine();
        }
    }
}
