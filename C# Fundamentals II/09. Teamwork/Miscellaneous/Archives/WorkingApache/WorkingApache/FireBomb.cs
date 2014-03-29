using System;
using System.Collections.Generic;
using System.Numerics;

class FireBomb
{
    public int x { get; set; }
    public int y { get; set; }

    public FireBomb(char[,] playGround, int apX, int apY, ref bool hit, ref bool endGame)
    {
        if (apY != 39 && apX < 118)
        {
            x = apX;
            y = apY + 1;

            if (playGround[y, x] != ' ')
            {
                endGame = true;
                hit = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                hit = false;
                playGround[y, x] = '*';
                Console.SetCursorPosition(x, y + 5);
                Console.Write('*');
            }
        }
        else
        {
            hit = true;
        }
    }

    public void MoveBomb(char[,] playGround, List<FlyingObjects> flyingObjects, List<Base> bases, ref bool hit, ref BigInteger score)
    {
        if (y < 39)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (playGround[y + 1, x] != ' ')
            {
                if (playGround[y + 1, x] == '^')
                {
                    for (int i = 0; i < bases.Count; i++)
                    {
                        if ((y + 1 == bases[i].y - 2 && x == bases[i].x - 1) || (y + 1 == bases[i].y - 2 && x == bases[i].x) || (y + 1 == bases[i].y - 2 && x == bases[i].x + 1))
                        {
                            bases[i].delete(playGround);
                            bases.RemoveAt(i);
                            this.delete(playGround);
                            hit = true;
                            score *= 2;
                            Apache.ScoreUpdate(score);
                        }
                    }
                }
                else if (playGround[y + 1, x] == '#')
                {
                    for (int i = 0; i < flyingObjects.Count; i++)
                    {
                        if ((y + 1 == flyingObjects[i].y && x == flyingObjects[i].x - 1) || (y + 1 == flyingObjects[i].y && x == flyingObjects[i].x + 1) || (y + 1 == flyingObjects[i].y - 1 && x == flyingObjects[i].x))
                        {
                            flyingObjects[i].delete(playGround);
                            flyingObjects.RemoveAt(i);
                            this.delete(playGround);
                            hit = true;
                            score += 5;
                            Apache.ScoreUpdate(score);
                        }
                    }
                }
                else
                {
                    this.delete(playGround);
                    hit = true;
                }
            }
            else
            {
                this.delete(playGround);
                y++;
                playGround[y, x] = '*';
                Console.SetCursorPosition(x, y + 5);
                Console.Write('*');
                hit = false;
            }
        }
        else
        {
            this.delete(playGround);
            hit = true;
        }
    }

    public void delete(char[,] playGround)
    {
        playGround[y, x] = ' ';
        Console.SetCursorPosition(x, y + 5);
        Console.Write(' ');
    }
}
