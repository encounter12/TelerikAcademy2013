using System;

class FindPrimesWithinRange
{
    static void Main()
    {
        Console.WriteLine("THIS PROGRAM FINDS ALL THE PRIMES BETWEEN 1 AND 100:");

        uint upperLimitInt = 100;
        for (int m = 1; m <= upperLimitInt; m++)
        {
           
            uint squareRootInt = (UInt32)Math.Sqrt(m);
            bool isComposite = false;

            for (int i = 2; i <= squareRootInt; i++)
            {
                if (m % i == 0)
                {
                    isComposite = true;
                    break;
                }
            }

            if (!isComposite)
            {
                Console.Write("{0} ", m);
            }               
        }
        Console.WriteLine();
    }
}
