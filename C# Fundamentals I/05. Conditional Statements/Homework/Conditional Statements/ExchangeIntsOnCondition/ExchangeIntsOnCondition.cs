using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalStatements
{
    class ExchangeIntsOnCondition
    {
        static void Main()
        {
            /*This program reads two integers from the console and exchanges their values if the first one is greater than the second one.*/

            Console.WriteLine("Enter first integer x:");
            int intNumber01 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second integer y:");
            int intNumber02 = int.Parse(Console.ReadLine());
            int tempIntVariable = 0;

            if (intNumber01 > intNumber02)
            {
                tempIntVariable = intNumber01;
                intNumber01 = intNumber02;
                intNumber02 = tempIntVariable;

            }
            
            Console.WriteLine("First integer x:{0}, Second integer y:{1}", intNumber01, intNumber02);

        }
    }
}
