namespace ReverseIntegersUsingAStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that reads N integers from the console and reverses them using a stack. 
    /// Use the Stack<int> class.
    /// </summary>
    internal class ReverseIntegersUsingAStack
    {
        private static void Main()
        {
            Console.Write("Please enter N (specifies how much integers will be entered): ");
            int numbersLength = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < numbersLength; i++)
            {
                Console.Write("Enter number {0}: ", i);
                int number = int.Parse(Console.ReadLine());
                numbers.Push(number);
            }

            // When converted to array the top number in the stack becomes the 0-th element in the array,
            // the bottom number in the stack becomes the last element in the array.
            string reversedNumbers = string.Join(", ", numbers.ToArray());
            Console.Write("The reversed numbers: {0}\n", reversedNumbers);
        }
    }
}