using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortStringArrayByLength
{
    class SortStringArrayByLength
    {
        static void Main(string[] args)
        {
            string[] array = { "abc", "abcdefgsaas", "sdfbs", "s;fjasl;dfjasjwlekj", "asldfjk", "sdfj;asjklj;ljksds", "sdf", "sdfkenjdlwidyricldksnslelsid", "s;lkshekl" };
            Console.WriteLine("Unsorted:");
            foreach (string item in array)
            {
                Console.WriteLine(item);
            }
            array = MergeSort(array);
            Console.WriteLine();
            Console.WriteLine("Sorted:");
            foreach (string item in array)
            {
                Console.WriteLine(item);
            }
        }
        public static string[] MergeSort(string[] a)
        {
            if (a.Length == 1)
                return a;
            int middle = a.Length / 2;
            string[] left = new string[middle];
            for (int i = 0; i < middle; i++)
            {
                left[i] = a[i];
            }
            string[] right = new string[a.Length - middle];
            for (int i = 0; i < a.Length - middle; i++)
            {
                right[i] = a[i + middle];
            }
            left = MergeSort(left);
            right = MergeSort(right);
            int leftptr = 0;
            int rightptr = 0;
            string[] sorted = new string[a.Length];
            for (int k = 0; k < a.Length; k++)
            {
                if (rightptr == right.Length || ((leftptr < left.Length) && (left[leftptr].Length <= right[rightptr].Length)))
                {
                    sorted[k] = left[leftptr];
                    leftptr++;
                }
                else if (leftptr == left.Length || ((rightptr < right.Length) && (right[rightptr].Length <= left[leftptr].Length)))
                {
                    sorted[k] = right[rightptr];
                    rightptr++;
                }
            }
            return sorted;
        }
    }
}
