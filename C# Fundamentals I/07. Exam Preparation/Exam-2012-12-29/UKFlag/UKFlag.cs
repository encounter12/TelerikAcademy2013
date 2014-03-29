using System;

class UKFlag
{
    static void Main()
    {
        int widthN = int.Parse(Console.ReadLine());

        for (int row = 0; row < widthN / 2; row++)
        {
            for (int col = 0; col < row; col++)
            {
                Console.Write(".");
            }
            Console.Write(@"\");
            
            for (int col = 0; col < widthN/2 - row - 1; col++)
            {
                Console.Write(".");
            }
            Console.Write(@"|");
            
            for (int col = 0; col < widthN / 2 - row - 1; col++)
            {
                Console.Write(".");
            }
            Console.Write(@"/");
            for (int col = 0; col < row; col++)
            {
                Console.Write(".");
            }

            Console.WriteLine();
        }
        
        for (int i = 0; i < widthN / 2; i++)
        {
            Console.Write("-");
        }

        Console.Write("*");
        
        for (int i = 0; i < widthN / 2; i++)
        {
            Console.Write("-");
        }

        Console.WriteLine();

        for (int row = 0; row < widthN / 2; row++)
        {
            for (int col = 0; col < widthN / 2 - row - 1; col++)
            {
                Console.Write(".");
            }           

            Console.Write(@"/");

            for (int col = 0; col < row; col++)
            {
                Console.Write(".");
            }
            
            Console.Write(@"|");

            for (int col = 0; col < row; col++)
            {
                Console.Write(".");
            }
            
            Console.Write(@"\");

            for (int col = 0; col < widthN / 2 - row - 1; col++)
            {
                Console.Write(".");
            }
            Console.WriteLine();                      
        }
    }
}