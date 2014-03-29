using System;

namespace ExchangeVariablesValues
{
    class ExchangeVariablesValuesV1
    {
        static void Main()
        {
            Console.WriteLine("THIS PROGRAM REPLACES TWO VARIABLES VALUES\n");
            int myFirstVariable = 5;
            Console.WriteLine("myFirstVariable = {0}", myFirstVariable);
            int mySecondVariable = 10;
            Console.WriteLine("mySecondVariable = {0}", mySecondVariable);
            int tempVariable = 0;
            tempVariable = myFirstVariable;
            myFirstVariable = mySecondVariable;
            mySecondVariable = tempVariable;
            Console.ReadLine();
            Console.WriteLine("myFirstVariable = {0}\nmySecondVariable = {1}", myFirstVariable, mySecondVariable);
        }
    }
}
