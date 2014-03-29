using System;
using System.Text;


class IsoscelesTriangle
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
            for (int colCounter = 1; colCounter <= 2*currentRow - 1; colCounter++)
            {
                Console.SetCursorPosition(rowsNumber - currentRow + colCounter, currentRow);
                Console.Write(copyrightCharacter); //prints copyright characters on each line
            }
        }
        Console.WriteLine();

    }
}

