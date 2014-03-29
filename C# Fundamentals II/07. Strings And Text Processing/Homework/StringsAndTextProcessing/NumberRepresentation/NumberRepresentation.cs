using System;

class Program
{
    /**
    * Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation.
    * Format the output aligned right in 15 symbols.
    */
    static void Main()
    {
        int number = 85;
        Console.WriteLine("Decimal:\n{0,15}", number);
        Console.WriteLine("Hexadecimal:\n{0,15:X}", number);
        Console.WriteLine("Percentage:\n{0,15:P}", number);
        Console.WriteLine("Scientific:\n{0,15:E}", number);
    }
}

