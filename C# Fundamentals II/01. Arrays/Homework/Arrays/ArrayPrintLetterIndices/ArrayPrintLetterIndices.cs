using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayPrintLetterIndices
{
    class ArrayPrintLetterIndices
    {
        static void Main(string[] args)
        {
            char[] alphabetArray = new char[26];

            int i = 0;
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                alphabetArray[i] = letter;
                i++;
            }

            Console.WriteLine("Enter word:");
            string word = Console.ReadLine();

            char[] wordArray = word.ToCharArray();

            for (int m = 0; m < wordArray.Length; m++)
            {
                for (int s = 0; s < alphabetArray.Length; s++)
                {
                    if (wordArray[m] == alphabetArray[s])
                    {
                        Console.Write("{0} ", s);
                    }
                }
            }
        }
    }
}
