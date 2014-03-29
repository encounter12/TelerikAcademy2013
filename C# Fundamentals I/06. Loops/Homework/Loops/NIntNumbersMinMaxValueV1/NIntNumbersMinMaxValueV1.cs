using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNumbersMinMaxValue
{
    class NIntNumbersMinMaxValueV1
    {
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

            int[] intArray = new int[numbersCountN];

            for (int i = 0; i < numbersCountN; i++)
            {
                do
                {
                    Console.WriteLine("Enter number {0}:", i + 1);
                    userInputCorrect = int.TryParse(Console.ReadLine(), out intArray[i]);
                    if (!userInputCorrect)
                    {
                        Console.WriteLine("You have entered incorrect number. Press any key to re-enter...");
                        Console.ReadKey();
                    }
                    
                } while (!userInputCorrect);               
            }


            int temp = 0;
            for (uint i = numbersCountN - 1; i > 0; i--)
            {
                if (intArray[i - 1] < intArray[i] )
                {
                    temp = intArray[i - 1];
                    intArray[i - 1] = intArray[i];
                    intArray[i] = temp;
                }
            }

            int maxValue = intArray[0];

            for (uint i = 0; i < numbersCountN - 1; i++)
            {
                if (intArray[i] < intArray[i + 1] )
                {
                    temp = intArray[i + 1];
                    intArray[i + 1] = intArray[i];
                    intArray[i] = temp;
                }
            }

            int minValue = intArray[numbersCountN - 1];

            Console.WriteLine("The largest number is: {0}", maxValue);
            Console.WriteLine("The smallest number is: {0}", minValue);

        }
    }
}
