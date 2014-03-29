using System;

class FormulaBitOne
{
    
    static int turnsCount = 0;
    static int roadLength = 1;
    static int carRow = 0;
    static int carCol = 7;
    static bool endOfRoad = false;
    static bool noEndOfRoad = false;

    static void Main()
    {
        int[,] numbers;
        FillFormulaArea(out numbers);
             
        while (true)
        {
            if (numbers[carRow + 1, carCol] == 1)
            {
                noEndOfRoad = true;
                break;
            }

            MoveSouth(carRow, carCol, numbers);

            if (carRow == 7 && carCol == 0)
            {
                endOfRoad = true;
                break;
            }
            else if (carCol == 0)
            {
                noEndOfRoad = true;
                break;
            }

            if (numbers[carRow, carCol - 1] == 1)
            {
                noEndOfRoad = true;
                break;
            }

            MoveWest(carRow, carCol, numbers);

            if (numbers[carRow - 1, carCol] == 1)
            {
                noEndOfRoad = true;
                break;
            }
            else if (carRow == 7 && carCol == 0)
            {
                endOfRoad = true;
                break;
            }

            MoveNorth(carRow, carCol, numbers);

            if (carCol == 0)
            {
                noEndOfRoad = true;
                break;
            }

            if (numbers[carRow, carCol - 1] == 1)
            {
                noEndOfRoad = true;
                break;
            }
            MoveWest(carRow, carCol, numbers);
           
        }

        if (noEndOfRoad == true)
        {
            Console.WriteLine("No {0}", roadLength);
        }
        else if (endOfRoad == true)
        {
            Console.WriteLine("{0} {1}", roadLength, turnsCount);
        }       
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

    public static void MoveSouth(int currentRow, int currentCol, int[,] numbers)
    {
        for (int row = currentRow; row < 8; row++)
        {
            roadLength++;

            if (row == 7 || numbers[row + 1, currentCol] == 1)
            {                
                turnsCount++;
                carRow = row;         
                break;
            }
            
        }                
    }

    public static void MoveWest(int currentRow, int currentCol, int[,] numbers)
    {

        for (int col = currentCol - 1; col >= 0; col--)
        {
            roadLength++;

            if (col == 0 || numbers[currentRow, col - 1] == 1)
            {
                turnsCount++;
                carCol = col;              
                break;
            }

        }
    }

    public static void MoveNorth(int currentRow, int currentCol, int[,] numbers)
    {
        for (int row = currentRow; row >= 0; row--)
        {
            roadLength++;

            if (row == 0 || numbers[row - 1, currentCol] == 1)
            {
                turnsCount++;
                carRow = row;
                break;
            }

        }
    }
}