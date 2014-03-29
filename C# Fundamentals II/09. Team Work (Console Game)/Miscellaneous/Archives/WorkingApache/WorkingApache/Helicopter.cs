using System;
using System.Collections.Generic;

class Helicopter
{
    public int x { get; set; }
    public int y { get; set; }
    public Helicopter(char[,] playGround)
    {
        x = 2;
        y = 39;

        Console.ForegroundColor = ConsoleColor.Blue;

        Console.SetCursorPosition(0, y +4);

        Console.WriteLine(" ___");
        Console.WriteLine("\\-@ ");

        playGround[y - 1, x - 1] = '_';
        playGround[y - 1, x] = '_';
        playGround[y - 1, x + 1] = '_';

        playGround[y, x] = '@';
        playGround[y, x - 1] = '-';
        playGround[y, x - 2] = '\\';
    }

    public void MoveHelicopterUp(char[,] playGround, ref bool endGame)
    {
        Console.ForegroundColor = ConsoleColor.Blue;

        if (y != 1)
        {
            if (playGround[y - 2, x] != ' ' || playGround[y - 2, x - 1] != ' ' || playGround[y - 2, x + 1] != ' ' || playGround[y - 1, x - 2] != ' ')
            {
                endGame = true;
            }
            else
            {
                Console.SetCursorPosition(x-2, y+5);
                Console.Write("   ");
                Console.SetCursorPosition(x-2, y +3);
                Console.Write(" ___");
                Console.SetCursorPosition(x - 2, y + 4);
                Console.Write("\\-@ ");

                //actually move the helicopter

                playGround[y, x] = ' ';
                playGround[y, x - 1] = ' ';
                playGround[y, x - 2] = ' ';

                y--;
                playGround[y - 1, x - 1] = '_';
                playGround[y - 1, x] = '_';
                playGround[y - 1, x + 1] = '_';

                playGround[y, x + 1] = ' ';
                playGround[y, x] = '@';
                playGround[y, x - 1] = '-';
                playGround[y, x - 2] = '\\';
            }
        }
    }

    public void MoveHelicopterDown(char[,] playGround, ref bool endGame)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        if (y != playGround.GetLength(0) - 2)
        {
            if (playGround[y + 1, x] != ' ' || playGround[y + 1, x - 1] != ' ' || playGround[y + 1, x - 2] != ' ' || playGround[y, x + 1] != ' ')
            {
                endGame = true;
            }
            else
            {
                Console.SetCursorPosition(x-2, y +4);
                Console.Write(string.Concat(playGround[0, y - 1].ToString(), "   "));
                Console.SetCursorPosition(x - 2, y + 5);
                Console.WriteLine(" ___");
                Console.SetCursorPosition(x - 2, y + 6);
                Console.WriteLine("\\-@ ");

                //actually move the helicopter

                playGround[y - 1, x - 1] = ' ';
                playGround[y - 1, x] = ' ';
                playGround[y - 1, x + 1] = ' ';

                y++;
                playGround[y - 1, x - 2] = ' ';
                playGround[y - 1, x - 1] = '_';
                playGround[y - 1, x] = '_';
                playGround[y - 1, x + 1] = '_';

                playGround[y, x] = '@';
                playGround[y, x - 1] = '-';
                playGround[y, x - 2] = '\\';
            }
        }
    }

    public void MoveHelicopterRight(char[,] playGround, ref bool endGame)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        if (x != 118)
        {
            if (playGround[y -1, x+2] != ' ' || playGround[y , x +1] != ' ')
            {
                endGame = true;
            }
            else
            {
                Console.SetCursorPosition(x - 2, y + 4);
                Console.Write("  ___");
                Console.SetCursorPosition(x - 2, y + 5);
                Console.WriteLine(" \\-@");

                //actually move the helicopter

                playGround[y - 1, x - 1] = ' ';
                playGround[y - 1, x + 2] = '_';

                x++;

                playGround[y, x] = '@';
                playGround[y, x - 1] = '-';
                playGround[y, x - 2] = '\\';
                playGround[y, x - 3] = ' ';
            }
        }
    }

    public void MoveHelicopterLeft(char[,] playGround, ref bool endGame)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        if (x != 2)
        {
            if (playGround[y, x-3] != ' ' || playGround[y - 1, x - 2] != ' ')
            {
                endGame = true;
            }
            else
            {
                Console.SetCursorPosition(x - 3, y + 4);
                Console.Write(" ___  ");
                Console.SetCursorPosition(x - 3, y + 5);
                Console.WriteLine("\\-@ ");

                //actually move the helicopter

                playGround[y - 1, x - 2] = '_';
                playGround[y - 1, x + 1] = ' ';

                x--;

                playGround[y, x+1] = ' ';
                playGround[y, x] = '@';
                playGround[y, x - 1] = '-';
                playGround[y, x - 2] = '\\';
            }
        }
    }
}
// ___
//\-@