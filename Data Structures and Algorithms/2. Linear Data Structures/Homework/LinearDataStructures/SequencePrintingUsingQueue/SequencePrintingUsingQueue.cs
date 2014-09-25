namespace SequencePrintingUsingQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// We are given the following sequence:
    /// S1 = N;
    /// S2 = S1 + 1;
    /// S3 = 2*S1 + 1;
    /// S4 = S1 + 2;
    /// S5 = S2 + 1;
    /// S6 = 2*S2 + 1;
    /// S7 = S2 + 2;
    /// -----------
    /// Using the Queue<T> class write a program to print its first 50 members for given N.
    /// Example: N=2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
    /// </summary>
    internal class SequencePrintingUsingQueue
    {
        private static void Main()
        {
            Console.WriteLine("Enter integers separated by comma or whitespace:");
            int firstNElements = ValidateUserConsoleInput();
            Console.WriteLine("N={0} -> {1}", firstNElements, PrintSequenceMembers(firstNElements));

        }

        private static int ValidateUserConsoleInput()
        {
            bool userInputCorrect = false;
            string input;
            int number;
            do
            {
                input = Console.ReadLine();
                userInputCorrect = int.TryParse(input.Trim(), out number);
                if (!userInputCorrect)
                {
                    Console.WriteLine("The input is not in the correct format. Please, re-enter:");
                }
                
            }
            while (!userInputCorrect);

            return number;
        }

        private static string PrintSequenceMembers(int elementsNumber)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(elementsNumber);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

            }

        }
    }
}
