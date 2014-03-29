using System;
using System.Collections.Generic;

class Slides
{
    static void ConvertStringToIntArray(string str, string[] separator, out int[] intArray)
    {
        intArray = Array.ConvertAll(str.Split(separator, StringSplitOptions.None), element => int.Parse(element));
    }
    static bool BallStuckCheck(int[] ballCoord, string[,,] cuboid, int[] direction)
    {
        bool ballStuck = false;
        string currentCubeValue = cuboid[ballCoord[0], ballCoord[1], ballCoord[2]];

        bool ballOutOfCube = false;

        if (ballCoord[0] + direction[0] < 0 || ballCoord[0] + direction[0] >= cuboid.GetLength(0)
            || ballCoord[2] + direction[2] < 0 || ballCoord[2] + direction[2] >= cuboid.GetLength(2))
        {
            ballOutOfCube = true;

            if (ballCoord[1] == cuboid.GetLength(1) - 1)
            {
                ballOutOfCube = false;
            }
        }

        if (currentCubeValue.StartsWith("B") || ballOutOfCube)
        {
            ballStuck = true;
        }

        return ballStuck;
    }

    static void AdjustDirection(int[] ballCoord, string[,,] cuboid, ref int[] directionVector)
    {
        string currentCubeValue = cuboid[ballCoord[0], ballCoord[1], ballCoord[2]];
        string currentCubeFirstLetter = currentCubeValue.Substring(0, 1);

        Dictionary<string, int[]> directionVectors = new Dictionary<string, int[]>()
        {
            {"S L", new int[] {-1, 1, 0}},
            {"S R", new int[] {1, 1, 0}},
            {"S F", new int[] {0, 1, -1}},
            {"S B", new int[] {0, 1, 1}},
            {"S FL", new int[] {-1, 1, -1}},
            {"S FR", new int[] {1, 1, -1}},
            {"S BL", new int[] {-1, 1, 1}},           
            {"S BR", new int[] {1, 1, 1}},
            {"E", new int[] {0, 1, 0}}
        };

        if (currentCubeFirstLetter == "S" || currentCubeFirstLetter == "E")
        {
            directionVector = directionVectors[currentCubeValue];
        }        
    }

    static bool TeleportCheck(int[]ballCoord, string[,,] cuboid)
    {
        bool teleportRequest = false;
        string currentCubeValue = cuboid[ballCoord[0], ballCoord[1], ballCoord[2]];

        if (currentCubeValue[0] == 'T')
        {
            teleportRequest = true;
        }
        return teleportRequest;
    }
    static void TeleportBall(int[] ballCoord, string[,,] cuboid)
    {
        string currentCubeValue = cuboid[ballCoord[0], ballCoord[1], ballCoord[2]];
        string[] teleportCoordinates = currentCubeValue.Substring(2).Split(' ');
        ballCoord[0] = int.Parse(teleportCoordinates[0]);
        ballCoord[2] = int.Parse(teleportCoordinates[1]);
    }
   
    static void MoveBall(int[] ballCoord, int[] direction)
    {
        for (int i = 0; i < ballCoord.Length; i++)
        {
            ballCoord[i] += direction[i];
        }
    }

    static bool BallOnExitCheck(int[] ballCoord, int[] cuboidSize)
    {
        bool ballOnExit = false;
        if (ballCoord[1] == cuboidSize[1] - 1)
        {
            ballOnExit = true;
        }
        return ballOnExit;
    }  
   
    static void Main()
    {
        //defining and initializing the cuboid size (Width, Height, Depth)
        int[] cuboidSize;
        string[] separatorString = new string[] { " " };

        string cuboidSizeString = Console.ReadLine();
        ConvertStringToIntArray(cuboidSizeString, separatorString, out cuboidSize);

        //defining and initializing the cuboid string array

        string[,,] cuboid = new string[cuboidSize[0], cuboidSize[1], cuboidSize[2]];

        separatorString = new string[] { " | " };
        for (int height = 0; height < cuboidSize[1]; height++)
        {
            string heightSlice = Console.ReadLine();
            string[] depthBars = heightSlice.Split(separatorString, StringSplitOptions.None);

            string[] separator = new string[] { "(", ")", ")(" };
            for (int depth = 0; depth < cuboidSize[2]; depth++)
            {
                string[] widthCubes = depthBars[depth].Split(separator, StringSplitOptions.RemoveEmptyEntries);

                for (int width = 0; width < cuboidSize[0]; width++)
                {
                    cuboid[width, height, depth] = widthCubes[width];
                }
            }
        }

        //defining and initializing the cuboid size (Width, Height, Depth)
                
        string ballCoordinatesString = Console.ReadLine();
        string[] ballCoord = ballCoordinatesString.Split(' ');

        int[] ballCoordinates = new int[]
        {
           int.Parse(ballCoord[0]), 0, int.Parse(ballCoord[1])
        };


        int[] direction = new int[3];
       
        bool ballStuck = false;

        while (true)
        {
            

            bool teleportNeeded = TeleportCheck(ballCoordinates, cuboid);

            if (teleportNeeded == true)
            {
                TeleportBall(ballCoordinates, cuboid);
                continue;
            }

            AdjustDirection(ballCoordinates, cuboid, ref direction);

            ballStuck = BallStuckCheck(ballCoordinates, cuboid, direction);

            if (ballStuck == true)
            {
                break;
            }

            bool ballOnExit = false;
            ballOnExit = BallOnExitCheck(ballCoordinates, cuboidSize);

            if (ballOnExit == true)
            {
                break;
            }
                                                                      
            MoveBall(ballCoordinates, direction);
        }

        Console.WriteLine("{0}", ballStuck ? "No" : "Yes");
        Console.WriteLine("{0} {1} {2}", ballCoordinates[0], ballCoordinates[1], ballCoordinates[2]);
    }
  
}
