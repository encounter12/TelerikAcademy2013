using System;

class IntIsOddOrEven
{
    static void Main()
    {
        Console.WriteLine("This program checks if a given integer is odd or even");
        Console.WriteLine("Please, enter an integer: ");
        int myInt = Int32.Parse(Console.ReadLine());

        if (myInt % 2 == 0)
        {
            Console.WriteLine("This integer is even");
        }
        else
        {
            Console.WriteLine("This integer is odd");
        }           
    }
}

