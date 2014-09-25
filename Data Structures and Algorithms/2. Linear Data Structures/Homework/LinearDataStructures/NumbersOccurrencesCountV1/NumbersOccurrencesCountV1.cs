namespace CountNumbersOccurrences
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
    /// Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
    /// 2 -> 2 times
    /// 3 -> 4 times
    /// 4 -> 3 times
    /// </summary>
    internal class NumbersOccurrencesCountV1
    {
        private static void Main()
        {
            Console.WriteLine("Enter integers separated by comma or whitespace:");
            string input = ValidateUserConsoleInput();

            int[] numbers = ConvertInputToIntArray(input);
            int maxNumber = 1000;
            int[] occurrences = CountNumbersOccurrences(numbers, maxNumber);

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

        // Guidelines from "Fundamentals to Programming with C#" book (by Svetlin Nakov): 
        // Make a new array "occurrences" with size 1001. 
        // After that scan through the list and for each number p increment the corresponding value of its occurrences (occurrences[p]++). 
        // Thus, at each index, where the value is not 0, we have an occurring number, so we print it.
        private static int[] CountNumbersOccurrences(int[] numbers, int maxNumber)
        {
            int[] occurrences = new int[maxNumber + 1];

            int len = numbers.Length;
            for (int i = 0; i < len; i++)
            {
                int occurrencesIndex = numbers[i];
                occurrences[occurrencesIndex]++;
            }

            return occurrences;
        }

        private static string PrintNumbersOccurrences(int[] occurrences)
        {
            StringBuilder sb = new StringBuilder();

            int len = occurrences.Length;
            for (int i = 0; i < len; i++)
            {
                if (occurrences[i] != 0)
                {
                    sb.AppendFormat("{0} -> {1} time{2}", i, occurrences[i], occurrences[i] > 1 ? "s" : string.Empty);
                    sb.AppendLine();
                }
            }

            string result = sb.ToString();
            return result;
        }
    }
}
