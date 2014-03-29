using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter word which letters will be the 1st char array elements:");
        string firstString = Console.ReadLine();
        Console.WriteLine("Enter word which letters will be the 2nd char array elements:");
        string secondString = Console.ReadLine();

        char[] chars01 = firstString.ToCharArray();
        char[] chars02 = secondString.ToCharArray();
        int MinCharsNumber = Math.Min(chars01.Length, chars02.Length);
        bool chars01LexicographicallyHigher = false;
        bool arraysLexicographicallyEqual = false;

        for (int i = 0; i < MinCharsNumber; i++)
        {
            if (chars01[i] > chars02[i])
            {
                chars01LexicographicallyHigher = false;
                break;
            }
            else if (chars01[i] < chars02[i])
            {
                chars01LexicographicallyHigher = true;
                break;
            }
            else if(i == MinCharsNumber - 1 && chars01.Length == chars02.Length)
            {
                arraysLexicographicallyEqual = true;
            }
            else if(i == MinCharsNumber - 1 && chars01.Length < chars02.Length)
            {
                chars01LexicographicallyHigher = true;
            }
            else
            {
                chars01LexicographicallyHigher = false;
            }
        }

        if (arraysLexicographicallyEqual)
        {
            Console.WriteLine("Char array \"{0}\" is lexicographically equal to \"{1}\"", firstString, secondString);
        }
        else if (chars01LexicographicallyHigher)
        {
            Console.WriteLine("Char array \"{0}\" lexicographically precedes \"{1}\"", firstString, secondString);
        }
        else
        {
            Console.WriteLine("Char array \"{0}\" lexicographically precedes \"{1}\"", secondString, firstString);
        }
    }
}
