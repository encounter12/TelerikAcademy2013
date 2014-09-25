namespace SequenceSumAndAverage
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that reads from the console a sequence of positive integer numbers. 
    /// The sequence ends when empty line is entered. Calculate and print the sum and average of the elements of the sequence. 
    /// Keep the sequence in List<int>.
    /// </summary>
    internal class SequenceSumAndAverage
    {
        private static void Main()
        {
            Console.WriteLine("Enter integers separated by whitespace:");

            string input = ReadInput();
            List<int> sequence = ConvertInputToList(input);

            long sum = CalculateSum(sequence);
            double average = CalculateAverage(sequence);

            Console.WriteLine("Elements sum: {0}", sum);
            Console.WriteLine("Elements average: {0}", average);
        }

        private static string ReadInput()
        {
            string input = string.Empty;

            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                input += line;
            }

            return input;
        }

        private static List<int> ConvertInputToList(string input)
        {
            List<int> sequence = new List<int>();
            string[] inputArray = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int len = inputArray.Length;

            for (int i = 0; i < len; i++)
            {
                int number = int.Parse(inputArray[i].Trim());
                sequence.Add(number);
            }

            return sequence;
        }

        private static long CalculateSum(List<int> numbers)
        {
            long sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        private static double CalculateAverage(List<int> numbers)
        {
            long sum = 0;
            int count = 0;
            foreach (var number in numbers)
            {
                sum += number;
                count++;
            }

            double average = (double)sum / count;
            return average;
        }
    }
}