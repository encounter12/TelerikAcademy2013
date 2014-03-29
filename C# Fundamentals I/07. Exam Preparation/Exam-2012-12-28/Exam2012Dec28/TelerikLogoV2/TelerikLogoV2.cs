using System;

class TelerikLogo
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());

        for (int i = 0; i < (x + 1) / 2; i++)
        {            
            Console.Write(new string('.', ((x - 1) / 2) - i));
            Console.Write("*");          
            if (i > 0)
            {
                Console.Write(new string('.', 2 * i - 1));
                Console.Write("*");
            }
            Console.Write(new string('.', 2 * x - 3 - 2 * i));
            Console.Write("*");

            if (i > 0)
            {
                Console.Write(new string('.', 2 * i - 1));
                Console.Write("*");
            }
            Console.Write(new string('.', (x - 1) / 2 - i));            
            Console.WriteLine();
        }

        for (int i = 0; i < (x - 3) / 2; i++)
        {
            Console.Write(new string('.', x + i));
            Console.Write("*");
            Console.Write(new string('.', x - 2 * i - 4));
            Console.Write("*");
            Console.Write(new string('.', x + i));
            Console.WriteLine();
        }

        for (int i = 0; i < x; i++)
        {
            Console.Write(new string('.', ((3 * x - 3) / 2) - i));
            Console.Write("*");
            if (i > 0)
            {
                Console.Write(new string('.', 2 * i - 1));
                Console.Write("*");
            }
            Console.Write(new string('.', ((3 * x - 3) / 2) - i));
            Console.WriteLine();
        }

        for (int i = 0; i < x - 1; i++)
        {
            Console.Write(new string('.', (x + 1) / 2 + i));
            Console.Write("*");
            if (i < x - 2)
            {
                Console.Write(new string('.', 2 * x - 5 - 2 * i));
                Console.Write("*");
            }
            Console.Write(new string('.', (x + 1) / 2 + i));
            Console.WriteLine();
        }
    }
}