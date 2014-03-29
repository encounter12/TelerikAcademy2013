using System;

class AngryBits
{
    static int[,] battleField = new int[8, 16];
    static int pigsTotalNumber = 0;

    enum Direction
    {
        NorthEast,
        SouthEast
    };

    public struct DamageArea
    {
        public int StartRow;
        public int EndRow;
        public int StartCol;
        public int EndCol;
    }

    static void Main()
    {                
        InitializeBattleField();

        int totalScore = 0;
        int totalDestroyedPigs = 0;
                
        for (int birdFieldCol = 7; birdFieldCol >= 0; birdFieldCol--)
        {
            for (int birdFieldRow = 0; birdFieldRow < battleField.GetLength(0); birdFieldRow++)
            {
                if (battleField[birdFieldRow, birdFieldCol] == 1)
                {
                    int strikeDestroyedPigs = 0;
                    int strikeScore = 0;
                    
                    BirdFlight(birdFieldRow, birdFieldCol, out strikeDestroyedPigs, out strikeScore);

                    totalDestroyedPigs += strikeDestroyedPigs;
                    totalScore += strikeScore;
                }
                
            }
        }

        Console.WriteLine("{0} {1}", totalScore, totalDestroyedPigs == pigsTotalNumber ? "Yes" : "No");
    }
   
    public static int BitAtPositionN(ushort inputNumber, int positionN)
    {
        int bitValue;

        if ((inputNumber & (1 << positionN)) != 0)
        {
            bitValue = 1;
        }
        else
        {
            bitValue = 0;
        }

        return bitValue;
    }

    //Take the user input and fill the 2 dimensional array with the bit values
    public static void InitializeBattleField()
    {
        for (int i = 0; i < battleField.GetLength(0); i++)
        {
            ushort inputNumber = ushort.Parse(Console.ReadLine());

            for (int j = battleField.GetLength(1) - 1; j >= 0; j--)
            {
                battleField[i, j] = BitAtPositionN(inputNumber, battleField.GetLength(1) - j - 1);

                if (j > 7 && battleField[i, j] == 1)
                {
                    pigsTotalNumber++;
                }
            }
        }
    }

    public static void BirdFlight(int birdFieldRow, int birdFieldCol, out int strikeDestroyedPigs, out int strikeScore)
    {
        battleField[birdFieldRow, birdFieldCol] = 0;
        int flyingBirdRow = birdFieldRow;
        int flyingBirdCol = birdFieldCol;

        Direction birdDirection = Direction.NorthEast;
        int flightLength = 0;
        strikeDestroyedPigs = 0;
        strikeScore = 0;
        bool isPigHit = false;

        while (true)
        {

            if (birdDirection == Direction.NorthEast && flyingBirdRow > 0)
            {
                flyingBirdRow--;
            }
            else
            {
                birdDirection = Direction.SouthEast;
                flyingBirdRow++;
            }

            flyingBirdCol++;
            flightLength++;

            if (battleField[flyingBirdRow, flyingBirdCol] == 1)
            {
                isPigHit = true;

                DamageArea damageArea = FindDamageAreaLimits(flyingBirdRow, flyingBirdCol);

                strikeDestroyedPigs = StrikeCalculateDamage(damageArea.StartRow, damageArea.EndRow, damageArea.StartCol, damageArea.EndCol);
                
            }

            if (flyingBirdRow == battleField.GetLength(0) - 1 || flyingBirdCol == battleField.GetLength(1) - 1 || isPigHit == true)
            {
                break;
            }
        }

        strikeScore = flightLength * strikeDestroyedPigs;       
    }

    //Calculates the number of destroyed pigs when bird hits a pig 
    private static int StrikeCalculateDamage(int impactAreaStartRow, int impactAreaEndRow, int impactAreaStartCol, int impactAreaEndCol)
    {
        int strikeDestroyedPigsCount = 0;
        for (int p = impactAreaStartRow; p <= impactAreaEndRow; p++)
        {
            for (int q = impactAreaStartCol; q <= impactAreaEndCol; q++)
            {
                if (battleField[p, q] == 1)
                {
                    strikeDestroyedPigsCount++;
                    battleField[p, q] = 0;
                }

            }
        }
        return strikeDestroyedPigsCount;
    }
    
    //Finds the limits of the damage area around the hit pig
    private static DamageArea FindDamageAreaLimits(int flyingBirdRow, int flyingBirdCol)
    {
        DamageArea damageArea;

        if (flyingBirdRow == battleField.GetLength(0) - 1)
        {
            damageArea.StartRow = flyingBirdRow - 1;
            damageArea.EndRow = flyingBirdRow;
        }
        else if (flyingBirdRow == 0)
        {
            damageArea.StartRow = flyingBirdRow;
            damageArea.EndRow = flyingBirdRow + 1;
        }
        else
        {
            damageArea.StartRow = flyingBirdRow - 1;
            damageArea.EndRow = flyingBirdRow + 1;
        }

        if (flyingBirdCol == 8)
        {
            damageArea.StartCol = flyingBirdCol;
            damageArea.EndCol = flyingBirdCol + 1;
        }
        else if (flyingBirdCol == battleField.GetLength(1) - 1)
        {
            damageArea.StartCol = flyingBirdCol - 1;
            damageArea.EndCol = flyingBirdCol;
        }
        else
        {
            damageArea.StartCol = flyingBirdCol - 1;
            damageArea.EndCol = flyingBirdCol + 1;
        }
        return damageArea;
    }    
}

