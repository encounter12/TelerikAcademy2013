using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

struct ConsoleObject
{
    public int startX;
    public int endX;
    public int y;
    public string str;
    public ConsoleColor color;
}

class FallingRocksGame
{
    static int playfieldWidth = 0;
    static int livesCount = 0;
    static double speed = 0;
    static int increasePointsIterations = 0;
    static uint points = 0;
    static int consoleHeight = 30;
    static int consoleWidth = 100;

    static void PrintOnPosition(int x, int y, char symbol,
        ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }

    static void PrintOnPosition(int x, int y, string str,
        ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }

    static void RemoveScrollBars()
    {
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }

    static void SetConsoleWindowSize()
    {
        Console.WindowWidth = consoleWidth;
        Console.WindowHeight = consoleHeight;
    }
    
    static int SetDwardInitialPositionToMiddle(int playfieldWidth, int dwarfStringLength)
    {
        int dwarfStartX = (playfieldWidth / 2) - (dwarfStringLength / 2);
        return dwarfStartX;
    }

    static void PrintUserInformation()
    {
        PrintOnPosition(playfieldWidth + 5, 5, "Lives: ", ConsoleColor.Blue);
        PrintOnPosition(playfieldWidth + 12, 5, livesCount.ToString(), ConsoleColor.Yellow);
        PrintOnPosition(playfieldWidth + 5, 7, "Speed: ", ConsoleColor.Blue);
        PrintOnPosition(playfieldWidth + 12, 7, speed.ToString(), ConsoleColor.Yellow);
        PrintOnPosition(playfieldWidth + 5, 9, "Points: ", ConsoleColor.Blue);
        PrintOnPosition(playfieldWidth + 13, 9, points.ToString(), ConsoleColor.Yellow);

    }
    static void PrintVerticalLine()
    {
        for (int i = 0; i < consoleHeight; i++)
        {
            PrintOnPosition(playfieldWidth + 1, i, "|", ConsoleColor.White);
        }
    }

    static void Main()
    {
        SetConsoleWindowSize();
        RemoveScrollBars();

        Console.CursorVisible = false;
        Random randomGenerator = new Random();
        int maxRockSize = 3;
        playfieldWidth = Console.WindowWidth - maxRockSize - 25; //Console.WindowWidth - dwarf.str.Length
        int[] rockRandomStartXArea = new int[2];

        speed = 100.0;
        double acceleration = 0.5;       
        livesCount = 5;

        char[] rockSymbol = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.' };

        ConsoleColor[] rockColor = new ConsoleColor[11];
        rockColor[0] = ConsoleColor.Blue;
        rockColor[1] = ConsoleColor.Yellow;
        rockColor[2] = ConsoleColor.Green;
        rockColor[3] = ConsoleColor.Red;
        rockColor[4] = ConsoleColor.Magenta;
        rockColor[5] = ConsoleColor.DarkBlue;
        rockColor[6] = ConsoleColor.DarkGreen;
        rockColor[7] = ConsoleColor.DarkYellow;
        rockColor[8] = ConsoleColor.DarkCyan;
        rockColor[9] = ConsoleColor.DarkRed;
        rockColor[10] = ConsoleColor.DarkMagenta;

        List<ConsoleObject> rocks = new List<ConsoleObject>();

        int randomRockSymbolNumber;
        int randomRockSize;
        int randomColorNumber;

        ConsoleObject dwarf = new ConsoleObject();
        dwarf.str = "(O)";
 
        //Setting the Dwarf initial coordinates (in the middle) and color
        dwarf.startX = SetDwardInitialPositionToMiddle(playfieldWidth, dwarf.str.Length);
        dwarf.endX = dwarf.startX + dwarf.str.Length - 1;
        dwarf.y = Console.WindowHeight - 1;
        dwarf.color = ConsoleColor.White;

        while (true)
        {
            //Updating the Dwarf coordinates when Left / Right Arrow is pressed

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.startX - 1 >= 0)
                    {
                        dwarf.startX = dwarf.startX - 1;
                        dwarf.endX = dwarf.startX + dwarf.str.Length - 1;
                    }

                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.endX + 1 <= playfieldWidth)
                    {
                        dwarf.startX = dwarf.startX + 1;
                        dwarf.endX = dwarf.startX + dwarf.str.Length - 1;
                    }
                }
            }
            //----------------------------------------

            /* Creating 2 Rocks on 1st line (one in the Console's right half and one in the Console's left half)
            and adding them in a List called "rocks" */

            for (int i = 0; i < 2; i++)
            {
                randomRockSymbolNumber = randomGenerator.Next(0, 10);
                ConsoleObject newRock = new ConsoleObject();
                randomRockSize = randomGenerator.Next(1, maxRockSize + 1);
                randomColorNumber = randomGenerator.Next(0, 11);

                StringBuilder rockString = new StringBuilder();
                newRock.str = rockString.Append(rockSymbol[randomRockSymbolNumber], randomRockSize).ToString();

                rockRandomStartXArea[0] = randomGenerator.Next(0, playfieldWidth / 2 - randomRockSize + 2);
                rockRandomStartXArea[1] = randomGenerator.Next(playfieldWidth / 2 + 1, playfieldWidth - randomRockSize + 2);

                newRock.startX = rockRandomStartXArea[i];
                newRock.endX = newRock.startX + (randomRockSize - 1);
                newRock.y = 0;
                newRock.color = rockColor[randomColorNumber];
                rocks.Add(newRock);
            }
            //----------------------------------------

            /* Increasing the rocks y coordinate with 1 and recording the new objects in a new List called "newList" 
               If the y coordinate gets higher than the Console's height these Rocks are not added in "newList" */

            List<ConsoleObject> newList = new List<ConsoleObject>();

            for (int i = 0; i < rocks.Count; i++)
            {
                ConsoleObject oldRock = rocks[i];
                ConsoleObject newObject = new ConsoleObject();
                newObject.startX = oldRock.startX;
                newObject.endX = oldRock.endX;
                newObject.y = oldRock.y + 1;
                newObject.str = oldRock.str;
                newObject.color = oldRock.color;
                if (newObject.y < Console.WindowHeight)
                {
                    newList.Add(newObject);
                }      
            }

            //----------------------------------------
           
            rocks = newList; //re-assigning the values of "newList" back to "rocks" List

            // Clearing the Console
            Console.Clear();
            PrintVerticalLine();
            PrintUserInformation();
            PrintOnPosition(dwarf.startX, dwarf.y, dwarf.str, dwarf.color);

            // Printing the rocks and the dwarf

            bool newObjectOnTheLeftOfDwarf;
            bool newObjectOnTheRightOfDwarf;

            foreach (ConsoleObject rock in rocks)
            {
                //check for collision
                newObjectOnTheLeftOfDwarf = rock.endX < dwarf.startX;
                newObjectOnTheRightOfDwarf = rock.startX > dwarf.endX;

                if ((rock.y == dwarf.y) && (!newObjectOnTheLeftOfDwarf && !newObjectOnTheRightOfDwarf))
                {
                    rocks.Clear();
                    PrintOnPosition(dwarf.startX, dwarf.y, "XXX", ConsoleColor.Red);
                    livesCount--;
                    increasePointsIterations = 0;
                    break;
                }

                PrintOnPosition(rock.startX, rock.y, rock.str, rock.color);
            }
            //----------------------------------------

            if (livesCount == 0)
            {
                Console.Clear();
                PrintUserInformation();
                PrintOnPosition(3, 5, "Game Over!!!", ConsoleColor.Red);
                PrintOnPosition(3, 7, "Press any key to exit...", ConsoleColor.Red); ;
                Console.ReadKey();
                Environment.Exit(0);
            }
            if (increasePointsIterations < Console.WindowHeight / 2)
            {
                increasePointsIterations++;
            }
            else
            {
                increasePointsIterations = 0;
                points = points + 100;
            }


            speed += acceleration;
            if (speed > 450)
            {
                speed = 450;
            }

            Thread.Sleep((int)(600 - speed)); // Pause the while loop for some time (ms)
        }
    }
}

