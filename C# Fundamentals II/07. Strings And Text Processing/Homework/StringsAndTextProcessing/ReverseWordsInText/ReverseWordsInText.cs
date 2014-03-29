using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReverseWordsInText
{
    class ReverseWordsInText
    {
        /*Write a program that reverses the words in given sentence.
         * Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".*/
       
        static void Main(string[] args)
        {
            string text = "C# is not C++, not PHP and not Delphi!";
            Console.WriteLine(text);
            string reversedWords = ReverseWords(text);
            Console.WriteLine(reversedWords);
        }

        public static string ReverseWords(string text)
        {
            string regex = @"\s+|,\s*|\.\s*|!\s*";
            List<string> words = new List<string>();
            List<string> separators = new List<string>();

            foreach (string word in Regex.Split(text, regex))
            {
                words.Add(word);
            }


            foreach (Match separator in Regex.Matches(text, regex))
            {
                separators.Add(separator.Value);
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < separators.Count; i++)
            {
                sb.Append(words[words.Count - 2 - i]).Append(separators[i]);
            }
            return sb.ToString();
        }
    }
}
