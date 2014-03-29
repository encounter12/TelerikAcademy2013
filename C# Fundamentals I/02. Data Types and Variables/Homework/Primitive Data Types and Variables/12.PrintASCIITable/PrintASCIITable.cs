using System;
using System.Text;

class Program
{
    static void Main()
    {        
        Console.WriteLine("THIS PROGRAM PRINTS THE WHOLE ASCII TABLE:\n");
        Console.Write("Decimal".PadRight(10));
        Console.Write("ASCII".PadRight(10));
        Console.WriteLine();
        char asciiChar;
        for (int i = 0; i < 128; i++)
        {
            asciiChar = (char)i;
            Console.Write(i.ToString().PadRight(10));
            Console.Write(asciiChar.ToString().PadRight(10));
            Console.WriteLine();
        }
    }
}
