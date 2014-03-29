using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsThereSubsetWithSumS
{
    class IsThereSubsetWithSumS
    {
        /* We are given an array of integers and a number S. Write a program to find if there exists a subset of the elements of the array that has a sum S. 
         * Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)
         */

        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter array length:");
            int arrayLength = int.Parse(Console.ReadLine());

            int[] array = new int[arrayLength];

            Console.WriteLine("Please, enter array elements (integers):");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Please, enter sum:");
            int sum = int.Parse(Console.ReadLine());

            List<int[]> subsets = FindSubsets(array);

            Console.WriteLine("Subsets of {{" + string.Join(", ", array.Select(x => x.ToString()).ToArray()) + "}} with sum = {0}:", sum);
            foreach (int[] subset in subsets)
            {
                if (subset.Sum() == sum)
                {
                    Console.WriteLine("{" + string.Join(", ", subset.Select(x => x.ToString()).ToArray()) + "}");
                }
            }
        }

        // all possible subsets of a given array
        public static List<T[]> FindSubsets<T>(T[] originalArray)
        {
            List<T[]> subsets = new List<T[]>();

            for (int i = 0; i < originalArray.Length; i++)
            {
                int subsetCount = subsets.Count;
                subsets.Add(new T[] { originalArray[i] });

                for (int j = 0; j < subsetCount; j++)
                {
                    T[] newSubset = new T[subsets[j].Length + 1];
                    subsets[j].CopyTo(newSubset, 0);
                    newSubset[newSubset.Length - 1] = originalArray[i];
                    subsets.Add(newSubset);
                }
            }

            return subsets;
        }
    }
}
