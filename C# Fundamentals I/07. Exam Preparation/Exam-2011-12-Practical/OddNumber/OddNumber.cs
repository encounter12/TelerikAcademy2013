using System;
//this solution gives time out on one of the tests
class OddNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long[] inputNumbers = new long[n];
            
        for (int i = n - 1; i >= 0; i--)
        {
            inputNumbers[i] = long.Parse(Console.ReadLine());
        }

        int counter;
        int s;

        for (s = 0; s < n; s++)
        {
            counter = 0;
            for (int m = 0; m < n; m++)
            {
                if (inputNumbers[s] == inputNumbers[m])
                {
                    counter++;
                }			        
            }
            if (counter % 2 != 0)
            {
                break;
            }
        }

        Console.WriteLine(inputNumbers[s]);
    }
}

