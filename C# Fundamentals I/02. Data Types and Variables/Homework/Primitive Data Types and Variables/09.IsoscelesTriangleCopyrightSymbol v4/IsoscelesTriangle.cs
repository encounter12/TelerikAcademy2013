using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        int numberOfSymbols = 9;
        char copyrightCharacter = '\u00a9';
        Console.WriteLine("THIS PROGRAM PRINTS ISOSCELES TRIANGLE USING {0} COPYRIGHT {1} SYMBOLS\n", numberOfSymbols, copyrightCharacter);

        int rowsNumber = (int)Math.Sqrt(numberOfSymbols);

        for (int currentRow = 1; currentRow <= rowsNumber; currentRow++) //iterates over lines
        {
            Console.SetCursorPosition(rowsNumber - currentRow + 1, currentRow);
            String copyrightString = new String(copyrightCharacter, 2*currentRow - 1);
            Console.Write(copyrightString); //prints copyright characters on each line
        }
        Console.WriteLine();
    }
}
