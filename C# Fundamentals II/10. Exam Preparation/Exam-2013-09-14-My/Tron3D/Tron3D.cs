using System;
using System.Text.RegularExpressions;

class Tron3D
{
    static void ConvertStringToIntArray(string str, string[] separator, out int[] intArray)
    {
        intArray = Array.ConvertAll(str.Split(separator, StringSplitOptions.None), element => int.Parse(element));
    }

    static void AdjustPlayerDirections(int[] playerDirection, char playerDirectionChange)
    {
        if (playerDirectionChange == 'L')
        {
            if (playerDirection[0] == 0 && playerDirection[1] == -1)
            {
                playerDirection[0] = -1;
                playerDirection[1] = 0;
            }
            else if (playerDirection[0] == 0 && playerDirection[1] == 1)
            {
                playerDirection[0] = 1;
                playerDirection[1] = 0;
            }
            else if (playerDirection[1] == 0 && playerDirection[0] == 1)
            {
                playerDirection[0] = 0;
                playerDirection[1] = -1;
            }
            else if (playerDirection[1] == 0 && playerDirection[0] == -1)
            {
                playerDirection[0] = 0;
                playerDirection[1] = 1;
            }
        }

        if (playerDirectionChange == 'R')
        {

            if (playerDirection[0] == 0 && playerDirection[1] == -1)
            {
                playerDirection[0] = 1;
                playerDirection[1] = 0;
            }
            else if (playerDirection[0] == 0 && playerDirection[1] == 1)
            {
                playerDirection[0] = -1;
                playerDirection[1] = 0;
            }
            else if (playerDirection[1] == 0 && playerDirection[0] == 1)
            {
                playerDirection[0] = 0;
                playerDirection[1] = 1;
            }
            else if (playerDirection[1] == 0 && playerDirection[0] == -1)
            {
                playerDirection[0] = 0;
                playerDirection[1] = -1;
            }
            
        }
    }


    static void MovePlayer(int[] playerCoordinates, int[] playerDirection, int playgroundLength)
    {
        if (playerDirection[1] == 1 && playerCoordinates[1] == playgroundLength - 1)
        {
            playerCoordinates[1] = 0;
        }
        else if (playerDirection[1] == -1 && playerCoordinates[1] == 0)
        {
            playerCoordinates[1] = playgroundLength - 1;		 
        }
        else
        {
            for (int i = 0; i < playerCoordinates.Length; i++)
            {
                playerCoordinates[i] += playerDirection[i];
            }
        }

        
    }

    static bool PlayerReachedForbiddenWallCheck(int[] playerCoordinates, int[] cubeDimensions)
    {
        bool playerLooses = false;
        if (playerCoordinates[0] < 0 || playerCoordinates[0] >= cubeDimensions[0])
        {
            playerLooses = true;
        }

        return playerLooses;
    }


    static void MarkCellAsVisited(int[] playerCoordinates, bool[,] playerVisitedCells)
    {
        playerVisitedCells[playerCoordinates[0], playerCoordinates[1]] = true;
    }

    static bool PlayerReachedOppositePlayerTrail(int[] playerCoordinates, bool[,] opponentPlayerVisitedCells)
    {
        bool playerReachedTrail = false;
        if (opponentPlayerVisitedCells[playerCoordinates[0], playerCoordinates[1]])
        {
            playerReachedTrail = true;
        }
        return playerReachedTrail;
    }
    
    static void Main()
    {
        int[] cubeDimensions = new int[3];
        string[] separator = new string[] { " " };
        
        string cuboidDimensionsString = Console.ReadLine();
        char[] redPlayerMotion = Console.ReadLine().ToCharArray();
        char[] bluePlayerMotion = Console.ReadLine().ToCharArray();

        ConvertStringToIntArray(cuboidDimensionsString, separator, out cubeDimensions);

        int x = cubeDimensions[0];
        int y = cubeDimensions[1];
        int z = cubeDimensions[2];

        bool[,] redPlayerVisitedCells = new bool[x, y];
        bool[,] bluePlayerVisitedCells = new bool[x, y];

        int[] redPlayerCoordinates = new int[]{(x / 2 - 1), y / 2 - 1};
        int[] bluePlayerCoordinates = new int[] { (x / 2 - 1), (3 * y) / 2 + z - 1 };

        int[] redPlayerCurrentDirection = new int[]{0, 1};
        int[] bluePlayerCurrentDirection = new int[]{0, -1};

        int playgroundLength = (2 * y) + (2 * z);


        ulong loopCount = 0;
        bool redPlayerLooses = false; 
        bool bluePlayerLooses = false;

        while (true)
        {            
            AdjustPlayerDirections(redPlayerCurrentDirection, redPlayerMotion[loopCount]);
            AdjustPlayerDirections(bluePlayerCurrentDirection, bluePlayerMotion[loopCount]);

            MovePlayer(redPlayerCoordinates, redPlayerCurrentDirection, playgroundLength);
            MovePlayer(bluePlayerCoordinates, bluePlayerCurrentDirection, playgroundLength);

            MarkCellAsVisited(redPlayerCoordinates, redPlayerVisitedCells);
            MarkCellAsVisited(bluePlayerCoordinates, bluePlayerVisitedCells);

            redPlayerLooses = PlayerReachedForbiddenWallCheck(redPlayerCoordinates, cubeDimensions);
            bluePlayerLooses = PlayerReachedForbiddenWallCheck(bluePlayerCoordinates, cubeDimensions);

            redPlayerLooses = PlayerReachedOppositePlayerTrail(redPlayerCoordinates, bluePlayerVisitedCells);
            bluePlayerLooses = PlayerReachedOppositePlayerTrail(bluePlayerCoordinates, redPlayerVisitedCells);

            if (redPlayerLooses = true || bluePlayerLooses == true)
            {
                break;
            }
            loopCount++;
        }

        int xDistance = Math.Abs((x / 2 - 1) - redPlayerCoordinates[0]);
        int yDistance = Math.Abs((y / 2 - 1) - redPlayerCoordinates[1]); 

        int distance = xDistance + yDistance;
               
        if (redPlayerLooses == true)
        {
            Console.WriteLine("BLUE");
            Console.WriteLine(distance);
        }
        else if (bluePlayerLooses == true)
        {
            Console.WriteLine("RED");
            Console.WriteLine(distance);
        }
       
    }   
}