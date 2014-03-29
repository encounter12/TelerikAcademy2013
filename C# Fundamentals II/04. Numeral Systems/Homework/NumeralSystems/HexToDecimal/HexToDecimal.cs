using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexToDecimal
{
    class HexToDecimal
    {
        /**
         * Write a program to convert hexadecimal numbers to their decimal representation.
         */
        static void Main(string[] args)
        {
            string hexNumberOne = "F00";
            string hexNumberTwo = "BAA";
            string hexNumberThree = "123ABC";

            //two ways of conversion - custom method and with Convert
            Console.WriteLine(hexNumberOne + ": " + HexToInt(hexNumberOne) + " " + Convert.ToInt32(hexNumberOne, 16));
            Console.WriteLine(hexNumberTwo + ": " + HexToInt(hexNumberTwo) + " " + Convert.ToInt32(hexNumberTwo, 16));
            Console.WriteLine(hexNumberThree + ": " + HexToInt(hexNumberThree) + " " + Convert.ToInt32(hexNumberThree, 16));
        }

        public static int HexToInt(string hexNumber)
        {
            int decimalNumber = 0;
            int powerOf16 = 1;

            for (int i = hexNumber.Length - 1; i >= 0; i--)
            {
                decimalNumber += HexDigitToDecimalDigit(hexNumber[i]) * powerOf16;
                powerOf16 *= 16;
            }

            return decimalNumber;
        }

        public static int HexDigitToDecimalDigit(char digit)
        {
            if (digit >= 'A')
            {
                return digit - 'A' + 10;
            }
            else
            {
                return digit - '0';
            }
        }
    }
}
