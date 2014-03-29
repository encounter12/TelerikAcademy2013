using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignOfThreeRealNumbersProduct
{
    class SignOfThreeRealNumbersProduct
    {
        static void DisplayProductSign(int negativeNumbersCount)
        {
            if (negativeNumbersCount % 2 == 0)
            {
                Console.WriteLine("The product has a sign +");
            }
            else
            {
                Console.WriteLine("The product has a sign -");
            }
        }
        static void Main()
        {
            int numbersCount = 3;
            float[] realNumbers = new float[numbersCount];
            int negativeNumbersCount = 0;
            bool userInputCorrect = false;
            for (int i = 0; i < numbersCount; i++)
			{
                do
                {
                    Console.WriteLine("Enter real number {0}:", i + 1);
                    userInputCorrect = float.TryParse(Console.ReadLine(), out realNumbers[i]);
                    if (!userInputCorrect)
                    {
                        Console.WriteLine("You have entered incorrect number. Press any key to re-enter..");
                        Console.ReadKey();
                    }
                } while (!userInputCorrect);
			}

            for (int i = 0; i < numbersCount; i++)
            {
                if (realNumbers[i]==0)
                {
                    Console.WriteLine("The product is 0");
                    break;
                }
                else if (realNumbers[i] < 0)
                {
                    negativeNumbersCount++;
                }
            }
            
            DisplayProductSign(negativeNumbersCount);                      
        }
    }
}
