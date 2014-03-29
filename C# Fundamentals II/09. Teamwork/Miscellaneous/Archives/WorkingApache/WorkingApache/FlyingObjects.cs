using System;
using System.Collections.Generic;
using System.Numerics;

class FlyingObjects
{
    
    static Random rnd = new Random();
    public int x { get; set; }
    public int y { get; set; }
    static int size = 1;

    public FlyingObjects(char[,] playGround)
    {
        y = rnd.Next(1, 25);
        x = 122;

        playGround[y, x] = '#';
        playGround[y, x - 1] = '#';
        playGround[y, x + 1] = '#';
        playGround[y - 1, x] = '#';
        playGround[y + 1, x] = '#';
    }

    public void MoveFlyingObjects(char[,] playGround, List<FireMissile> missle, List<FireBomb> bomb, ref bool endGame, ref bool delete, ref bool canAdd, ref BigInteger playerScore)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        if (x - 2 >= 0)
        {
            if (playGround[y, x - 2] != ' ' || playGround[y + 1, x - 1] != ' ' || playGround[y - 1, x - 1] != ' ')
            {
                if (playGround[y, x - 2] == '@' || playGround[y + 1, x - 1] == '@' || playGround[y - 1, x - 1] == '@' || playGround[y, x - 2] == '_' || playGround[y + 1, x - 1] == '_' || playGround[y - 1, x - 1] == '_')
                { 
                    endGame = true;
                }
                else if (playGround[y, x - 2] == '-' || playGround[y + 1, x - 1] == '-' || playGround[y - 1, x - 1] == '-')
                 {
                    if (missle.Count > 0)
                    {
                        missle[0].delete(playGround);
                    }

                    missle.RemoveAt(0);
                    playerScore += 5;
                    delete = true;
                    this.delete(playGround);
                    Apache.ScoreUpdate(playerScore);
                }
                else
                {
                    bomb[0].delete(playGround);
                    playerScore += 5;
                    delete = true;
                    this.delete(playGround);
                    Apache.ScoreUpdate(playerScore);
                }
             }
            else
            {
                playGround[y, x + 1] = ' ';
                playGround[y - 1, x] = ' ';
                playGround[y + 1, x] = ' ';

                x--;

                playGround[y, x - 1] = '#';
                playGround[y - 1, x] = '#';
                playGround[y + 1, x] = '#';

                if (x - 1 < 120 && x - 1 >= 0)
                {
                    Console.SetCursorPosition(x - 1, y + 5);
                    Console.WriteLine('#');
                }
                if (x < 120 && x >= 0)
                {
                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine('#');
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine('#');
                }
                if (x + 1 < 120 && x + 1 >= 0)
                {
                    canAdd = true;
                    Console.SetCursorPosition(x + 1, y + 4);
                    Console.WriteLine(' ');
                    Console.SetCursorPosition(x + 1, y + 5);
                    Console.WriteLine('#');
                    Console.SetCursorPosition(x + 1, y + 6);
                    Console.WriteLine(' ');
                }
                if (x + 2 < 120 && x + 2 >= 0)
                {
                    Console.SetCursorPosition(x + 2, y + 5);
                    Console.WriteLine(' ');
                }
            }
        }
        else
        {
            if (x - 1 == 0)
            {
                playGround[y, x + 1] = ' ';
                playGround[y+1, x ] = ' ';
                playGround[y-1, x] = ' ';

                x--;

                playGround[y-1, x ] = '#';
                playGround[y+1, x ] = '#';

                Console.SetCursorPosition(0, y + 4);
                Console.Write("# ");
                Console.SetCursorPosition(0, y + 5);
                Console.Write("## ");
                Console.SetCursorPosition(0, y + 6);
                Console.Write("# ");

            }
            else if (x == 0)
            {
                playGround[y, x + 1] = ' ';
                playGround[y + 1, x] = ' ';
                playGround[y - 1, x] = ' ';

                x--;

                Console.SetCursorPosition(0, y + 4);
                Console.Write(" ");
                Console.SetCursorPosition(0, y + 5);
                Console.Write("# ");
                Console.SetCursorPosition(0, y + 6);
                Console.Write("  ");
            }
            else if (x + 1 == 0)
            {
                 playGround[y, x + 1] = ' ';

                Console.SetCursorPosition(0, y + 5);
                Console.Write(' ');
                delete = true;
            }
        }
    }

    public void delete(char[,] playGround)
    {
        Console.SetCursorPosition(x, y + 4);
        Console.Write(' ');
        Console.SetCursorPosition(x - 1, y + 5);
        Console.Write("   ");
        Console.SetCursorPosition(x, y + 6);
        Console.Write(' ');

        playGround[y,x] = ' ';
        playGround[ y - 1,x] = ' ';
        playGround[ y + 1,x] = ' ';
        playGround[y,x - 1] = ' ';
        playGround[y,x + 1] = ' ';
    }
}

