using System;

class CalculateRectangleArea
{
    static void Main()
    {
        Console.WriteLine("THIS PROGRAM CALCULATES THE RECTANGLE AREA");
        Console.Write("Please, enter width: \n");
        double rectangleWidth = Double.Parse(Console.ReadLine());
        Console.Write("Please, enter height: \n");
        double rectangleHeight = Double.Parse(Console.ReadLine());
        double rectangleArea = rectangleWidth * rectangleHeight;
        Console.WriteLine("Rectangle Area S = width * height = {0} ", rectangleArea);
    }
}
