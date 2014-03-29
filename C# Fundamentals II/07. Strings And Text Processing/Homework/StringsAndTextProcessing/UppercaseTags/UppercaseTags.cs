using System;
using System.Text.RegularExpressions;

class UppercaseTags
{
    /**
    * You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. 
    * The tags cannot be nested.
    */
    static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        Console.WriteLine(Uppercase(text));
    }

    public static string Uppercase(string input)
    {
        int start = 0;
        int end = 0;
        do
        {
            start = input.IndexOf("<upcase>", start) + 8;
            end = input.IndexOf("</upcase>", end + 8);
            if ((start >= 0) && (end >= 0))
            {
                input = input.Replace(input.Substring(start, end - start), input.Substring(start, end - start).ToUpper());
            }
        } while (start > 7);

        return Regex.Replace(input, @"<(.*?)>", "");
    }
}

