using System;

class FindTrapezoidArea
{
    static void Main()
    {
        Console.WriteLine("THIS PROGRAM CALCULATES THE AREA OF TRAPEZOID");
        Console.WriteLine("Please enter side A:");
        float sideA = Single.Parse(Console.ReadLine());
        Console.WriteLine("Please enter side B:");
        float sideB = Single.Parse(Console.ReadLine());
        Console.WriteLine("Please enter height H:");
        float heightH = Single.Parse(Console.ReadLine());
        double trapezoidArea = (sideA + sideB) * heightH / 2;
        Console.WriteLine("The trapezoid's area is S = (a + b) * h / 2 = {0}", trapezoidArea);
    }
}

