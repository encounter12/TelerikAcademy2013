using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRangeFactorials
{
    class NumberRangeFactorials
    {
        static void Main(string[] args)
        {
            int[][] array = new int[100][];
            int[] factorial = { 1 };
            for (int i = 1; i <= 100; i++)
            {
                array[i - 1] = MultArray(factorial, i);
                factorial = array[i - 1];
                for (int j = 0; j < array[i - 1].Length; j++)
                {
                    Console.Write(array[i - 1][j]);
                }
                Console.WriteLine();
            }
        }
        static int[] MultArray(int[] array, int number)
        {
            List<int> result = new List<int>(array);
            int add = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                int multDigit = array[i] * number + add;
                result[i] = multDigit % 10;
                add = multDigit / 10;
            }
            if (add > 0) result.InsertRange(0, NumberToArray(add));
            return result.ToArray();
        }
        static int[] NumberToArray(int number)
        {
            List<int> numberAsList = new List<int>();
            do
            {
                numberAsList.Insert(0, (number % 10));
                number = number / 10;
            } while (number != 0);
            return numberAsList.ToArray();
        }
    }
}
