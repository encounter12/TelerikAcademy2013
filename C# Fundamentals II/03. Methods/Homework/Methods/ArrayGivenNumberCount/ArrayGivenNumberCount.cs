using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayGivenNumberCount
{
    class ArrayGivenNumberCount
    {
        static void Main(string[] args)
        {
            int[] test1 = { 1, 2, 3, 4, 5, 6, 7 };
            int[] test2 = { -1, -5, 5, 5, 4 };
            int[] test3 = { 0, 0, 0, 0, 0, 0, 0, 0 };
            if (TimesInArray(test1, 3) == 1)
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }
            if (TimesInArray(test2, 5) == 2)
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }
            if (TimesInArray(test3, 0) == 8)
            {
                Console.WriteLine("Pass");
            }
            else Console.WriteLine("Fail");
        }
        public static int TimesInArray(int[] array, int number)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number) counter++;
            }
            return counter;
        }
    }
}
