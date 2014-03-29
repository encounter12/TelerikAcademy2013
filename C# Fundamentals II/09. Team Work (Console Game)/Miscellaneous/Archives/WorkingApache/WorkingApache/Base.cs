using System;
using System.Collections.Generic;

class Base
{
    public int x { get; set; }
    public int y { get; set; }

    public Base(char[,] playGround)
    {
        x = 121;
        y = 39;

        playGround[ y,x-1] = '%';
        playGround[y,x] = '%';
        playGround[ y,x+1] = '%';
        playGround[y-1,x-1] = '%';
        playGround[y-1,x] = '%';
        playGround[y-1,x+1] = '%';
        playGround[y-2,x-1] = '^';
        playGround[y-2,x] = '^';
        playGround[y-2,x+1] = '^';
    }

    public void MoveBase(char[,] playGround, List<FireMissile> missle, List<FireBomb> bomb, ref bool endGame, ref bool hit)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        if (x - 1 > 0)
        {
            if (playGround[y, x - 2] == '*' || playGround[y - 1, x - 2] == '*' || playGround[y - 2, x - 2] == '*')
            {
                hit = true;
                bomb[0].delete(playGround);
                bomb.RemoveAt(0);
            }
            else
            {
                playGround[y, x + 1] = ' ';
                playGround[y - 1, x + 1] = ' ';
                playGround[y - 2, x + 1] = ' ';

                playGround[y, x - 2] = '%';
                playGround[y - 1, x - 2] = '%';
                playGround[y - 2, x - 2] = '^';

                if (x < 119)
                {
                    Console.SetCursorPosition(x - 2, y + 3);
                    Console.Write("^^^ ");
                    Console.SetCursorPosition(x - 2, y + 4);
                    Console.Write("&&& ");
                    Console.SetCursorPosition(x - 2, y + 5);
                    Console.Write("&&& ");
                }
                else if (x < 120)
                {
                    Console.SetCursorPosition(x - 2, y + 3);
                    Console.Write('^');
                    Console.SetCursorPosition(x - 2, y + 4);
                    Console.Write('&');
                    Console.SetCursorPosition(x - 2, y + 5);
                    Console.Write('&');
                }
                else if (x - 1 < 120)
                {
                    Console.SetCursorPosition(x - 1, y + 3);
                    Console.Write('^');
                    Console.SetCursorPosition(x - 1, y + 4);
                    Console.Write('&');
                    Console.SetCursorPosition(x - 1, y + 5);
                    Console.Write('&');
                }
                else if (x - 2 < 120)
                {
                    Console.SetCursorPosition(x - 2, y + 3);
                    Console.Write('^');
                    Console.SetCursorPosition(x - 2, y + 4);
                    Console.Write('&');
                    Console.SetCursorPosition(x - 2, y + 5);
                    Console.Write('&');
                }
                x--;
            }
        }
        else
        {
            if (x - 1 == 0||x==0||x+1==0)
            {
                playGround[y, x + 1] = ' ';
                playGround[y - 1, x + 1] = ' ';
                playGround[y - 2, x + 1] = ' ';

                Console.SetCursorPosition(x + 1, y + 3);
                Console.Write(' ');
                Console.SetCursorPosition(x + 1, y + 4);
                Console.Write(' ');
                Console.SetCursorPosition(x + 1, y + 5);
                Console.Write(' ');

                if (x + 1 == 0)
                {
                    hit = true;
                }
                x--;
            }
        }
    }

    public void delete(char[,] playGround)
    {
        playGround[y, x - 1] = ' ';
        playGround[y, x] = ' ';
        playGround[y, x + 1] = ' ';
        playGround[y - 1, x - 1] = ' ';
        playGround[y - 1, x] = ' ';
        playGround[y - 1, x + 1] = ' ';
        playGround[y - 2, x - 1] = ' ';
        playGround[y - 2, x] = ' ';
        playGround[y - 2, x + 1] = ' ';

        Console.SetCursorPosition(x - 1, y +3 );
        Console.Write("   ");
        Console.SetCursorPosition(x - 1, y +4);
        Console.Write("   ");
        Console.SetCursorPosition(x - 1, y+5);
        Console.Write("   ");
    }
}

