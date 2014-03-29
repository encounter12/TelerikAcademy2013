using System;
using System.Collections.Generic;
using System.Linq;

//this solution gives no time out compared to V1
class OddNumberV2
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<long, int> numbersOccurrenceCount = new Dictionary<long, int>();
        long oddNumber = 0;

        for (int i = 0; i < n; i++)
        {
            long number = long.Parse(Console.ReadLine());

            if (numbersOccurrenceCount.ContainsKey(number))
            {
                numbersOccurrenceCount[number] = numbersOccurrenceCount[number] + 1;
            }
            else
            {
                numbersOccurrenceCount.Add(number, 1);
            }
        }

        foreach (KeyValuePair<long, int> item in numbersOccurrenceCount)
        {
            if (item.Value % 2 != 0)
            {
                oddNumber = numbersOccurrenceCount.FirstOrDefault(x => x.Value == item.Value).Key;
                break;
            }
        }

        Console.WriteLine(oddNumber);  
    }
}