using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIntNumbersMinMaxValueV2
{
    class NIntNumbersMinMaxValueV2
    {
        static void SortNumbers(int[] numbersArray)
        {
            int temp = 0;
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

            int[] numbersArray = new int[numbersCountN];

            for (int i = 0; i < numbersCountN; i++)
            {
                do
                {
                    Console.WriteLine("Enter integer number {0}:", i + 1);
                    userInputCorrect = int.TryParse(Console.ReadLine(), out numbersArray[i]);
                    if (!userInputCorrect)
                    {
                        Console.WriteLine("You have entered incorrect number. Press any key to re-enter...");
                        Console.ReadKey();
                    }

                } while (!userInputCorrect);
            }

            SortNumbers(numbersArray); 
       
            int maxValue = numbersArray[0];
            int minValue = numbersArray[numbersCountN - 1];

            Console.WriteLine("The largest number is: {0}", maxValue);
            Console.WriteLine("The smallest number is: {0}", minValue);

            /*foreach (double item in numbersArray)
            {
                Console.WriteLine(item);
            }*/        
        }
    }
}
