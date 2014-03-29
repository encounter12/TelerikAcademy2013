using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindElementIndexUsingBinarySearch
{
    class FindElementIndexUsingBinarySearch
    {
        static int binarySearch(int[] numbers, int key, int imin, int imax)
        {                  
            if (imax < imin)
            {
                return -1;                
            }
            else
            {
                int imid = imin + (imax - imin) / 2;
                if (numbers[imid] > key)
                {
                    return binarySearch(numbers, key, imin, imid - 1);
                }
                else if (numbers[imid] < key)
                {
                    return binarySearch(numbers, key, imid + 1, imax);  
                }
                else
                {
                    return imid;
                }
            }            
        }
        static void Main(string[] args)
        {
            /*Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm*/

            Console.WriteLine("Enter array elements number N:");
            int arrayLengthN = int.Parse(Console.ReadLine());          

            int[] numbers = new int[arrayLengthN];

            Console.WriteLine("Enter the sorted array numbers:");
            for (int i = 0; i < arrayLengthN; i++)
            {
                Console.Write("numbers[{0}] = ", i);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter a number which index in the array should be found:");
            int givenNumber = int.Parse(Console.ReadLine());

            int givenNumberIndex = binarySearch(numbers, givenNumber, 0, arrayLengthN - 1);

            if (givenNumberIndex == -1)
            {
                Console.WriteLine("Key not found");
            }
            else
            {
                Console.WriteLine(givenNumberIndex);
            }
        }
    }
}
