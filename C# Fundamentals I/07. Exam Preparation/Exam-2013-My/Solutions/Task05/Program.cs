using System;

class Program
{
    static void Main()
    {

    }

    public static int GetBitOnPosition(int number, int position)
    {
        int bitOnPosition = (number & (1 << position)) >> position;
        return bitOnPosition;
    }
    public static void FillFormulaArea(out int[,] numbers)
    {
        numbers = new int[8, 8];

        for (int row = 0; row < 8; row++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int col = 0; col < 8; col++)
            {
                numbers[row, col] = GetBitOnPosition(number, 7 - col);
            }
        }
    }
}

