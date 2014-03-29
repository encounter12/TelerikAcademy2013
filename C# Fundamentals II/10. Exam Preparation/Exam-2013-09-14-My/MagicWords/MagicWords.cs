using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MagicWords
{
    static void ReorderWords(List<string> inputWordsList, int wordsNumber)
    {
        for (int i = 0; i < wordsNumber; i++)
        {
            int oldIndex = i;
            int newIndex = inputWordsList[i].Length % (wordsNumber + 1);
            if (newIndex < 0)
            {
                newIndex = 0;
            }

            inputWordsList.Insert(newIndex, inputWordsList[i]);
            if (newIndex < oldIndex)
            {
                oldIndex += 1;
            }
            inputWordsList.RemoveAt(oldIndex);
        }
    }

    static void PrintMagicWords(List<string> reorderedWordsList)
    {
        int wordsMaxLength = reorderedWordsList.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length;
        StringBuilder sb = new StringBuilder();
                
        for (int i = 0; i < wordsMaxLength; i++)
        {
            for (int j = 0; j < reorderedWordsList.Count; j++)
            {
                if (reorderedWordsList[j].Length > i)
                {
                    sb.Append(reorderedWordsList[j][i].ToString());
                }                
            }
        }
        
        Console.Write(sb.ToString());
    }
    static void Main()
    {
        List<string> wordsList = new List<string>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            wordsList.Add(Console.ReadLine());
        }

        ReorderWords(wordsList, n);

        PrintMagicWords(wordsList);
    }   
}

