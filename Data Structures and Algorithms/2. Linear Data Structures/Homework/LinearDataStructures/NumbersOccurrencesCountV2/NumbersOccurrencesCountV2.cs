namespace NumbersOccurrencesCountV2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
    /// Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
    /// 2 -> 2 times
    /// 3 -> 4 times
    /// 4 -> 3 times
    /// </summary>
    internal class NumbersOccurrencesCountV2
    {
        private static void Main()
        {
            Console.WriteLine("Enter integers separated by comma or whitespace:");
            string input = ValidateUserConsoleInput();

            int[] numbers = ConvertInputToIntArray(input);
            SortedDictionary<int, int> occurrences = CountNumbersOccurrences(numbers);

            Console.WriteLine(PrintNumbersOccurrences(occurrences));
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

        private static int[] ConvertInputToIntArray(string input)
        {
            char[] separators = new char[] { ',', ' ' };
            string[] inputStrings = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int len = inputStrings.Length;
            int[] numbers = new int[len];
            for (int i = 0; i < len; i++)
            {
                numbers[i] = int.Parse(inputStrings[i].Trim());
            }

            return numbers;
        }

        private static SortedDictionary<int, int> CountNumbersOccurrences(int[] numbers)
        {
            SortedDictionary<int, int> occurrences = new SortedDictionary<int, int>();
            foreach (var number in numbers)
            {
                if (occurrences.ContainsKey(number))
                {
                    occurrences[number]++;
                }
                else
                {
                    occurrences[number] = 1;
                }
            }

            return occurrences;
        }

        private static string PrintNumbersOccurrences(SortedDictionary<int, int> occurrences)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in occurrences)
            {
                sb.AppendFormat("{0} -> {1} time{2}", item.Key, item.Value, item.Value > 1 ? "s" : string.Empty);
                sb.AppendLine();
            }

            string result = sb.ToString();
            return result;
        }
    }
}
