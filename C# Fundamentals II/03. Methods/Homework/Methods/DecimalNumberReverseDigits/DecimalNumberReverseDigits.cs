using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalNumberReverseDigits
{
    class DecimalNumberReverseDigits
    {
        static void Main(string[] args)
        {
            int n = 123;
            Console.WriteLine(Reverse(n));
        }
        public static int Reverse(int number)
        {
            int reversed = 0;
            int check = number;
            int index = 0;
            do
            {
                index++;
                check = check / 10;
            } while (check != 0);
            for (int i = index - 1; i >= 0; i--)
            {
                reversed = reversed + number % 10 * (int)Math.Pow(10, i);
                number = number / 10;
            }
            return reversed;
        }
    }
}
