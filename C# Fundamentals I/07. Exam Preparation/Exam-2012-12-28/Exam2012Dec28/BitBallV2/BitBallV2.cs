using System;

class BitBall
{
    static void Main()
    {
        int[,] topTeam;
        int[,] bottomTeam;

        PlaygroundFill(out topTeam, out bottomTeam);

        int topTeamScore = 0;
        int bottomTeamScore = 0;

        for (int col = 0; col < 8; col++)
        {
            int topPlayerRow;
            bool topPlayerOnColExists = IsTherePlayerOnCol(topTeam, col, out topPlayerRow);

            if (topPlayerOnColExists == true)
            {
                topTeamScore += SingleTopPlayerScore(bottomTeam, col, topPlayerRow);              
            }                                     
        }

        for (int col = 0; col < 8; col++)
        {
            int bottomPlayerRow;
            bool bottomPlayerOnColExists = IsTherePlayerOnCol(bottomTeam, col, out bottomPlayerRow);

            if (bottomPlayerOnColExists == true)
            {
                bottomTeamScore += SingleBottomPlayerScore(topTeam, col, bottomPlayerRow);     
            }
        }

        Console.WriteLine("{0}:{1}", topTeamScore, bottomTeamScore);
    }
    public static int GetBitOnPosition(int number, int position)
    {
        int digit = (number & (1 << position)) >> position;
        return digit;
    }
    public static void PlaygroundFill(out int[,] topTeamOnPlayground, out int[,] bottomTeamOnPlayground)
    {
        int number;
        topTeamOnPlayground = new int[8, 8];
        bottomTeamOnPlayground = new int[8, 8];

        for (int row = 0; row < 8; row++)
        {
            number = int.Parse(Console.ReadLine());
            for (int bitPosition = 0; bitPosition < 8; bitPosition++)
            {
                topTeamOnPlayground[row, 7 - bitPosition] = GetBitOnPosition(number, bitPosition);
            }
        }

        for (int row = 0; row < 8; row++)
        {
            number = int.Parse(Console.ReadLine());
            for (int bitPosition = 0; bitPosition < 8; bitPosition++)
            {
                bottomTeamOnPlayground[row, 7 - bitPosition] = GetBitOnPosition(number, bitPosition);
                if (bottomTeamOnPlayground[row, 7 - bitPosition] == 1 && topTeamOnPlayground[row, 7 - bitPosition] == 1)
                {
                    bottomTeamOnPlayground[row, 7 - bitPosition] = 0;
                    topTeamOnPlayground[row, 7 - bitPosition] = 0;
                }
            }
        }
    }
    public static bool IsTherePlayerOnCol(int[,] team, int col, out int playerRow)
    {
        bool playerOnColExists = false;
        playerRow = 0;

        for (int row = 7; row >= 0; row--)
        {
            if (team[row, col] == 1)
            {
                playerOnColExists = true;
                playerRow = row;
                break;
            }
        }
        return playerOnColExists;
    }
    public static int SingleTopPlayerScore(int[,] bottomTeam, int col, int topPlayerRow)
    {
        int distance = 0;
        int topPlayerScore = 0;

        for (int rowB = 7; rowB > topPlayerRow; rowB--)
        {

            if (bottomTeam[rowB, col] == 1)
            {
                break;
            }
            distance++;
        }
        if (distance == 7 - topPlayerRow)
        {
            topPlayerScore++;
        }
        return topPlayerScore;
    }
    public static int SingleBottomPlayerScore(int[,] topTeam, int col, int bottomPlayerRow)
    {
        int distance = 0;
        int bottomPlayerScore = 0;
        for (int rowT = 0; rowT < bottomPlayerRow; rowT++)
        {
            if (topTeam[rowT, col] == 1)
            {
                break;
            }
            distance++;
        }
        if (distance == bottomPlayerRow)
        {
            bottomPlayerScore++;
        }
        return bottomPlayerScore;   
    }
}