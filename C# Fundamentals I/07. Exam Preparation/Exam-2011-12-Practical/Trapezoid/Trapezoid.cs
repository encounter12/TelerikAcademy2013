using System;

class Trapezoid
{
    static void Main()
    {
        int upperBaseLength = int.Parse(Console.ReadLine());

        //displays the hightest row on the console
        for (int dots = 0; dots < upperBaseLength; dots++)
        {
            Console.Write(".");            
        }
        for (int asterisks = 0; asterisks < upperBaseLength; asterisks++)
        {
            Console.Write("*");
        }

        Console.WriteLine();

        //displays rows 1 to upperBaseLength - 1
        for (int rows = 0; rows < upperBaseLength - 1; rows++)
        {
            for (int leftFillCols = 0; leftFillCols < upperBaseLength - rows - 1; leftFillCols++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int insideFillCols = 0; insideFillCols < upperBaseLength + rows - 1; insideFillCols++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            Console.WriteLine();
        }

        //displays last row
        for (int i = 0; i < upperBaseLength * 2; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();

    }
}