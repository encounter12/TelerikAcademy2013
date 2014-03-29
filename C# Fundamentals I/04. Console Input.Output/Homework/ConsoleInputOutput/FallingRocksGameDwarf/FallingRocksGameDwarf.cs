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
class FallingRocks
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

    static int SetDwardInitialPositionToMiddle(int playfieldWidth, int dwarfStringLength)
    {
        int dwarfStartX = (playfieldWidth / 2) - (dwarfStringLength / 2);
        return dwarfStartX;
    }
    static void Main()
    {
        SetConsoleWindowSize();
        RemoveScrollBars();
        ConsoleObject dwarf = new ConsoleObject(); 
        dwarf.str = "(O)";
        int playfieldWidth = Console.WindowWidth - dwarf.str.Length;
        dwarf.startX = SetDwardInitialPositionToMiddle(playfieldWidth, dwarf.str.Length);
        dwarf.endX = dwarf.startX + dwarf.str.Length - 1;
        dwarf.y = Console.WindowHeight - 1;        
        dwarf.color = ConsoleColor.Yellow;

        while (true)
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key==ConsoleKey.LeftArrow)
                {
                    if (dwarf.startX -1 >= 0)
                    {
                        dwarf.startX = dwarf.startX - 1;
                    }
                   
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.startX + 1 < playfieldWidth)
                    {
                        dwarf.startX = dwarf.startX + 1;
                    }                    
                }
            }

            Console.Clear();
            PrintOnPosition(dwarf.startX, dwarf.y, dwarf.str, dwarf.color);            
            Thread.Sleep(350);
        }            
    }
}

