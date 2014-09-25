namespace EqualNumbersLongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a method that finds the longest subsequence of equal numbers in given List<int>and returns the result as new List<int>. 
    /// Write a program to test whether the method works correctly.
    /// </summary>
    public class LongestSubsequence
    {
        public static void Main()
        {
            Console.WriteLine("Enter integers separated by whitespace or comma:");

            string input = ValidateUserConsoleInput();
            List<int> numbers = ConvertInputToList(input);

            string initialSequenceString = string.Join(", ", numbers);
            Console.WriteLine("The initial sequence list: {{{0}}}", initialSequenceString);

            List<int> equalNumbersLongestSubsequence = GetEqualNumbersLongestSubsequence(numbers);

            string longestSubsequenceString = string.Join(", ", equalNumbersLongestSubsequence);
            Console.WriteLine("The longest subsequence of equal numbers is: {{{0}}}", longestSubsequenceString);
        }

        public static string ValidateUserConsoleInput()
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

        public static List<int> ConvertInputToList(string input)
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

        public static List<int> GetEqualNumbersLongestSubsequence(List<int> numbers)
        {
            List<int> currentSubsequence = new List<int>();
            int currentIndex = 0;
            currentSubsequence.Add(numbers[currentIndex]);

            List<int> equalNumbersLongestSubsequence = new List<int>();
            List<int> previousLongestSubsequence = new List<int>();

            while (currentIndex < numbers.Count - 1)
            {
                if (numbers[currentIndex + 1] == numbers[currentIndex])
                {
                    currentSubsequence.Add(numbers[currentIndex + 1]);
                }
                else
                {
                    equalNumbersLongestSubsequence = GetLongerSequence(previousLongestSubsequence, currentSubsequence);
                    previousLongestSubsequence = new List<int>(equalNumbersLongestSubsequence);
                    currentSubsequence = new List<int>() { numbers[currentIndex + 1] };
                }

                currentIndex++;
            }

            equalNumbersLongestSubsequence = GetLongerSequence(previousLongestSubsequence, currentSubsequence);

            return equalNumbersLongestSubsequence;
        }

        public static List<int> GetLongerSequence(List<int> firstSubsequence, List<int> secondSubsequence)
        {
            List<int> longerSubsequence = new List<int>(firstSubsequence);

            if (firstSubsequence.Count < secondSubsequence.Count)
            {
                longerSubsequence = new List<int>(secondSubsequence);
            }

            return longerSubsequence;
        }
    }
}