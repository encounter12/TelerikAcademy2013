using System;

class PrintNumbers
{
    static void Main()
    {
        int termsNumber = 3;

        Console.Write("{0}", 1);

        for (int i = 0; i < termsNumber - 1; i++)
        {
            uint nthTerm = (uint)Math.Pow(10, i + 2) + 1;
            Console.Write(", {0}", nthTerm);
        }
        Console.WriteLine();
    }
}
