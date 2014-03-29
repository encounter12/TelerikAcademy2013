using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSubsetsHavingSumZeroV2
{
    class AllSubsetsHavingSumZeroV2
    {
        static void Main()
        {
            byte numbersCount = 5;
            int[] numbers = new int[numbersCount];
            List<int[]> subsets = new List<int[]>();

            for (byte i = 0; i < numbersCount; i++)
            {
                do
                {
                    Console.WriteLine("Please, enter integer number {0}: ", i + 1);
                } while (int.TryParse(Console.ReadLine(), out numbers[i]) == false);
            }

            Console.WriteLine("Subsets of {" + string.Join(", ", numbers.Select(x => x.ToString()).ToArray()) + "}, whose sum is 0:");

            subsets = FindSubsets(numbers);

            foreach (int[] subset in subsets)
            {
                if (subset.Sum() == 0)
                {
                    Console.WriteLine("{" + string.Join(", ", subset.Select(x => x.ToString()).ToArray()) + "}");
                }
            }
        }

        //all possible subsets of a given array
        static List<T[]> FindSubsets<T>(T[] originalArray)
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
