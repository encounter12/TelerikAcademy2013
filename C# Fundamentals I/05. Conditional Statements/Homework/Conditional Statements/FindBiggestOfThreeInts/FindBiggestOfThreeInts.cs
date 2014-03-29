using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBiggestOfThreeInts
{
    class FindBiggestOfThreeInts
    {
        static void Main()
        {
            int numbersCount = 3;
            int[] intNumbers = new int[numbersCount];
            bool userInputCorrect = false;

            for (int i = 0; i < numbersCount; i++)
            {
                do
                {
                    Console.WriteLine("Enter integer number {0}:", i + 1);
                    userInputCorrect = int.TryParse(Console.ReadLine(), out intNumbers[i]);
                    if (!userInputCorrect)
                    {
                        Console.WriteLine("You have entered incorrect number. Press any key to re-enter..");
                        Console.ReadKey();
                    }
                } while (!userInputCorrect);               
            }

            Console.WriteLine();

            if (intNumbers[0] >= intNumbers[1])
            {
                if (intNumbers[1] >= intNumbers[2])
                {
                    Console.WriteLine("The biggest number is {0}", intNumbers[0]);
                }
                else
                {
                    if (intNumbers[0] >= intNumbers[2])
                    {
                        Console.WriteLine("The biggest number is {0}", intNumbers[0]);
                    }
                    else
                    {
                        Console.WriteLine("The biggest number is {0}", intNumbers[2]);
                    }
                }
            }
            else
            {
                if (intNumbers[1] <= intNumbers[2])
                {
                    Console.WriteLine("The biggest number is {0}", intNumbers[2]);
                }
                else
                {
                    Console.WriteLine("The biggest number is {0}", intNumbers[1]);
                }
            }
        }
    }
}
