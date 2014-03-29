using System;

namespace ArrayMostFrequentNumber
{
    class ArrayMostFrequentNumber
    {
        static int LowestMostFrequentNumber(int[] numbers, out int mostFrequentNumberCount)
        {
            int length = numbers.Length;
            Array.Sort(numbers);

            int currentNumber = numbers[0];
            int currentNumberCount = 1;

            int mostFrequentNumber = numbers[0];
            mostFrequentNumberCount = int.MinValue;
          
            for (int i = 0; i < length - 1; i++)
            {                
                if (numbers[i] == numbers[i + 1])
                {
                    currentNumberCount++;
                    continue;                    
                }
                if (currentNumberCount > mostFrequentNumberCount)
                {
                    mostFrequentNumberCount = currentNumberCount;
                    mostFrequentNumber = currentNumber;                                        
                }
                currentNumberCount = 1;
                currentNumber = numbers[i + 1];
            }

            if (currentNumberCount > mostFrequentNumberCount)
            {
                mostFrequentNumberCount = currentNumberCount;
                mostFrequentNumber = currentNumber;
            }

            return mostFrequentNumber;
        }

        static void Main()
        {
            /*Write a program that finds the most frequent number in an array*/

            Console.WriteLine("Enter the array elements number N:");
            int arrayLengthN = int.Parse(Console.ReadLine());

            int[] numbers = new int[arrayLengthN];
            int mostFrequentNumber;
            int mostFrequentNumberCount;

            Console.WriteLine("Enter the array numbers:");
            for (int i = 0; i < arrayLengthN; i++)
            {
                Console.Write("numbers[{0}] = ", i);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            mostFrequentNumber = LowestMostFrequentNumber(numbers, out mostFrequentNumberCount);
                  
            Console.WriteLine("First (lowest) most frequent number: {0}\nOccurrences: {1}", mostFrequentNumber, mostFrequentNumberCount);
        }
    }
}
