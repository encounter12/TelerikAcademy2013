namespace MajorantFindingV1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
    /// Write a program to find the majorant of given array (if exists). Example: {2, 2, 3, 3, 2, 3, 4, 3, 3}  -> 3
    /// </summary>
    internal class MajorantFindingV1
    {
        private static void Main()
        {
            Console.WriteLine("Enter integers separated by comma or whitespace:");
            string input = ValidateUserConsoleInput();

            int[] numbers = ConvertInputToIntArray(input);
            int majorant = FindMajorant(numbers);
            Console.WriteLine("{0} -> {1}", PrintIntArray(numbers), PrintMajorant(majorant));
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

        private static int FindMajorant(int[] numbers)
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

            int majorantOccurrences = (numbers.Length / 2) + 1;

            int majorantNumber = -1;
                majorantNumber = occurrences.FirstOrDefault(count => count.Value >= majorantOccurrences).Key;
            return majorantNumber;
        }

        private static string PrintMajorant(int majorant)
        {
            if (majorant != 0)
            {
                return majorant.ToString();
            }
            else
            {
                return "No existing majorant";
            }
        }

        private static string PrintIntArray(int[] numbers)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            for (int i = 0; i < numbers.Length; i++)
            {
                sb.Append(numbers[i]);
                if (i < numbers.Length - 1)
                {
                    sb.Append(", ");
                }
            }

            sb.Append("}");

            return sb.ToString();
        }
    }
}