using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNumbersMinMaxValueV2
{
    class NDoubleNumbersMinMaxValue
    {
        static void SortNumbers(double[] numbersArray)
        {
            double temp = 0;
            for (int m = 0; m < numbersArray.Length - 1; m++)
            {
                for (int i = numbersArray.Length - 1; i > m; i--)
                {
                    if (numbersArray[i - 1] < numbersArray[i])
                    {
                        temp = numbersArray[i - 1];
                        numbersArray[i - 1] = numbersArray[i];
                        numbersArray[i] = temp;
                    }

                }
            }            
        }
 
        static void Main()
        {
            uint numbersCountN = 0;
            bool userInputCorrect = false;


            do
            {
                Console.WriteLine("Enter the total numbers count N:");
                userInputCorrect = uint.TryParse(Console.ReadLine(), out numbersCountN);
                if (!userInputCorrect)
                {
                    Console.WriteLine("You have entered incorrect number. Press any key to re-enter...");
                    Console.ReadKey();
                }

            } while (!userInputCorrect);

            userInputCorrect = false;

            double[] numbersArray = new double[numbersCountN];

            for (int i = 0; i < numbersCountN; i++)
            {
                do
                {
                    Console.WriteLine("Enter real number {0}:", i + 1);
                    userInputCorrect = double.TryParse(Console.ReadLine(), out numbersArray[i]);
                    if (!userInputCorrect)
                    {
                        Console.WriteLine("You have entered incorrect number. Press any key to re-enter...");
                        Console.ReadKey();
                    }

                } while (!userInputCorrect);
            }

            SortNumbers(numbersArray); 
       
            double maxValue = numbersArray[0];
            double minValue = numbersArray[numbersCountN - 1];

            Console.WriteLine("The largest number is: {0}", maxValue);
            Console.WriteLine("The smallest number is: {0}", minValue);

            /*foreach (double item in numbersArray)
            {
                Console.WriteLine(item);
            }*/
        }
    }
}
