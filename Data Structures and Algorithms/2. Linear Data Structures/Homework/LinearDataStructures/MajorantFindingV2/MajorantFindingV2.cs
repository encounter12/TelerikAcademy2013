namespace MajorantFindingV2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
    /// Write a program to find the majorant of given array (if exists). Example: {2, 2, 3, 3, 2, 3, 4, 3, 3}  -> 3
    /// </summary>
    internal class MajorantFindingV2
    {
        private static void Main()
        {
            Console.WriteLine("Enter integers separated by comma or whitespace:");
            string input = ValidateUserConsoleInput();

            List<int> numbers = ConvertInputToList(input);

            int majorant;
            bool isMajorantFound = TryFindMajorant(numbers, out majorant);

            Console.WriteLine("{0} -> {1}", PrintNumbers(numbers), PrintMajorant(isMajorantFound, majorant));
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

        // Guidelines from "Fundamentals of Computer Programming with C#" book (by Svetlin Nakov): 
        // Use list. Sort the list and you are going to get the equal numbers next to one another. 
        // Scan the array by counting the number of occurrences of each number. 
        // If up to a certain moment a number has occurred N/2+1 times, this is the majorant and there is no need to check further. 
        // If after position N/2+1 there is a new number (a majorant is not found until this moment), there is no need to search further – 
        // even in the case when the list is filled with the current number to the end, it will not occur N/2+1 times.
        private static bool TryFindMajorant(List<int> numbers, out int majorant)
        {
            bool isMajorantFound = false;
            List<int> numbersCopy = new List<int>(numbers);
            numbersCopy.Sort();

            int numberCount = 0;
            int previousNumber = numbers[0];
            majorant = 0;
            int majorantBoundary = (numbers.Count / 2) + 1;
            foreach (var number in numbersCopy)
            {
                if (number == previousNumber)
                {
                    numberCount++;
                    if (numberCount >= majorantBoundary)
                    {
                        isMajorantFound = true;
                        majorant = number;
                        break;
                    }
                }
                else
                {
                    numberCount = 0;
                    numberCount++;
                }

                previousNumber = number;
            }

            return isMajorantFound;
        }

        private static string PrintMajorant(bool isMajorantFound, int majorant)
        {
            if (isMajorantFound)
            {
                return majorant.ToString();
            }
            else
            {
                return "No existing majorant";
            }
        }

        private static string PrintNumbers(List<int> numbers)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            int len = numbers.Count;
            for (int i = 0; i < len; i++)
            {
                sb.Append(numbers[i]);
                if (i < len - 1)
                {
                    sb.Append(", ");
                }
            }

            sb.Append("}");

            return sb.ToString();
        }
    }
}
