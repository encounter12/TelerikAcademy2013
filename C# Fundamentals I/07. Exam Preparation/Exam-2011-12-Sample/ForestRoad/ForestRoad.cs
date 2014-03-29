using System;

class ForestRoad
{
    static void Main()
    {
        int mapWidthN = int.Parse(Console.ReadLine());
        int mapsHeight = 2*mapWidthN - 1;

        for (int rows = 0; rows < mapWidthN - 1; rows++)
        {
            for (int dotsCols = 0; dotsCols < rows; dotsCols++)
            {
                Console.Write(".");
            }

            Console.Write("*");

            for (int dotsCols = 0; dotsCols < mapWidthN - rows - 1; dotsCols++)
            {
                Console.Write(".");
            }

            Console.WriteLine();
        }        

        for (int rows = 0; rows < mapWidthN; rows++)
        {
            for (int dotsCols = 0; dotsCols < mapWidthN - rows - 1; dotsCols++)
            {
                Console.Write(".");
            }

            Console.Write("*");

            for (int dotsCols = 0; dotsCols < rows; dotsCols++)
            {
                Console.Write(".");
            }

            Console.WriteLine();
        }
    }
}