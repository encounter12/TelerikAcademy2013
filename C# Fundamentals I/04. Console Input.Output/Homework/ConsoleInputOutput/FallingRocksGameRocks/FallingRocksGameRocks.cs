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

class Program
{
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
        Console.WindowWidth = 100;
        Console.WindowHeight = 30;
    }

    static void Main()
    {
        SetConsoleWindowSize();
        RemoveScrollBars();
        Console.CursorVisible = false;
        Random randomGenerator = new Random();
        int maxRockSize = 3;
        int playfieldWidth = Console.WindowWidth - maxRockSize;        
        int[] rockRandomStartXArea = new int[2];        
        
        char[] rockSymbol = {'^', '@', '*', '&', '+', '%', '$', '#', '!', '.'};
        
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


        while (true)
        {

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

            List<ConsoleObject> newList = new List<ConsoleObject>();

            for (int i = 0; i < rocks.Count; i++)
            {
                ConsoleObject oldRock = rocks[i];
                ConsoleObject newObject = new ConsoleObject();
                newObject.startX = oldRock.startX;
                newObject.y = oldRock.y + 1;
                newObject.str = oldRock.str;
                newObject.color = oldRock.color;
                if (newObject.y < Console.WindowHeight)
                {
                    newList.Add(newObject);
                }
            }

            rocks = newList;

            Console.Clear();

            foreach (ConsoleObject rock in rocks)
            {
                PrintOnPosition(rock.startX, rock.y, rock.str, rock.color);
            }

            Thread.Sleep(350);            
        }

    }
}
