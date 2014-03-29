using System;

class GreedyDwarf
{
    static void ConvertStringToIntArray(string str, string[] separator, out int[] intArray)
    {
        intArray = Array.ConvertAll(str.Split(separator, StringSplitOptions.None), element => int.Parse(element));
    }
    static void Main()
    {
        
        string[] separatorString = new string[] { ", " };
        int[] valley;

        string valleyString = Console.ReadLine();
        ConvertStringToIntArray(valleyString, separatorString, out valley);

        int m = int.Parse(Console.ReadLine());
        int[][] patterns = new int[m][];

        for (int i = 0; i < m; i++)
        {
            string patternString = Console.ReadLine();
            ConvertStringToIntArray(patternString, separatorString, out patterns[i]);
        }
       
        int maxCoins = int.MinValue;
        
        for (int i = 0; i < m; i++)
        {
            bool[] valleyCellsVisited = new bool[valley.Length];
            int valleyIndex = 0;
            int patternIndex = 0;
            int currentPatternCoins = 0;

            while (true)
            {
                if (patternIndex == patterns[i].Length)
                {
                    patternIndex = 0;
                }

                if (valleyIndex < 0 || valleyIndex >= valley.Length)
                {
                    break;
                }
                else if (valleyCellsVisited[valleyIndex] == true)
                {
                    break;
                }

                currentPatternCoins += valley[valleyIndex];
                valleyCellsVisited[valleyIndex] = true;
                valleyIndex += patterns[i][patternIndex];
                patternIndex++;
                
            }

            if (currentPatternCoins > maxCoins)
            {
                maxCoins = currentPatternCoins;
            }
        }
      
        Console.WriteLine(maxCoins);
    }
}