using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArraySelectionSort
{
    class SortArraySelectionSort
    {
        static void SortArraySelectSort(int[] numbers)
        {
            int min;
            int temp;

            for (int i = 0; i < numbers.Length; i++)
            {
                min = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[min])
                    {
                        min = j;
                    }
                }
                temp = numbers[i];
                numbers[i] = numbers[min];
                numbers[min] = temp;
            }
        }
        static void Main()
        {
            /*Write a program to sort an array. Use the "selection sort" algorithm*/

            Console.WriteLine("Enter the array elements number N:");
            int arrayLengthN = int.Parse(Console.ReadLine());

            int[] numbers = new int[arrayLengthN];

            Console.WriteLine("Enter the array numbers:");
            for (int i = 0; i < arrayLengthN; i++)
            {
                Console.Write("numbers[{0}] = ", i);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            SortArraySelectSort(numbers);

            Console.WriteLine("Sorted array:");

            for (int i = 0; i < arrayLengthN; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
