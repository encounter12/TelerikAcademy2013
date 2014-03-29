using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] durankulakDigits = GetDurankulakDigits();

        string durankulakNumber = Console.ReadLine();

        List<uint> decimalRepresentations = GetDecimalRepresentations(durankulakNumber);
        foreach (var item in decimalRepresentations)
        {
            Console.WriteLine(item);
        }

    }

    static string[] GetDurankulakDigits()
    {
        string[] durankulakDigits = new string[168];

        for (int i = 0; i < 168; i++)
        {
            if (i < 26 )
            {
                durankulakDigits[i] = ((char)('A' + i)).ToString();
            }
            else if (i < 2 * 26)
            {
		        durankulakDigits[i] = "a" + durankulakDigits[i - 26];
            }
            else if (i < 3 * 26)
            {
                durankulakDigits[i] = "b" + durankulakDigits[i - 2 * 26];
            }
            else if (i < 4 * 26)
            {
                durankulakDigits[i] = "c" + durankulakDigits[i - 3 * 26];
            }
            else if (i < 5 * 26)
            {
                durankulakDigits[i] = "d" + durankulakDigits[i - 4 * 26];
            }
            else if (i < 6 * 26)
            {
                durankulakDigits[i] = "e" + durankulakDigits[i - 5 * 26];
            }
            else
            {
                durankulakDigits[i] = "f" + durankulakDigits[i - 6 * 26];
            }
        }
    }

    static List<uint> GetDecimalRepresentations(string[] durankulakDigits, string durankulakNumber)
    {
        List<uint> decimalRepresentations = new List<uint>();
        char buffer = new char(); // \0

        foreach (char symbol in durankulakNumber)
        {
            if (symbol >= 'A' && symbol <= 'Z')
            {
                string durankulakDigit = null;
                uint decimalRepresentation = 0;
                if (buffer != default(char))
                {
                    durankulakDigit = string.Format("{0}{1}", buffer, symbol);
                    decimalRepresentation = (uint)Array.IndexOf(durankulakDigits, durankulakDigits);
                    decimalRepresentations.Add(decimalRepresentation); 

                    buffer = default(char);
                }
                else
                {
                    durankulakDigit = symbol.ToString();
                }
		 
            }
            else
            {
                buffer = symbol;
            }
        }
    }

    static ulong GetDecimalNumber(List<uint> decimalRepresentations)
    {
        ulong result = 0;
        for (int i = 0; i < decimalRepresentations.Count; i++)
        {
            decimal
        }
    }

}

