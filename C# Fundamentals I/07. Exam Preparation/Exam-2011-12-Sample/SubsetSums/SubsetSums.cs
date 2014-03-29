using System;
using System.Collections.Generic;
using System.Linq;

class SubsetSums
{
    static void Main()
    {
        long sumS = long.Parse(Console.ReadLine());
        int variablesNumberN = int.Parse(Console.ReadLine());
        long[] setArray = new long[variablesNumberN];

        for (int i = 0; i < variablesNumberN; i++)
        {
            setArray[i] = long.Parse(Console.ReadLine());
        }

        List<List<long>> subsetsListHavingGivenSum = FindAllSubsetsHavingGivenSum(setArray, sumS);

        Console.WriteLine(subsetsListHavingGivenSum.Count);
    }

    static List<List<long>> FindAllSubsetsHavingGivenSum(long[] setArray, long sum)
    {
        List<List<long>> subsetsListHavingGivenSum = new List<List<long>>();
        int variablesNumber = setArray.Length;
        for (int i = 1; i < Math.Pow(2, variablesNumber); i++)
        {
            List<long> subset = new List<long>();

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
            if (subset.Sum() == sum) //fore the Sum extension method the directive System.Linq should be added
            {
                subsetsListHavingGivenSum.Add(subset);
            }
        }

        return subsetsListHavingGivenSum;
    }
}