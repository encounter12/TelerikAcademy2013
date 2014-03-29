using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSubsequenceOfGivenSum
{
    class FindSubsequenceOfGivenSum
    {
        static bool ArrayFindSubsequenceWithGivenSum(int[] numbers, int givenSum, out int sumStartIndex, out int sumEndIndex)
        {
            sumStartIndex = 0;
            sumEndIndex = 0;
            int currentSum = 0;
            int m;
            bool sequenceAvailable = false;

            for (int i = 0; i < numbers.Length; i++)
            {

                for (m = i; m < numbers.Length; m++)
                {
                    currentSum += numbers[m];
                    if (currentSum >= givenSum)
                    {
                        break;
                    }
                }
                if (currentSum == givenSum)
                {
                    sumStartIndex = i;
                    sumEndIndex = m;
                    sequenceAvailable = true;
                    break;
                }
                currentSum = 0;
            }
            return sequenceAvailable;
        }
        static void Main(string[] args)
        {
            /*Write a program that finds in given array of integers a sequence of given sum S (if present). 
             * Example: {4, 3, 1, 4, 2, 5, 8}, S=11 - {4, 2, 5}*/

            int sumStartIndex = 0;
            int sumEndIndex = 0;

            Console.WriteLine("Enter the array elements number N:");
            int arrayLengthN = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the given sum S:");
            int givenSum = int.Parse(Console.ReadLine());

            int[] numbers = new int[arrayLengthN];
            
            Console.WriteLine("Enter the array numbers:");
            for (int i = 0; i < arrayLengthN; i++)
            {
                Console.Write("numbers[{0}] = ", i);
                numbers[i] = int.Parse(Console.ReadLine());
            }
            
            bool sequenceAvailable = ArrayFindSubsequenceWithGivenSum(numbers, givenSum, out sumStartIndex, out sumEndIndex);
           
            if (sequenceAvailable)
            {
                Console.WriteLine("The first subsequence with the given sum S is: ");
                Console.Write("{");
                for (int i = sumStartIndex; i <= sumEndIndex; i++)
                {
                    Console.Write(numbers[i]);
                    if (i < sumEndIndex)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write("}");
            }
            else
            {
                Console.WriteLine("No sequence available");
            }

            Console.WriteLine();
        }
    }
}
