using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class SortListOfWords
{
    //Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order

    static void Main()
    {
        string text = "Lorem ipsum Dolor, Sit-amet.";

        List<string> words = new List<string>();
        foreach (Match word in Regex.Matches(text, @"\w+"))
        {
            words.Add(word.Value);
        }

        words.Sort();

        Console.WriteLine(String.Join(" ", words));
    }
}

