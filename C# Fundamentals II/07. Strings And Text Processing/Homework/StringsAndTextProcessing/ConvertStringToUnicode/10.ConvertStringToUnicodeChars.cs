using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertStringToUnicode
{
    class ConvertStringToUnicode
    {
        /*Write a program that converts a string to a sequence of C# Unicode character literals. 
         * Use format strings. Sample input: Hi! ; Expected output: \u0048\u0069\u0021*/

        static void Main(string[] args)
        {
            
            string text = "Hi!";
            Console.WriteLine(text);

            foreach (char symbol in text)
            {
                Console.Write(@"\u{0:X4} ", (int)symbol);
            }
            Console.WriteLine();

            /*The above loop could be replaced with:
                StringBuilder sb = new StringBuilder();
                foreach (char symbol in text)
                {
                    sb.Append(@"\u").Append(String.Format("{0:X4}", (int)symbol)).Append(" ");
                }
                string resultString = sb.ToString().Trim();
                Console.WriteLine(resultString);
             * */
        }
    }
}
