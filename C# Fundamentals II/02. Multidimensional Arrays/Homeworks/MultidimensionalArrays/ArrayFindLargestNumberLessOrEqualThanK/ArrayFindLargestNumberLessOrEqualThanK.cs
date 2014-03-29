using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayFindLargestNumberLessOrEqualThanK
{
    class ArrayFindLargestNumberLessOrEqualThanK
    {
        static void Main()
        {
            /*Write a program, that reads from the console an array of N integers and an integer K, 
             * sorts the array and using the method Array.BinarySearch() finds the largest number in the array which is ≤ K*/

            Console.WriteLine("Write the array lenght n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Write number K:");
            int k = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("numbers[{0}] = ", i);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(numbers);
            int myIndex = Array.BinarySearch(numbers, k);
            int myIndexBitwiseComplement = ~Array.BinarySearch(numbers, k);

            int resultNumber;

            /* Array.Binary Search Method (http://msdn.microsoft.com/en-us/library/y15ef976.aspx) application: 
             * 1. If myIndex > 0, then index is the index of the array element that is equal to k
             * 2. If myIndex < 0 and (-1) * myIndex <= numbers.Length, 
             * then ~Array.BinarySearch(numbers, k) is the index of the first number within the array that is larger than k
             * 3. If myIndex < 0 and (-1) * myIndex > numbers.Length, then all array elements are < k;
             */

            if (myIndex >= 0)
            {
                resultNumber = numbers[myIndex]; //in this case there is array element equal to K
            }
            else if (myIndex < 0 && myIndexBitwiseComplement <= numbers.Length - 1)
            {
                resultNumber = numbers[myIndexBitwiseComplement - 1]; //the largest number in the array which is < K
            }
            else
            {
                resultNumber = numbers[numbers.Length - 1];
            }            

            Console.WriteLine("The largest number in the array which is <= K is: {0}", resultNumber);
        }
    }
}
