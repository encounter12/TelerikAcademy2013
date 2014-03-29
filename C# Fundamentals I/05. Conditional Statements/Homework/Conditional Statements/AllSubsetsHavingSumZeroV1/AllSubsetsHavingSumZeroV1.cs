using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSubsetsHavingSumZeroV1
{
    class AllSubsetsHavingSumZeroV1
    {
        static List<List<int>> FindAllSubsets(int[] setArray)
        {
            List<List<int>> subsetsList = new List<List<int>>();
            int variablesNumber = setArray.Length;
            for (int i = 1; i < Math.Pow(2, variablesNumber); i++)
            {
                List<int> subset = new List<int>();

                for (int m = 0; m < variablesNumber; m++)
                {
                    int mask = 1 << m;
                    int nAndMask = i & mask;
                    int bitValue = nAndMask >> m;

                    if (bitValue == 1)
                    {
                        subset.Add(setArray[m]);
                    }
                }
                subsetsList.Add(subset);
            }
            return subsetsList;
        }
        static List<List<int>> FindAllSubsetsHavingGivenSum(int[] setArray, int sum)
        {
            List<List<int>> subsetsListHavingGivenSum = new List<List<int>>();
            int variablesNumber = setArray.Length;
            for (int i = 1; i < Math.Pow(2, variablesNumber); i++)
            {
                List<int> subset = new List<int>();

                for (int m = 0; m < variablesNumber; m++)
                {
                    int mask = 1 << m;
                    int nAndMask = i & mask;
                    int bitValue = nAndMask >> m;

                    if (bitValue == 1)
                    {
                        subset.Add(setArray[m]);
                    }
                }
                if (subset.Sum() == sum)
                {
                    subsetsListHavingGivenSum.Add(subset);
                }               
            }
           
            return subsetsListHavingGivenSum;
        }

        static List<List<int>> FindAllSubsetsWithGivenLength(int[] setArray, int subsetsLength)
        {
            List<List<int>> subsetsListWithGivenLength = new List<List<int>>();
            int variablesNumber = setArray.Length;
            for (int i = 1; i < Math.Pow(2, variablesNumber); i++)
            {
                List<int> subset = new List<int>();

                for (int m = 0; m < variablesNumber; m++)
                {
                    int mask = 1 << m;
                    int nAndMask = i & mask;
                    int bitValue = nAndMask >> m;

                    if (bitValue == 1)
                    {
                        subset.Add(setArray[m]);
                    }
                }
                if (subset.Count == subsetsLength)
                {
                    subsetsListWithGivenLength.Add(subset);
                }
            }

            return subsetsListWithGivenLength;
        }
        static void Main()
        {
            int variablesNumber = 5;
            int[] setArray = new int[variablesNumber];
            bool userInputCorrect = false;

            for (int i = 0; i < variablesNumber; i++)
            {
                do
                {
                    Console.WriteLine("Enter number {0}:", i + 1);
                    userInputCorrect = int.TryParse(Console.ReadLine(), out setArray[i]);
                    if (!userInputCorrect)
                    {
                        Console.WriteLine("You have entered incorrect number. Press any key to re-enter...");
                        Console.ReadKey();
                    }

                } while (!userInputCorrect);

            }

            Console.WriteLine("Enter the subset sum:");
            int sum = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter subset length 0 < L <= {0}:", variablesNumber);
            int subsetsLength = int.Parse(Console.ReadLine());

            List<List<int>> subsetsList = FindAllSubsets(setArray);

            Console.WriteLine("All the subsets of the given set are:");

            foreach (List<int> memberSubset in subsetsList)
            {
                foreach (int subsetElements in memberSubset)
                {
                    Console.Write("{0} ", subsetElements);
                }
                Console.WriteLine();
            }

            Console.WriteLine("All the subsets having sum = {0} are:", sum);

            List<List<int>> subsetsListHavingGivenSum = FindAllSubsetsHavingGivenSum(setArray, sum);

            foreach (List<int> memberSubset in subsetsListHavingGivenSum)
            {
                foreach (int subsetElements in memberSubset)
                {
                    Console.Write("{0} ", subsetElements);
                }
                Console.WriteLine();
            }

            List<List<int>> subsetsListWithGivenLength = FindAllSubsetsWithGivenLength(setArray, subsetsLength);

            Console.WriteLine("All the subsets with length {0} are:", subsetsLength);

            foreach (List<int> memberSubset in subsetsListWithGivenLength)
            {
                foreach (int subsetElements in memberSubset)
                {
                    Console.Write("{0} ", subsetElements);
                }
                Console.WriteLine();
            }

        }
    }
}
