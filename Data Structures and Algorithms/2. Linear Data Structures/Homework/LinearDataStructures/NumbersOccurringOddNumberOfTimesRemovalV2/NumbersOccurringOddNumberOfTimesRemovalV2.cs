namespace NumbersOccurringOddNumberOfTimesRemovalV2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that removes from given sequence all numbers that occur odd number of times. 
    /// Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}
    /// </summary>
    internal class NumbersOccurringOddNumberOfTimesRemovalV2
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

        // Guidelines from "Fundamentals to Programming with C#" book (by Svetlin Nakov) (p. 679): 
        // Fast solution: use a hash-table (Dictionary<int, int>). 
        // With a single scan calculate count[p] (the number of occurrences of p in the input sequence) for each number p from the input sequence. 
        // With another single scan pass through all numbers p and append p to the result only when count[p] is even.
        private static List<int> RemoveNumbersOccurringOddNumberOfTimes(List<int> numbers)
        {
            // the 1-st foreach could be replaced with: 
            // Dictionary<int, int> numbersCounts = numbers.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            Dictionary<int, int> numbersCounts = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if (numbersCounts.ContainsKey(number))
                {
                    numbersCounts[number]++;
                }
                else
                {
                    numbersCounts[number] = 1;
                }
            }
            
            List<int> result = new List<int>();
            
            foreach (KeyValuePair<int, int> item in numbersCounts)
            {
                if (item.Value % 2 == 0)
                {
                    result.Add(item.Key);
                }
            }

            return result;
        }
    }
}