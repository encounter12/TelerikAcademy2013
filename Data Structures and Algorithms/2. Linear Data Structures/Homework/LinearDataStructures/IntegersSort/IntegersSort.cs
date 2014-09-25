namespace IntegersSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that reads a sequence of integers (List<int>) ending with an empty line 
    /// and sorts them in an increasing order.
    /// </summary>
    internal class IntegersSort
    {
        private static void Main()
        {
            Console.WriteLine("Enter integers separated by whitespace:");
            string input = ReadInput();
            List<int> numbers = ConvertInputToList(input);

            List<int> sortedNumbers = SortInIncreasingOrder(numbers);

            Console.WriteLine("The sorted numbers sequence: {0}", string.Join(", ", sortedNumbers));

            Console.WriteLine("The initial numbers sequence: {0}", string.Join(", ", numbers));
        }

        private static List<int> SortInIncreasingOrder(List<int> numbers)
        {
            // copy the initial list into a new one, this method is valid only for primitive types. 
            List<int> copiedNumbers = new List<int>(numbers);

            int len = copiedNumbers.Count;

            // performs the sort
            for (int i = 0; i < len; i++)
            {
                for (int j = len - 1; j > i; j--)
                {
                    int previousNumber;
                    if (copiedNumbers[j] < copiedNumbers[j - 1])
                    {
                        previousNumber = copiedNumbers[j - 1];
                        copiedNumbers[j - 1] = copiedNumbers[j];
                        copiedNumbers[j] = previousNumber;
                    }
                }
            }

            return copiedNumbers;
        }

        private static string ReadInput()
        {
            string input = string.Empty;

            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                input += line;
            }

            return input;
        }

        private static List<int> ConvertInputToList(string input)
        {
            List<int> sequence = new List<int>();
            string[] inputArray = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int len = inputArray.Length;

            for (int i = 0; i < len; i++)
            {
                int number = int.Parse(inputArray[i].Trim());
                sequence.Add(number);
            }

            return sequence;
        }
    }
}
