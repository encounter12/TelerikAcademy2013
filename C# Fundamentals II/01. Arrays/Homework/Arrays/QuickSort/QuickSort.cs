using System;

namespace QuickSort
{
    class ArrayQuickSort
    {        

        static void Main(string[] args)
        {
            //Write a program that sorts an array of strings using the quick sort algorithm.

            Console.WriteLine("Please, enter array length:");
            int arrayLength = int.Parse(Console.ReadLine());

            int[] array = new int[arrayLength];

            Console.WriteLine("Please, enter array elements (integers):");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            QuickSort(array);

            // or alternatively - use the Array.Sort method, which implements the Quick Sort algorithm
            // Array.Sort(array);

            Console.WriteLine("The sorted elements are:");
            Console.Write("{");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("}");
        }

        public static void QuickSort(int[] array)
        {
            if (array.Length > 1)
            {
                QuickSortInternal(array, 0, array.Length - 1);
            }
        }

        private static void QuickSortInternal(int[] array, int left, int right)
        {
            if (left < right)
            {
                int q = Partition(array, left, right);

                QuickSortInternal(array, left, q - 1);
                QuickSortInternal(array, q + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int temp;

            int i = left;
            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    temp = array[j];
                    array[j] = array[i];
                    array[i] = temp;
                    i++;
                }
            }

            array[right] = array[i];
            array[i] = pivot;

            return i;
        }
    }
}
