using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertHexToBinaryDirectly
{
    class ConvertHexToBinaryDirectly
    {
        public static string ConverHexToBinDirectly(string hexString)
        {
            string binaryString = "";
            Dictionary<char, string> hexBinary = new Dictionary<char, string>()
	        {
	            {'0', "0000"}, {'1', "0001"}, {'2', "0010"}, {'3', "0011"},
                {'4', "0100"}, {'5', "0101"}, {'6', "0110"}, {'7', "0111"},
                {'8', "1000"}, {'9', "1001"}, {'A', "1010"}, {'B', "1011"},
                {'C', "1100"}, {'D', "1101"}, {'E', "1110"}, {'F', "1111"}

	        };

            foreach (char symbol in hexString)
            {
                binaryString += hexBinary[symbol];
            }

            return binaryString.TrimStart('0');
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter hexadecimal number:");
            string hexString = Console.ReadLine();

            string binaryString = ConverHexToBinDirectly(hexString);
            Console.WriteLine("Binary representation: {0}", binaryString);
        }
    }
}
