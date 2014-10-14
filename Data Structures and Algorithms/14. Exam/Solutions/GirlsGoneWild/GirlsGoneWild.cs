namespace GirlsGoneWild
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class GirlsGoneWild
    {
        public static void Main()
        {
            int shirtsNumber = int.Parse(Console.ReadLine());
            string skirtsLetters = Console.ReadLine();

            int girlsNumber = int.Parse(Console.ReadLine());

            List<string> skirtsSet = CreateSkirtsSet(skirtsLetters);
            List<string> shirtsSet = CreateShirtsSet(shirtsNumber);

            SortedSet<string> skirtsVariations = VariationsGenerator.GenerateVariations(skirtsSet, 2);
            SortedSet<string> shirtsVariations = VariationsGenerator.GenerateVariations(shirtsSet, 2);

            SortedSet<string> totalVariations = CreateTotalVariations(skirtsVariations, shirtsVariations);

        }

        static List<string> CreateShirtsSet(int shirtsNumber)
        {
            List<string> shirtsSet = new List<string>();

            for (int i = 0; i < shirtsNumber; i++)
            {
                shirtsSet.Add(i.ToString());
            }

            return shirtsSet;
        }

        static List<string> CreateSkirtsSet(string skirtsLetters)
        {
            string setElement;
            List<string> skirtsSet = new List<string>();

            for (int j = 0; j < skirtsLetters.Length; j++)
            {
                setElement = skirtsLetters[j].ToString();
                skirtsSet.Add(setElement);
            }

            skirtsSet.Sort();

            return skirtsSet;
        }

        static SortedSet<string> CreateTotalVariations(SortedSet<string> skirtsVariations, SortedSet<string> shirtsVariations)
        {
            SortedSet<string> totalVariation = new SortedSet<string>();

            foreach (var shirtsVariation in shirtsVariations)
            {
                string[] shirtsVariationString = shirtsVariation.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string totalVariationStr;

                foreach (var skirtVariation in skirtsVariations)
                {
                    totalVariationStr = "";
                    string[] skirtsVariationsString = skirtVariation.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < shirtsVariationString.Length; i++)
                    {
                        totalVariationStr += shirtsVariationString[i] + skirtsVariationsString[i] + "-";
                    }

                    totalVariationStr = totalVariationStr.Remove(totalVariationStr.Length - 1);
                    totalVariation.Add(totalVariationStr);
                }
            }

            return totalVariation;
        }
    }

    static class VariationsGenerator
    {
        static int[] arr;
        static bool[] used;

        public static SortedSet<string> GenerateVariations(List<string> set, int k)
        {
            arr = new int[k];
            int n = set.Count;
            used = new bool[n];
            SortedSet<string> variations = new SortedSet<string>();
            GenerateVariationsNoRepetitions(0, n, k, variations, set);
            return variations;
        }

        static void GenerateVariationsNoRepetitions(int index, int n, int k, SortedSet<string> variations, List<string> set)
        {
            if (index >= k)
            {
                variations.Add(PrintVariations(set));
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateVariationsNoRepetitions(index + 1, n, k, variations, set);
                        used[i] = false;
                    }
                }
            }
        }

        static string PrintVariations(List<string> set)
        {
            string variationString = "";

            for (int i = 0; i < arr.Length; i++)
            {
                variationString += set[arr[i]] + " ";
            }
            return variationString;
        }
    }
}