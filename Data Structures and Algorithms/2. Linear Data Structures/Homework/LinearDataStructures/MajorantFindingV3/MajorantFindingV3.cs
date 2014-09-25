namespace MajorantFindingV3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
    /// Write a program to find the majorant of given array (if exists). Example: {2, 2, 3, 3, 2, 3, 4, 3, 3}  -> 3
    /// </summary>
    internal class MajorantFindingV3
    {
        private static void Main()
        {
            Console.WriteLine("Enter integers separated by comma or whitespace:");
            string input = ValidateUserConsoleInput();
            int[] numbers = ConvertInputToIntArray(input);
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

        private static int[] ConvertInputToIntArray(string input)
        {
            char[] chars = new char[] { ' ', ',' };
            string[] inputArray = input.Split(chars, StringSplitOptions.RemoveEmptyEntries);

            int len = inputArray.Length;
            int[] numbers = new int[len];

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

                numbers[i] = number;
            }

            return numbers;
        }

        // Guidelines from "Fundamentals of Computer Programming with C#" book (by Svetlin Nakov):
        // Use a stack. Scan through the elements. 
        // At each step if the element at the top of the stack is different from the next element form the input sequence, remove the element from the stack. 
        // Otherwise append the element to the stack. Finally the majorant will be in stack (if it exists). 
        // Why? Each time when we find any two different elements, we discard both of them. 
        // And this operation keeps the majorant the same and decreases the length of the sequence. 
        // If we repeat this as much times as possible, finally the stack will hold only elements with the same value – the majorant.
        private static bool TryFindMajorant(int[] numbers, out int majorant)
        {
            bool isMajorantFound = false;
            majorant = 0;

            Stack<int> majorantCandidateStack = new Stack<int>();
            majorantCandidateStack.Push(numbers[0]);

            int size = numbers.Length;
            for (int i = 1; i < size; i++)
            {
                if (majorantCandidateStack.Count == 0)
                {
                    majorantCandidateStack.Push(numbers[i]);
                }
                else if (majorantCandidateStack.Peek() == numbers[i])
                {
                    majorantCandidateStack.Push(numbers[i]);
                }
                else
                {
                    majorantCandidateStack.Pop();
                }
            }

            if (majorantCandidateStack.Count == 0)
            {
                isMajorantFound = false;
            }

            int majorityBoundary = size / 2;
            int majorityCandidateNumber = majorantCandidateStack.Pop();
            int majorityCandidateCount = 0;

            for (int i = 0; i < size; i++)
            {
                if (numbers[i] == majorityCandidateNumber)
                {
                    majorityCandidateCount++;
                }
            }

            if (majorityCandidateCount > majorityBoundary)
            {
                majorant = majorityCandidateNumber;
                isMajorantFound = true;
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
                return "No existing majority";
            }
        }

        private static string PrintNumbers(int[] numbers)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            int len = numbers.Length;
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
