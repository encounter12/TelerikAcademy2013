using System;

class QuadronacciRectangle
{
    static void Main()
    {
        long term1 = long.Parse(Console.ReadLine());
        long term2 = long.Parse(Console.ReadLine());
        long term3 = long.Parse(Console.ReadLine());
        long term4 = long.Parse(Console.ReadLine());
        int rows = int.Parse(Console.ReadLine());
        int columns = int.Parse(Console.ReadLine());
        long currentTerm = 0;

        Console.Write(term1 + " " + term2 + " " + term3 + " " + term4);

        for (int i = 0; i < columns - 4; i++)
        {
            currentTerm = term1 + term2 + term3 + term4;

            Console.Write(" {0}", currentTerm);
            term1 = term2;
            term2 = term3;
            term3 = term4;
            term4 = currentTerm;
        }
        
        for (int i = 0; i < rows - 1; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < columns; j++)
            {
                currentTerm = term1 + term2 + term3 + term4;
                if (j < columns - 1)
                {
                    Console.Write("{0} ", currentTerm);
                }
                else
                {
                    Console.Write("{0}", currentTerm);
                }
                term1 = term2;
                term2 = term3;
                term3 = term4;
                term4 = currentTerm;

            }            
        }
    }
}

