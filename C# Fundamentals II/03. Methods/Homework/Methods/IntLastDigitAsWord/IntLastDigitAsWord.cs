using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class IntLastDigitAsWord
    {
        public static string DisplayIntNthDigitAsWord(int inputNumber, int digitPosition)
        {
            string[] digitsStrings = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            int nthDigit = Math.Abs((inputNumber / (int)Math.Pow(10, digitPosition)) % 10);
            return digitsStrings[nthDigit];
        }
        static void Main(string[] args)
        {
            /*Write a method that returns the last digit of given integer as an English word. 
             * Examples: 512 - "two", 1024 - "four", 12309 - "nine".*/

            Console.WriteLine("Enter an integer:");
            int inputNumber = int.Parse(Console.ReadLine());
            int digitPosition = 0;
            
            string nthDigitWord = DisplayIntNthDigitAsWord(inputNumber, digitPosition);

            Console.WriteLine("Last digit: {0}",nthDigitWord);
        }        
    }
}
