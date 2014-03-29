using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayMethodUsingMaxElementMethod
{   
    class SortArrayMethodUsingMaxElementMethod
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the array length:");
            int arrayLength = int.Parse(Console.ReadLine());
            int[] numbers = new int[arrayLength];

            Console.WriteLine("Specify the array elements:");
            for (int i = 0; i < arrayLength; i++)
            {
                Console.Write("numbers[{0}] = ", i);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int maxElementIndex;
            int maxElement = ArrayIndexRangeFindMaxElement(numbers, 0, numbers.Length - 1, out maxElementIndex);
            Console.WriteLine("\nMax element: {0}\n", maxElement);

            ArraySortDescending(numbers);

            Console.WriteLine("The array sorted descendingly is:{{ {0} }}", string.Join(", ", numbers));               

            ArraySortAscending(numbers);

            Console.WriteLine("The array sorted ascendingly is: {{ {0} }}", string.Join(", ", numbers));
            
        }
        public static int ArrayIndexRangeFindMaxElement(int[] numbers, int startIndex, int endIndex, out int maxElementIndex)
        {
            int maxElement = int.MinValue;
            maxElementIndex = startIndex;
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (numbers[i] > maxElement)
                {
                    maxElement = numbers[i];
                    maxElementIndex = i;
                }
            }
            return maxElement;
        }
        public static void ArraySortDescending(int[] numbers)
        {
            int temp;
            int maxElementIndex;
            for (int i = 0; i < numbers.Length; i++)
            {
                temp = numbers[i];
                numbers[i] = ArrayIndexRangeFindMaxElement(numbers, i, numbers.Length - 1, out maxElementIndex);
                numbers[maxElementIndex] = temp;
            }
        }
        public static void ArraySortAscending(int[] numbers)
        {
            int temp;
            int maxElementIndex;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                temp = numbers[i];
                numbers[i] = ArrayIndexRangeFindMaxElement(numbers, 0, i, out maxElementIndex);
                numbers[maxElementIndex] = temp;
            }
        }
    }
}
