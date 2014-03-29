using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertShortToBinary
{
    class ConvertShortToBinary
    {
        public static string GetShortBinaryString(short shortDecimalNumber)
        {
            int bitsNumber = 16;
            char[] binaryArray = new char[bitsNumber];

            for (int position = 0; position < bitsNumber; position++)
            {
                if ((shortDecimalNumber & (1 << position)) != 0)
                {
                    binaryArray[bitsNumber - position - 1] = '1';
                }
                else
                {
                    binaryArray[bitsNumber - position - 1] = '0';
                }
            }
            return new string(binaryArray).TrimStart('0');
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Write decimal number of type short:");
            short shortDecimalNumber = short.Parse(Console.ReadLine());

            string binaryString = GetShortBinaryString(shortDecimalNumber);

            Console.WriteLine("Binary representation:");
            Console.WriteLine(binaryString);
                     
        }
    }
}
