using System;
using System.Collections.Generic;

class Mountain
{
    static Random rnd = new Random();
    public int size;
    public int x;
    public int y;

    public Mountain(char[,] playGround)
    {
        size = 2;
        while (size % 2 != 1)
        {
            size = rnd.Next(7,26);
        }

        x = 120 + size / 2 + 1;
        y = 39;

        int row = playGround.GetLength(0) - 2;
        for (int i = 120; i < 120 + (size / 2); i++)
        {
            playGround[row, i] = '/';
            row--;
        }
        
        for (int i = 120 + (size/ 2); i < 120 + size; i++)
        {
            playGround[row, i] = '\\';
            row++;
        }

    }

    public void MoveMountain(char[,] playGround,List<FireMissile> missle,List<FireBomb> bomb,ref bool endGame,ref bool delete,ref bool canAdd)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = x-(size/2)-2; i <x; i++)
        {
            if (i >= 0)
            {
                if (playGround[y, i] != ' ')
                {
                    if (playGround[y, i] == '@' || playGround[y, i] == '_')
                    {
                        endGame = true;
                    }
                    else if (playGround[y, i] == '-')
                    {
                        if (missle.Count != 0)
                        {
                            missle[0].delete(playGround);
                        }
                    }
                    else
                    {
                        if (bomb.Count != 0)
                        {
                            bomb[0].delete(playGround);
                        }
                    }
                }
            }
            if (i < 120&&i>=0)
            {
                Console.SetCursorPosition(i, y + 5);
                Console.Write('/');
            }
            if (i >= 0)
            {
                playGround[y, i] = '/';
            }
            y--;
        }

        if (x >= 0)
        {
            if (playGround[y, x] != ' ')
            {
                if (playGround[y, x] == '@' || playGround[y, x] == '_')
                {
                    endGame = true;
                }
                else if (playGround[y, x] == '-')
                {
                    if (missle.Count != 0)
                    {
                        missle[0].delete(playGround);
                    }
                }
                else
                {
                    if (bomb.Count != 0)
                    {
                        bomb[0].delete(playGround);
                    }
                }
            }
        }
        if (x < 120 && x >= -1)
        {
            if (x > -1)
            {
                Console.SetCursorPosition(x, y + 5);
                Console.Write('\\');
            }
            if (x + 1 < 120)
            {
                Console.SetCursorPosition(x + 1, y + 5);
                Console.Write(' ');
            }
        }
        if (x > 0)
        {
            playGround[y, x] = '\\';
        }
        if (x >= -1)
        {
            playGround[y, x + 1] = ' ';
        }
        y++;

        for (int i = x+1; i <= x+(size/2)+1; i++)
        {
            if (i < 120 && i >= -1)
            {
                if (i > -1)
                {
                    Console.SetCursorPosition(i, y + 5);
                    Console.Write('\\');
                }
                if (i+1 < 120)
                {
                    Console.SetCursorPosition(i+1, y + 5);
                    Console.Write(' ');
                }
            }
            if (i > 0)
            {
                playGround[y, i] = '\\';
            }
            if (i >= -1)
            {
                playGround[y, i + 1] = ' ';
            }
            y++;
        }

        if (x + (size / 2) + 2 < 120 && x + (size / 2) + 2 >= -1)
        {
            if (x + (size / 2) + 2 > -1)
            {
                Console.SetCursorPosition(x + (size / 2) + 2, y + 5);
                Console.Write('\\');
            }
            if (x + (size / 2) + 3 < 120)
            {
                Console.SetCursorPosition(x + (size / 2) + 3, y + 5);
                Console.Write(' ');
            }
        }
        if (x + (size / 2) + 2 >= 0)
        {
            playGround[y, x + (size / 2) + 2] = '\\';
        }
        else
        {
            delete = true;
        }
        playGround[y, x + (size / 2) + 3] = ' ';

        x--;
        if (x + (size / 2) + 3 <= 120)
        {
            canAdd = true;
        }
    }
}
