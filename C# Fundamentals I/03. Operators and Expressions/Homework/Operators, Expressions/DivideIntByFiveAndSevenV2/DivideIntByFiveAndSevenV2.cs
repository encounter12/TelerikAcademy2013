using System;

class DivideIntByFiveAndSevenV2
{
    static void Main()
    {
        Console.WriteLine("This program displays if an integer could be divided by 5 and 7");
        Console.WriteLine("Please, type the number: ");
        int myInt = Int32.Parse(Console.ReadLine());
        if (myInt % 35 == 0)
        {
            Console.WriteLine("The number could be divided by 5 and 7 without remainder");
        }
        else
        {
            Console.WriteLine("The number could NOT be divided by 5 and 7 without remainder");
        }
    }
}

