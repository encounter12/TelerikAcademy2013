using System;

class CheckIntThirdDigit
{
    static void Main()
    {
        Console.WriteLine("This program checks if an integer's 3-rd digit from right to left is 7");
        Console.Write("Please, enter an integer: ");
        int digitPosition = 3;
        bool myThirdDigitIsSeven = false;
        int myInt= Int32.Parse(Console.ReadLine());
        int myIntThirdDigit = (myInt / (int)Math.Pow(10, digitPosition - 1)) % 10;

        if (myIntThirdDigit==7)
        {
            myThirdDigitIsSeven = true;
        }   
        Console.WriteLine("3rd digit from right to left is 7: {0}", myThirdDigitIsSeven);
    }
}