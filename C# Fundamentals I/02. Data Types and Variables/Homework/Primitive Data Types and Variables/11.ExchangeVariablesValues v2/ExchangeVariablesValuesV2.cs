using System;


namespace ExchangeVariablesValues
{
    class ExchangeVariablesValuesV2
    {
        static void Main()
        {
            Console.WriteLine("THIS PROGRAM REPLACES THE VALUES OF TWO VARIABLES\n");
            Console.WriteLine("myFirstVariable:");
            float myFirstVariable = Single.Parse(Console.ReadLine());
            Console.WriteLine("mySecond Variable:");
            float mySecondVariable = Single.Parse(Console.ReadLine());          
            float tempVariable = 0;
            tempVariable = myFirstVariable;
            myFirstVariable = mySecondVariable;
            mySecondVariable = tempVariable;
            Console.WriteLine();
            Console.WriteLine("myFirstVariable = {0}\nmySecondVariable = {1}", myFirstVariable, mySecondVariable);

        }
    }
}
