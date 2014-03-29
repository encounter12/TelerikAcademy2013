using System;

class TribonacciTriangle
{
    static void Main()
    {
        long termNMinusThree = long.Parse(Console.ReadLine());
        long termNMinusTwo = long.Parse(Console.ReadLine());
        long termNMinusOne = long.Parse(Console.ReadLine());
        int linesNumberL = int.Parse(Console.ReadLine());
        long termN;

        if (linesNumberL == 1)
        {
            Console.WriteLine(termNMinusThree);
        }        
        else
        {
            Console.WriteLine(termNMinusThree);
            Console.WriteLine(termNMinusTwo + " " + termNMinusOne);
            int count = 3;

            for (int rows = 0; rows < linesNumberL - 2; rows++)
            {
                for (int i = 0; i < count; i++)
                {
                    termN = termNMinusOne + termNMinusTwo + termNMinusThree;
                    termNMinusThree = termNMinusTwo;
                    termNMinusTwo = termNMinusOne;
                    termNMinusOne = termN;
                    
                    if (i == count - 1)
                    {
                        Console.Write("{0}", termN);
                    }
                    else
                    {
                        Console.Write("{0} ", termN);
                    }
                }
                count++;               
                Console.WriteLine();
            }            
        }
    }
}

