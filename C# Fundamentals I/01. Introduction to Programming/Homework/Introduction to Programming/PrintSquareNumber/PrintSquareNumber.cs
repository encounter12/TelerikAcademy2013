using System;

class PrintSquareNumber
{
    static double CalculateSquareNumber(int number)
    {
        double squareNumber = Math.Pow(number, 2);
        return squareNumber;
    }
    static void Main()
    {
        int number = 12345;
        double squareNumber = CalculateSquareNumber(number);
        Console.WriteLine("{0} * {0} = {1}", number, squareNumber);
    }
}
