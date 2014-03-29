using System;
using System.Collections.Generic;
using System.Numerics;

class FireMissile
{
    public int x { get; set; }
    public int y { get; set; }

    public FireMissile(char[,] playGround, int apX, int apY, ref bool hit, ref bool endGame)
    {
        if (apX <= 117)
        {
            x = apX + 2;
            y = apY;
            if (playGround[y, x] != ' ')
            {
                hit = true;
                endGame = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                hit = false;
                Console.SetCursorPosition(x, y + 5);
                Console.WriteLine('-');
                Console.SetCursorPosition(apX, apY + 5);
            }
        }
        else
        {
            hit = true;
        }
    }

    public void MoveMissile(char[,] playGround, List<FlyingObjects> flyingObjects, List<FireBomb> bomb,ref bool hit,ref BigInteger score)
    {
        if (x < 119)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (playGround[y, x + 1] != ' ')
            {
                if (playGround[y, x + 1] == '*')
                {
                    playGround[y, x] = ' ';
                    playGround[y, x + 1] = ' ';
                    this.delete(playGround);
                    bomb[0].delete(playGround);
                    bomb.Remove(bomb[0]);
                    hit = true;
                }
                else
                {
                    if (playGround[y, x + 1] == '#')
                    {
                        this.delete(playGround);
                        hit = true;
                        foreach (var flyingObject in flyingObjects)
                        {
                            if (((x +1)== flyingObject.x && y == (flyingObject.y + 1)) || ((x+1) == (flyingObject.x - 1) && y == flyingObject.y) || ((x+1) == flyingObject.x && y == (flyingObject.y - 1)))
                            {
                                score += 5;
                                Apache.ScoreUpdate(score);
                                flyingObject.delete(playGround);
                                flyingObjects.Remove(flyingObject);
                                break;
                            }
                        }
                    }
                    else
                    {
                        this.delete(playGround);
                        hit = true;
                    }
                }
            }
            else
            {
                playGround[y, x] = ' ';
                playGround[y, x + 1] = '-';
                x++;
                Console.SetCursorPosition(x - 1, y + 5);
                Console.Write(" -");
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
