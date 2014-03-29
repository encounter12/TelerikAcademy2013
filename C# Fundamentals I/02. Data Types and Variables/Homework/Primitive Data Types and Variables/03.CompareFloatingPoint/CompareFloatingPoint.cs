using System;

class CompareFloatingPoint
{
    static void Main()
    {
        Console.WriteLine("This program safely compares 2 floating-point numbers with precision of 0.000001");
        Console.Write("Please, writh the first number: ");
        float firstFloatNumber = float.Parse(Console.ReadLine());
        Console.Write("Please, writh the second number: ");
        float secondFloatNumber = float.Parse(Console.ReadLine());

        if (firstFloatNumber==secondFloatNumber)
        {
            Console.WriteLine("The two numbers ARE equal");
        }
        else
        {
            Console.WriteLine("The two numbers are NOT equal");
        }
        
    }
}
