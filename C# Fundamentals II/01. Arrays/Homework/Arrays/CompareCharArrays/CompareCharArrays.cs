using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareCharArrays
{
    enum precedence
    {
        Higher, 
        Lower,
        Equal
    }
    class CompareCharArrays
    {
        static precedence CompareCharArraysLexicographically(string firstString, string secondString)
        {
            char[] chars01 = firstString.ToCharArray();
            char[] chars02 = secondString.ToCharArray();
            int MinCharsNumber = Math.Min(chars01.Length, chars02.Length);
            precedence arrayPrecedence = precedence.Equal;

            for (int i = 0; i < MinCharsNumber; i++)
            {
                if (chars01[i] > chars02[i])
                {
                    arrayPrecedence = precedence.Lower;
                    break;
                }
                else if (chars01[i] < chars02[i])
                {
                    arrayPrecedence = precedence.Higher;
                    break;
                }
                else if (i == MinCharsNumber - 1 && chars01.Length == chars02.Length)
                {
                    arrayPrecedence = precedence.Equal;
                }
                else if (i == MinCharsNumber - 1 && chars01.Length < chars02.Length)
                {
                    arrayPrecedence = precedence.Higher;
                }
                else
                {
                    arrayPrecedence = precedence.Lower;
                }
            }
            return arrayPrecedence;
        }
        static void Main()
        {                       
            Console.WriteLine("Enter word which letters will be the 1st char array elements:");
            string firstString = Console.ReadLine();
            Console.WriteLine("Enter word which letters will be the 2nd char array elements:");
            string secondString = Console.ReadLine();
            precedence arrayPrecedence = CompareCharArraysLexicographically(firstString, secondString);
           
            if (arrayPrecedence == precedence.Higher)
            {
                Console.WriteLine("Char array \"{0}\" lexicographically precedes \"{1}\"", firstString, secondString);
            }
            else if (arrayPrecedence == precedence.Lower)
            {
                Console.WriteLine("Char array \"{0}\" lexicographically precedes \"{1}\"", secondString, firstString);
            }
            else
            {
                Console.WriteLine("Char array \"{0}\"  lexicographically equals \"{1}\"", firstString, secondString);
            }
        }
    }
}
