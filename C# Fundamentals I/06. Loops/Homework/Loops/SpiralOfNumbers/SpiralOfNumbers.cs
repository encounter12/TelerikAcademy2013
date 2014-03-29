using System;

class SpiralMatrix
{
    static void Main()
    {
        byte n = 0;

        do
        {
            Console.WriteLine("Please, enter a positive integer number N (1 <= N < 20)");
        } while (byte.TryParse(Console.ReadLine(), out n) == false || n < 1 || n >= 20);

        uint[,] matrix = GenerateSpiralMatrix(n, n);
        Console.WriteLine();
        PrintMatrix(matrix);
    }
    
    static uint[,] GenerateSpiralMatrix(byte rows, byte columns)
    {
        uint[,] matrix = new uint[rows, columns];

        int lowerRowBound = 0;
        int upperRowBound = rows - 1;

        int lowerColumnBound = 0;
        int upperColumnBound = columns - 1;

        uint currentNumber = 1;

        do
        {
            //fill upper rows
            for (int upperRowsColumnIndex = lowerColumnBound; upperRowsColumnIndex <= upperColumnBound; upperRowsColumnIndex++)
            {
                matrix[lowerRowBound, upperRowsColumnIndex] = currentNumber;
                currentNumber++;
            }
            lowerRowBound++;

            //fill right columns
            for (int rightColumnsRowIndex = lowerRowBound; rightColumnsRowIndex <= upperRowBound; rightColumnsRowIndex++)
            {
                matrix[rightColumnsRowIndex, upperColumnBound] = currentNumber;
                currentNumber++;
            }
            upperColumnBound--;

            //this check is needed for the algorithm to work correct in some cases when columns != rows
            if (currentNumber > rows * columns)
            {
                break;
            }

            //fill lower rows
            for (int lowerRowsColumnIndex = upperColumnBound; lowerRowsColumnIndex >= lowerColumnBound; lowerRowsColumnIndex--)
            {
                matrix[upperRowBound, lowerRowsColumnIndex] = currentNumber;
                currentNumber++;
            }
            upperRowBound--;

            //fill left columns
            for (int leftColumnsRowIndex = upperRowBound; leftColumnsRowIndex >= lowerRowBound; leftColumnsRowIndex--)
            {
                matrix[leftColumnsRowIndex, lowerColumnBound] = currentNumber;
                currentNumber++;
            }
            lowerColumnBound++;
        }
        while (currentNumber <= rows * columns);

        return matrix;
    }

    static void PrintMatrix(uint[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,-3} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
