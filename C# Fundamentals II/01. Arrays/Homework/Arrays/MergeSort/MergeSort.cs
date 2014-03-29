using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class MergeSort
    {
        static int[] mergeSort(int[] array)
        {        
            if(array.Length > 1)
            {               
                int elementsInA1 = array.Length / 2;         
                int elementsInA2 = array.Length - elementsInA1;
                int[] arr1 = new int[elementsInA1];
                int[] arr2 = new int[elementsInA2];
                for (int i = 0; i < elementsInA1; i++)
                {
                    arr1[i] = array[i];
                }

                for (int i = elementsInA1; i < elementsInA1 + elementsInA2; i++)
                {
                    arr2[i - elementsInA1] = array[i];
                }
                                        
                arr1 = mergeSort(arr1);
                arr2 = mergeSort(arr2);
                 
                int m = 0, j = 0, k = 0;
               
                while (arr1.Length != j && arr2.Length != k)
                {
                    if (arr1[j] < arr2[k])
                    {
                        array[m] = arr1[j];
                        m++; j++;
                    }                        
                    else
                    {
                        array[m] = arr2[k];
                        m++; k++;
                    }
                }
                
                while (arr1.Length != j)
                {
                    array[m] = arr1[j];
                    m++; j++;
                }
                while (arr2.Length != k)
                {
                    array[m] = arr2[k];
                    m++; k++;
                }
            }
            return array;
        }

        static void Main(string[] args)
        {
            /*Write a program that sorts an array of integers using the merge sort algorithm (see: http://en.wikipedia.org/wiki/Merge_sort )*/

            Console.WriteLine("Enter the array elements number N:");
            int arrayLengthN = int.Parse(Console.ReadLine());            

            int[] numbers = new int[arrayLengthN];

            Console.WriteLine("Enter the array numbers:");
            for (int i = 0; i < arrayLengthN; i++)
            {
                Console.Write("numbers[{0}] = ", i);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            mergeSort(numbers);

            Console.WriteLine("The sorted array using merge sort algorithm is:");
            Console.Write("{");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]);
                if (i < numbers.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("}");
            Console.WriteLine();
        }
    }
}
