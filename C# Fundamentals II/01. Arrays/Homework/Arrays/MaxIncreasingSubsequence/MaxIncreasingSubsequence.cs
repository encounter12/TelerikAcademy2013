using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxIncreasingSubsequence
{
    class ArrayMaxIncreasingSubsequence
    {
        static int MaxIncreasingContiguousSubsequence(int[] numberArray, out int maxSequenceStartIndex)
        {
            int currentSequenceLength = 1;
            int currentSequenceStartIndex = 0;

            int maxSequenceLength = 0;
            maxSequenceStartIndex = 0;

            for (int m = 0; m < numberArray.Length - 1; m++)
            {
                if (numberArray[m + 1] == numberArray[m] + 1)
                {
                    currentSequenceLength++;
                    continue;
                }

                if (currentSequenceLength > maxSequenceLength)
                {
                    maxSequenceLength = currentSequenceLength;
                    maxSequenceStartIndex = currentSequenceStartIndex;
                }
                currentSequenceLength = 1;
                currentSequenceStartIndex = m + 1;
            }
            if (currentSequenceLength > maxSequenceLength)
            {
                maxSequenceLength = currentSequenceLength;
                maxSequenceStartIndex = currentSequenceStartIndex;
            }

            return maxSequenceLength;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Array number of elements:");
            int arrayLength = int.Parse(Console.ReadLine());
            int[] numberArray = new int[arrayLength];
            int maxSequenceStartIndex;
            int maxSequenceLength;

            for (int i = 0; i < arrayLength; i++)
            {
                Console.Write("number[{0}] = ", i);
                numberArray[i] = int.Parse(Console.ReadLine());
            }
            maxSequenceLength = MaxIncreasingContiguousSubsequence(numberArray, out maxSequenceStartIndex);

            Console.Write("The maximal increasing continuous subsequence is: {");
            for (int i = maxSequenceStartIndex; i < maxSequenceStartIndex + maxSequenceLength; i++)
            {

                Console.Write(numberArray[i]);
                if (i < maxSequenceStartIndex + maxSequenceLength - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("}");
            Console.WriteLine();
        }
    }
}
