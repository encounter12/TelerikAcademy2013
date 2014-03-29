using System;

class FallDown
{
    static int GetBitOnPosition(int number, int position)
    {
        int extractedBit;

        extractedBit = (number & (1 << position)) >> position;
        return extractedBit;
    }

    static void Main()
    {
        int numbersCount = 8;
        int[] inputNumbers = new int[numbersCount];
        int[,] grid = new int[numbersCount, sizeof(byte) * 8];
           

        for (int i = 0; i < numbersCount; i++)
        {
            inputNumbers[i] = byte.Parse(Console.ReadLine());
        }

        for (int i = 0; i < numbersCount; i++)
        {
            for (int j = grid.GetLength(1) - 1; j >= 0; j--)
            {
                grid[i, grid.GetLength(1) - 1 - j] = GetBitOnPosition(inputNumbers[i], j);
            }
        }

        for (int i = grid.GetLength(0) - 2; i >= 0; i--)
		{
            for (int m = i; m < grid.GetLength(0) - 1; m++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[m, j] > grid[m + 1, j])
                    {
                        grid[m + 1, j] = 1;
                        grid[m, j] = 0;
                    }
                }	
            }                		 
		}

        int[] resultNumbers = new int[numbersCount];
            
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            resultNumbers[i] = 0;
            for (int j = grid.GetLength(1) - 1 ; j >= 0; j--)
            {
                resultNumbers[i] += grid[i, j] * (int)Math.Pow(2, grid.GetLength(1) - 1 - j);
                          
            }
            Console.WriteLine(resultNumbers[i]); 
        }            
    }
}

