namespace SequenceAllNegativeNumbersRemoval
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that removes from given sequence all negative numbers.
    /// </summary>
    internal class SequenceAllNegativeNumbersRemoval
    {
        private static void Main()
        {
            Console.WriteLine("Enter numbers (positive or negative) separated by comma or whitespace:");

            string input = ValidateUserConsoleInput();
            List<double> numbers = ConvertInputToList(input);

            string initialSequenceString = string.Join(", ", numbers);
            Console.WriteLine("The initial sequence: {{{0}}}", initialSequenceString);

            List<double> nonNegativeNumbers = RemoveNegativeNumbers(numbers);
            string nonNegativeNumbersString = string.Join(", ", nonNegativeNumbers);
            Console.WriteLine("The sequence without negative numbers: {{{0}}}", nonNegativeNumbersString);
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
                    double number;
                    userInputCorrect = double.TryParse(inputArray[i].Trim(), out number);
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

        private static List<double> ConvertInputToList(string input)
        {
            List<double> sequence = new List<double>();

            char[] chars = new char[] { ' ', ',' };
            string[] inputArray = input.Split(chars, StringSplitOptions.RemoveEmptyEntries);

            int len = inputArray.Length;

            for (int i = 0; i < len; i++)
            {
                double number;
                try
                {
                    number = double.Parse(inputArray[i].Trim());
                }
                catch (Exception ex)
                {
                    throw new FormatException(string.Format("The argument '{0}' is not of correct type.", inputArray[i]), ex);
                }

                sequence.Add(number);
            }

            return sequence;
        }

        private static List<double> RemoveNegativeNumbers(List<double> numbers)
        {
            List<double> nonNegativeNumbers = new List<double>();

            foreach (double number in numbers)
            {
                if (number >= 0)
                {
                    nonNegativeNumbers.Add(number);
                }
            }

            return nonNegativeNumbers;
        }
    }
}