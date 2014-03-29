using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInputOutput
{
    class PrintSumOfThreeIntegers
    {
        static void Main()
        {
            int n = 3;
            Console.WriteLine("PRINT SUM OF {0} INTEGERS", n);
            Console.WriteLine("This program reads {0} integers from the console and prints their sum", n);
           
            int[] intArray = new int[n];
            bool userInputCorrect = false;

            //Initializes the integers values (validation included)
            for (int i = 0; i < n; i++) 
            {
                do
                {                   
                   
                    Console.WriteLine("Enter integer No.{0}:", i+1);
                    userInputCorrect = int.TryParse(Console.ReadLine(), out intArray[i]);
                    if (!userInputCorrect)
                    {
                        Console.WriteLine("You have entered incorrect type. Please re-enter...");
                        Console.ReadLine();
                    }
                } while (!userInputCorrect);
            }

            //Performs the summing
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += intArray[i];
            }

            //Displays the sum on the console
            Console.Write("{0} ", intArray[0]);

            for (int i = 1; i < n; i++)
			{
			    Console.Write("+ {0} ", intArray[i]);
			}

            Console.WriteLine(" = {0}", sum);

        }
    }
}
