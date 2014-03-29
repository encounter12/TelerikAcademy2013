using System;

class Program
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        string innerPart = "";
        int nthTerm = 1;

        for (int row = 0; row < height; row++)
        {
            for (int dotsCol = 0; dotsCol < height - row - 1; dotsCol++)
            {
                Console.Write(".");
                
            }
            Console.Write("/");


            if (row == (nthTerm * nthTerm + nthTerm) / 2)
            {
                innerPart = new string('-', 2 * row);
                nthTerm++;
            }
            else
            {
                innerPart = new string('.', 2 * row);
            }

            Console.Write(innerPart);

            Console.Write(@"\");
            for (int dotsCol = 0; dotsCol < height - row - 1; dotsCol++)
            {
                Console.Write(".");

            }

            Console.WriteLine();            
        }
    }
}