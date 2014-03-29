using System;

class TelerikLogo
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());

        for (int i = 0; i < (x + 1) / 2; i++)
        {
            for (int j = 0; j < (x - 1) / 2 - i; j++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int j = 0; j < 2 * i - 1; j++)
            {
                Console.Write(".");
            }
            if (i > 0)
            {
                Console.Write("*");
            }
            for (int j = 0; j < 2*x - 3 - 2*i; j++)
            {
                Console.Write(".");
            }
            Console.Write("*");

            if (i > 0)
            {
                for (int j = 0; j < 2 * i - 1; j++)
                {
                    Console.Write(".");
                }
                Console.Write("*");
            }
            for (int j = 0; j < (x - 1) / 2 - i; j++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < (x - 3) / 2; i++)
        {
            for (int j = 0; j < x + i; j++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int j = 0; j < x - 2*i - 4; j++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int j = 0; j < x + i; j++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < ((3*x - 3) / 2) - i; j++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            
            if (i > 0)
            {
                for (int j = 0; j < 2 * i - 1; j++)
                {
                    Console.Write(".");
                }
                Console.Write("*");
            }
            
            for (int j = 0; j < ((3 * x - 3) / 2) - i; j++)
            {
                Console.Write(".");
            }

            Console.WriteLine();
        }
        for (int i = 0; i < x - 1; i++)
        {
            for (int j = 0; j < (x + 1)/2 + i; j++)
            {
                Console.Write(".");
            }
            Console.Write("*");
                       
            for (int j = 0; j < 2*x - 5 - 2*i; j++)
            {
                Console.Write(".");    
            }
            if (i < x - 2)
            {
                Console.Write("*");
            }
            for (int j = 0; j < (x + 1) / 2 + i; j++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
        }                
    }
}