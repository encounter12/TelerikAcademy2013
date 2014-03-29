using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSumOfNNumbers
{
    class CalculateSumOfNNumbers
    {
        static void Main()
        {
            
            Console.WriteLine("PRINT SUM OF N INTEGERS");
            Console.WriteLine("This program reads N integers from the console and prints their sum");
            

            uint n = 0;
            bool userInputCorrect = false;
            do
            {
                Console.WriteLine("Enter number of integers n to be summed up:");
                userInputCorrect = uint.TryParse(Console.ReadLine(), out n);
                if (!userInputCorrect)
                {
                    Console.WriteLine("You have entered incorrect number n. Press Enter to type it again...");
                    Console.ReadLine();
                }

            } while (!userInputCorrect);        

            int[] intArray = new int[n];

            for (uint i = 0; i < n; i++)
            {
                do
                {

                    Console.WriteLine("Enter integer No.{0}:", i + 1);
                    userInputCorrect = int.TryParse(Console.ReadLine(), out intArray[i]);
                    if (!userInputCorrect)
                    {
                        Console.WriteLine("You have entered incorrect type. Please re-enter...");
                        Console.ReadLine();
                    }
                } while (!userInputCorrect);
            }


            int sum = 0;
            for (uint i = 0; i < n; i++)
            {
                sum += intArray[i];
            }

            Console.Write("{0}", intArray[0]);

            for (uint i = 1; i < n; i++)
            {
                Console.Write(" + {0}", intArray[i]);
            }

            Console.WriteLine(" = {0}", sum);

        }
    }
}
