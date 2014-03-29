using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGreatestOfFiveVariables
{
    class FindGreatestOfFiveVariables
    {
        static void Main()
        {
            int valuesNumber = 5;
            double[] values = new double[valuesNumber];
            bool userInputCorrect = false;
            double tempVariable = 0;

            for (int i = 0; i < values.Length; i++)
            {
                do
                {
                
                    Console.WriteLine("Enter value No.{0}: ", i + 1);
                    userInputCorrect = double.TryParse(Console.ReadLine(), out values[i]);
                    if (!userInputCorrect)
                    {
                        Console.WriteLine("You have entered incorrect number. Please re-enter");
                        Console.ReadKey();
                    }
              
                
                } while (!userInputCorrect);
            }

            for (int i = values.Length - 1; i >= 1; i--)
            {
                if (values[i] > values[i - 1])
                {
                    tempVariable = values[i - 1];
                    values[i - 1] = values[i];
                    values[i] = tempVariable;
                }
            }

            Console.WriteLine("Highest number is: {0}", values[0]);


        }
    }
}
