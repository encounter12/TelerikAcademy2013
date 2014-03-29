using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeleteWordsStartingWithText
{
    class DeleteWordsStartingWithPrefix
    {
        static void Main(string[] args)
        {
            /*Write a program that deletes from a text file all words that start with the prefix "test". 
             * Words contain only the symbols 0...9, a...z, A…Z, _.*/

            string inputFilePath = @"..\..\InputOutput\Input.txt";
            string outputFilePath = @"..\..\InputOutput\Output.txt";
            StringBuilder sb = new StringBuilder();
            string content = "";

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                content = sb.Append(reader.ReadToEnd()).ToString();
            }

            string pattern = @"(\btest)\w+\b";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(content, replacement);
            //Console.WriteLine(result);

            using (StreamWriter outfile = new StreamWriter(outputFilePath))
            {
                outfile.Write(result);
            }
        }
    }
}
