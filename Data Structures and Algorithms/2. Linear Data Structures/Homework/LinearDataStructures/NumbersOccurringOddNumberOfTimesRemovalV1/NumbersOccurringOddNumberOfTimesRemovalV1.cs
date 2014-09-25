namespace SequenceNumbersOccurringOddNumberOfTimesRemoval
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that removes from given sequence all numbers that occur odd number of times. 
    /// Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}
    /// </summary>
    internal class NumbersOccurringOddNumberOfTimesRemovalV1
    {
        private static void Main()
        {
            Console.WriteLine("Enter integers separated by comma or whitespace:");

            string input = ValidateUserConsoleInput();
            List<int> numbers = ConvertInputToList(input);
            List<int> result = RemoveNumbersOccurringOddNumberOfTimes(numbers);

            Console.WriteLine("{{{0}}} -> {{{1}}}", string.Join(", ", numbers), string.Join(", ", result));
        }

        private static string ValidateUserConsoleInput()
        {
            bool userInputCorrect = false;
            string input;
            do
            {
                input = Console.ReadLine();
                char[] chars = new char[] { ' ', ',' };
                string[] inputArray = input.Split(chars, StringSplitOptions.RemoveEmptyEntries);

                int len = inputArray.Length;
                for (int i = 0; i < len; i++)
                {
                    int number;
                    userInputCorrect = int.TryParse(inputArray[i].Trim(), out number);
                    if (!userInputCorrect)
                    {
                        Console.WriteLine("The input is not in the correct format. Please, re-enter:");
                        break;
                    }
                }
            }
            while (!userInputCorrect);

            return input;
        }

        private static List<int> ConvertInputToList(string input)
        {
            List<int> sequence = new List<int>();

            char[] chars = new char[] { ' ', ',' };
            string[] inputArray = input.Split(chars, StringSplitOptions.RemoveEmptyEntries);

            int len = inputArray.Length;

            for (int i = 0; i < len; i++)
            {
                int number;
                try
                {
                    number = int.Parse(inputArray[i].Trim());
                }
                catch (Exception ex)
                {
                    throw new FormatException(string.Format("The argument '{0}' is not of correct type.", inputArray[i]), ex);
                }

                sequence.Add(number);
            }

            return sequence;
        }

        private static List<int> RemoveNumbersOccurringOddNumberOfTimes(List<int> numbers)
        {
            List<int> result = new List<int>();

            foreach (int number in numbers)
            {
                int count = CountOccurrences(numbers, number);
                if (count % 2 == 0)
                {
                    result.Add(number);
                }
            }

            return result;
        }

        private static int CountOccurrences(List<int> numbers, int number)
        {
            int count = 0;
            foreach (int item in numbers)
            {
                if (number == item)
                {
                    count++;
                }
            }

            return count;
        }
    }
}