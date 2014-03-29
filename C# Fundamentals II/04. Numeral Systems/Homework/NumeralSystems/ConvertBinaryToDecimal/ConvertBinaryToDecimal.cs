using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeralSystems
{
    class ConvertBinaryToDecimal
    {
        public static int ConvertBinToDecimal(string binaryString)
        {
            int intDigit;
            int decimalNumber = 0;

            for (int i = binaryString.Length - 1; i >= 0; i--)
            {
                intDigit = binaryString[i] - '0';
                decimalNumber += intDigit * (int)Math.Pow(2, binaryString.Length - 1 - i);
            }

            return decimalNumber;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter binary number:");
            string binaryString = Console.ReadLine();
            int decimalNumber = ConvertBinToDecimal(binaryString);

            Console.WriteLine("Decimal representation: {0}", decimalNumber);
        }
    }
}
