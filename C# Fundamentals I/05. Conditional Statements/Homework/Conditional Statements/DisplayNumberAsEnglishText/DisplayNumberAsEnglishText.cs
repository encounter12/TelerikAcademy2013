using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayNumberAsEnglishText
{
    class DisplayNumberAsEnglishText
    {
        static void Main()
        {
            int number = 0;

            do
            {
                Console.WriteLine("Please, enter number between 0 and 999: ");
            } while (int.TryParse(Console.ReadLine(), out number) == false || number > 999);

            Console.WriteLine("The English name of {0} is {1}", number, ThreeDigitsNumberNameEn(number));
        }


        static string ThreeDigitsNumberNameEn(int number)
        {
            if (number > 999)
            {
                throw new Exception("Number is out of range");
            }

            string hundred = "hundred";
            string and = "and";

            string numberName = "";

            if (number <= 99)
            {
                numberName = TwoDigitsNumberNameEn(number);
            }
            else
            {
                numberName = TwoDigitsNumberNameEn(number / 100) + ' ' + hundred;

                //left over
                if ((number % 100) != 0)
                {
                    numberName += ' ' + and + ' ' + TwoDigitsNumberNameEn(number % 100);
                }
            }

            return numberName;
        }

   
        static string TwoDigitsNumberNameEn(int number)
        {
            if (number > 99)
            {
                throw new Exception("Number is out of range");
            }

            //digits names
            Dictionary<int, string> digitsNames = new Dictionary<int, string>();
            digitsNames.Add(0, "zero");
            digitsNames.Add(1, "one");
            digitsNames.Add(2, "two");
            digitsNames.Add(3, "three");
            digitsNames.Add(4, "four");
            digitsNames.Add(5, "five");
            digitsNames.Add(6, "six");
            digitsNames.Add(7, "seven");
            digitsNames.Add(8, "eight");
            digitsNames.Add(9, "nine");

            //tens names
            Dictionary<int, string> tensNames = new Dictionary<int, string>();
            tensNames.Add(10, "ten");
            tensNames.Add(11, "eleven");
            tensNames.Add(12, "twelve");
            tensNames.Add(13, "thirteen");
            tensNames.Add(14, "fourteen");
            tensNames.Add(15, "fifteen");
            tensNames.Add(16, "sixteen");
            tensNames.Add(17, "seventeen");
            tensNames.Add(18, "eighteen");
            tensNames.Add(19, "nineteen");
            tensNames.Add(20, "twenty");
            tensNames.Add(30, "thirty");
            tensNames.Add(40, "fourty");
            tensNames.Add(50, "fifty");
            tensNames.Add(60, "sixty");
            tensNames.Add(70, "seventy");
            tensNames.Add(80, "eighty");
            tensNames.Add(90, "ninety");

            string numberName = "";

            if (number >= 0 && number < 10)
            {
                numberName = digitsNames[number];
            }
            else if (number >= 10 && number < 20)
            {
                numberName = tensNames[number];
            }
            else
            {
                if ((number % 10) == 0)
                {
                    numberName = tensNames[(number / 10) * 10];
                }
                else
                {
                    numberName = tensNames[(number / 10) * 10] + '-' + digitsNames[number % 10];
                }
            }

            return numberName;
        }
    }
}
