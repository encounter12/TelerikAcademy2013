using System;
using System.Collections.Generic;

class LeastMajorityMultiple
{
    static void Main()
    {
        List<int> numbersList = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            numbersList.Add(int.Parse(Console.ReadLine()));
        }

        List<List<int>> subsets = GetSubsets(numbersList, 3);

        int leastMajorityMultiple = int.MaxValue;

        foreach (List<int> subset in subsets)
        {
            int leastCommonMultiple = LeastCommonMultiple(LeastCommonMultiple(subset[0], subset[1]), subset[2]);

            if (leastCommonMultiple < leastMajorityMultiple)
            {
                leastMajorityMultiple = leastCommonMultiple;
            }
           
        }

        Console.WriteLine(leastMajorityMultiple);
    }

    private static int LeastCommonMultiple(int number01, int number02)
    {
        int leastCommonMultiple = (number01 * number02) / GreatestCommonDivisor(number01, number02);
        return leastCommonMultiple;
    }

    private static int GreatestCommonDivisor(int number01, int number02)
    {      
        int remainder = -1;
        int greatestCommonDivisor = 0;

        while (remainder != 0)
        {
            remainder = number01 % number02;

            if (remainder == 0)
            {
                greatestCommonDivisor = number02;
            }

            number01 = number02;
            number02 = remainder;
                       
        }
        return greatestCommonDivisor;
    }
    public static List<List<int>> GetSubsets(List<int> superSet, int subsetsLength)
    {
        List<List<int>> subsets = new List<List<int>>();

        GetSubsets(superSet, subsetsLength, 0, new List<int>(), subsets);

        return subsets;
    }

    private static void GetSubsets(List<int> superSet, int subsetsLength, int index, List<int> currentSubset, List<List<int>> solution)
    {
        // successful stop clause
        if (currentSubset.Count == subsetsLength)
        {
            solution.Add(new List<int>(currentSubset));

            return;
        }

        // unseccessful stop clause
        if (index == superSet.Count)
        {
            return;
        }

        int subset = superSet[index];
        currentSubset.Add(subset);

        // "guess" x is in the subset
        GetSubsets(superSet, subsetsLength, index + 1, currentSubset, solution);
        currentSubset.Remove(subset);

        // "guess" x is not in the subset
        GetSubsets(superSet, subsetsLength, index + 1, currentSubset, solution);
    }
}
