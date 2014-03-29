using System;

class Laser
{
    static void ConvertStringToIntArray(string str, string[] separator, out int[] intArray)
    {
        intArray = Array.ConvertAll(str.Split(separator, StringSplitOptions.None), element => int.Parse(element));
    }

    static void AdjustLaserStartCoordinates(ref int[] laserStartCoordinates)
    {        
        for (int i = 0; i < laserStartCoordinates.Length; i++)
        {
            laserStartCoordinates[i] -= 1;
        }        
    }

    static void MoveLaser(int[] directionVector, ref int[] laserCurrentCoordinates)
    {
        for (int i = 0; i < laserCurrentCoordinates.Length; i++)
        {
            laserCurrentCoordinates[i] += directionVector[i];
        }
    }

    static void EdgeVertexReachedCheck(int[] cuboidDimensions, int[] laserCoord, ref bool laserStuck)
    {
        int laserWidth = laserCoord[0];
        int laserHeight = laserCoord[1];
        int laserDepth = laserCoord[2];
        int cubeWidth = cuboidDimensions[0] - 1;
        int cubeHeight = cuboidDimensions[1] - 1;
        int cubeDepth = cuboidDimensions[2] - 1;    
        //width edges
        if ((laserHeight == 0 && laserDepth == 0) || (laserHeight == cubeHeight && laserDepth == 0)
            || (laserDepth == cubeDepth && laserHeight == 0) || (laserHeight == cubeHeight && laserDepth == cubeDepth))
        {
            laserStuck = true;
        }
        //height edges
        if ((laserWidth == 0 && laserDepth == 0) || (laserWidth == cubeWidth && laserDepth == 0) 
            || (laserWidth == 0 && laserDepth == cubeDepth) || (laserWidth == cubeWidth && laserDepth == cubeDepth))
        {
            laserStuck = true;
        }
        //depth edges
        if ((laserWidth == 0 && laserHeight == 0) || (laserWidth == 0 && laserHeight == cubeHeight) 
            || (laserWidth == cubeWidth && laserHeight == 0) || (laserWidth == cubeWidth && laserHeight == cubeHeight))
        {
            laserStuck = true;            
        }
    }

    static void BurnCube(int[] pointCoord, ref bool[,,] burnedCubesArray)
    {
        burnedCubesArray[pointCoord[0], pointCoord[1], pointCoord[2]] = true;
    }
    static void BurnedCubeReachedCheck(int[] pointCoord, bool[,,] burnedCubesArray, ref bool laserStuck)
    {
        if (burnedCubesArray[pointCoord[0], pointCoord[1], pointCoord[2]] == true)
        {
            laserStuck = true;
        }
    }
    static void FindLaserPreviousCoordinates(int[] laserdirection, ref int[] laserCoord)
    {
        for (int i = 0; i < laserCoord.Length; i++)
        {
            laserCoord[i] -= laserdirection[i];
        }
    }
    static void AdjustLaserEndCoordinates(ref int[] laserFinalCoordinates)
    {
        for (int i = 0; i < laserFinalCoordinates.Length; i++)
        {
            laserFinalCoordinates[i] += 1;
        }
    }
    static void SideVerticalWallReachedCheck(int[] pointCoord, int[] cuboidDimensions, ref int[] directionVector)
    {
        if (pointCoord[0] == 0 || pointCoord[0] == cuboidDimensions[0] - 1)
        {
            directionVector[0] *= -1;
        }
    }
    static void FacingVerticalWallReachedCheck(int[] pointCoord, int[] cuboidDimensions, ref int[] directionVector)
    {
        if (pointCoord[2] == 0 || pointCoord[2] == cuboidDimensions[2] - 1)
        {
            directionVector[2] *= -1;
        }
    }

    static void HorizontalWallReachedCheck(int[] pointCoord, int[] cuboidDimensions, ref int[] directionVector)
    {
        if (pointCoord[1] == 0 || pointCoord[1] == cuboidDimensions[1] - 1)
        {
            directionVector[1] *= -1;
        }
    }

    static void Main()
    {
        string[] separatorString = new string[] { " " };

        //defining and initializing the cuboid dimensions (W, H, and D) array
        int[] cuboidSize;

        string cuboidSizeString = Console.ReadLine();
        ConvertStringToIntArray(cuboidSizeString, separatorString, out cuboidSize);


        //defining and initializing the laser start cube coordinates (startW, startH, and startD) array
        int[] pointCoordinates;
        string pointCoordinatesString = Console.ReadLine();
        ConvertStringToIntArray(pointCoordinatesString, separatorString, out pointCoordinates);

        //adjusting the laser start cube coordinates for 3 dimensional array starting from W = 0, H = 0, D = 0
        AdjustLaserStartCoordinates(ref pointCoordinates);
       
        //defining and initializing the point direction (dirW, dirH, and dirD) array 
        int[] direction;
        string directionString = Console.ReadLine();
        ConvertStringToIntArray(directionString, separatorString, out direction);

        //defining and initializing 3-dimentional bool array with the burned cubes
        bool[, ,] burnedCubes = new bool[cuboidSize[0], cuboidSize[1], cuboidSize[2]];
        
        bool laserStuck = false;

        while (true)
        {
                        
            //Check if edge or vertex is reached
            EdgeVertexReachedCheck(cuboidSize, pointCoordinates, ref laserStuck);

            //Check if burned cube is reached 
            BurnedCubeReachedCheck(pointCoordinates, burnedCubes, ref laserStuck);

            if (laserStuck == true)
            {
                //check what are the previous cube coordinates and break the loop.
                
                break;
            }
            
            //Check if side vertical wall is reached (widthWalls)
            SideVerticalWallReachedCheck(pointCoordinates, cuboidSize, ref direction);
            
            //Check if facing vertical wall is reached (heightWalls)
            FacingVerticalWallReachedCheck(pointCoordinates, cuboidSize, ref direction);

            //Check if horizontal upper or bottom wall is reached (horizontalWalls)
            HorizontalWallReachedCheck(pointCoordinates, cuboidSize, ref direction);

            BurnCube(pointCoordinates, ref burnedCubes);
            MoveLaser(direction, ref pointCoordinates);
        }

        FindLaserPreviousCoordinates(direction, ref pointCoordinates);
        
        //adjust final cube coordinates 
        AdjustLaserEndCoordinates(ref pointCoordinates);

        Console.WriteLine(string.Join(" ", pointCoordinates));          
    }
}