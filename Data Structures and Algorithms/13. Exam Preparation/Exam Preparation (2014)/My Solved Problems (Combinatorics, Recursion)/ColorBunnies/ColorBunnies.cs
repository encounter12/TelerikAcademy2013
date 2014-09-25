namespace ColorBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ColorBunnies
    {
        static void Main()
        {
            int askedBunnies = int.Parse(Console.ReadLine());

            Dictionary<int, int> equalBunniesNumberSets = new Dictionary<int, int>(); 

            for (int i = 0; i < askedBunnies; i++)
            {
                int currentBunniesSetCount = int.Parse(Console.ReadLine()) + 1;
                if (equalBunniesNumberSets.ContainsKey(currentBunniesSetCount))
                {
                    equalBunniesNumberSets[currentBunniesSetCount]++;
                }
                else
                {
                    equalBunniesNumberSets.Add(currentBunniesSetCount, 1);
                }               
            }

            int totalMinimumBunniesCount = 0;

            foreach(var bunniesSet in equalBunniesNumberSets)
            {
                int currentBunniesSetCount = bunniesSet.Key;
                int askedBunniesWithEqualSets = bunniesSet.Value;
                totalMinimumBunniesCount += (int)Math.Ceiling(askedBunniesWithEqualSets / (double)currentBunniesSetCount) * 
                    currentBunniesSetCount;
            }

            Console.WriteLine(totalMinimumBunniesCount);
        }
    }
}