using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Apache
{
    static Random rnd = new Random();
    public static void PlayApacheCombat()
    {
        for (int i = 0; i < 48; i++)
        {
            Thread.Sleep(10);
            Console.WriteLine();
        }
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        //Making playground
        Console.SetWindowSize(120, 47);
        
        char[,] playGround = new char[41, 150];
        BigInteger playerScore = 0;
        int change = 100;
        Console.ForegroundColor = ConsoleColor.White;
        for (int i = 0; i < playGround.GetLength(1) - 30; i++)
        {
            Console.Write('*');
        }

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Player score: {0}", playerScore);
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.White;
        for (int i = 0; i < playGround.GetLength(1) - 30; i++)
        {
            Console.Write('*');
        }

        for (int i = 0; i < playGround.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < playGround.GetLength(1); j++)
            {
                playGround[i, j] = ' ';
                if (j < 120)
                {
                    Console.Write(' ');
                }
            }
        }
        for (int i = 0; i < playGround.GetLength(1) - 30; i++)
        {
            playGround[playGround.GetLength(0) - 1, i] = '_';
            Console.Write('_');
        }

        //Making helicopter
        Helicopter apache = new Helicopter(playGround);

        List<Mountain> mountains = new List<Mountain>();
        Mountain mountainObject = new Mountain(playGround);
        mountains.Add(mountainObject);

        int sparePositionsForMountain = rnd.Next(4, 16);
        int counterForSpareMountain = 0;

        List<FlyingObjects> flyingObjects = new List<FlyingObjects>();
        FlyingObjects flyingObject = new FlyingObjects(playGround);
        flyingObjects.Add(flyingObject);

        int sparePositionsForFlyingObjects = rnd.Next(25, 40);
        int counterForSpareFlyingObject = 0;

        List<FireMissile> missile = new List<FireMissile>();
        bool hit = false;

        List<FireBomb> bombs = new List<FireBomb>();

        List<Base> bases = new List<Base>();
        bool addBases = true;
        int passThisMountain = rnd.Next(3, 8);
        int passedMountains=0;


        int missileAndBombCounter = 0;
        int repeatedCounterForMissilesAndBombs = 100;

        bool endGame = false;

        //Real game
        int whenToMoveMountainAndFlyingObjects = 3000;
        int moveMountainAndFlyingObjectsCounter = 1;

        Console.SetCursorPosition(apache.x, apache.y + 5);

        while (!endGame)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key.ToString()!=ConsoleSpecialKey.ControlC.ToString())
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.Z:
                            {
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(playGround[apache.y, Console.CursorLeft]);
                                Console.SetCursorPosition(apache.x, Console.CursorTop);
                                if (bombs.Count == 0)
                                {
                                    hit = false;
                                    FireBomb bomb = new FireBomb(playGround, apache.x, apache.y, ref hit, ref endGame);
                                    bombs.Add(bomb);
                                    if (hit)
                                    {
                                        bombs.RemoveAt(0);
                                    }
                                    else
                                    {
                                        bombs[0].MoveBomb(playGround, flyingObjects, bases, ref hit, ref playerScore);
                                        if (hit)
                                        {
                                            bombs.RemoveAt(0);
                                        }
                                    }
                                }
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            {
                                Console.SetCursorPosition(apache.x, Console.CursorTop);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(playGround[Console.CursorTop - 5, Console.CursorLeft]);
                                Console.SetCursorPosition(apache.x, Console.CursorTop);
                                apache.MoveHelicopterUp(playGround, ref endGame);
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            {
                                Console.SetCursorPosition(apache.x, Console.CursorTop);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(playGround[Console.CursorTop - 5, Console.CursorLeft]);
                                Console.SetCursorPosition(apache.x, Console.CursorTop);
                                apache.MoveHelicopterDown(playGround, ref endGame);
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            {
                                Console.SetCursorPosition(apache.x, Console.CursorTop);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(playGround[Console.CursorTop - 5, Console.CursorLeft]);
                                Console.SetCursorPosition(apache.x, Console.CursorTop);
                                apache.MoveHelicopterLeft(playGround, ref endGame);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            {
                                Console.SetCursorPosition(apache.x, Console.CursorTop);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(playGround[Console.CursorTop - 5, Console.CursorLeft]);
                                Console.SetCursorPosition(apache.x, Console.CursorTop);
                                apache.MoveHelicopterRight(playGround, ref endGame);
                            }
                            break;
                        case ConsoleKey.Spacebar:
                            {
                                Console.SetCursorPosition(apache.x, apache.y + 5);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(playGround[apache.y, Console.CursorLeft]);
                                Console.SetCursorPosition(apache.x, Console.CursorTop);
                                if (missile.Count == 0)
                                {
                                    hit = false;
                                    FireMissile missile1 = new FireMissile(playGround, apache.x, apache.y, ref hit, ref endGame);
                                    missile.Add(missile1);
                                    if (hit)
                                    {
                                        missile.RemoveAt(0);
                                    }
                                    else
                                    {
                                        missile[0].MoveMissile(playGround, flyingObjects, bombs, ref hit, ref playerScore);
                                        if (hit)
                                        {
                                            missile.RemoveAt(0);
                                        }
                                    }
                                }
                            }
                            break;
                        default:
                            {
                                Console.SetCursorPosition(apache.x, Console.CursorTop);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(playGround[Console.CursorTop - 5, Console.CursorLeft]);
                                Console.SetCursorPosition(apache.x, Console.CursorTop);
                            }
                            break;
                    }
                }
                else
                {
                }
                Console.SetCursorPosition(apache.x, apache.y + 5);
            }

            if (missileAndBombCounter == repeatedCounterForMissilesAndBombs)
            {
                if (missile.Count != 0)
                {
                    missile[0].MoveMissile(playGround, flyingObjects, bombs, ref hit, ref playerScore);
                    if (hit)
                    {
                            missile.RemoveAt(0);
                    }
                }
                if (bombs.Count != 0)
                {
                    bombs[0].MoveBomb(playGround, flyingObjects, bases, ref hit, ref playerScore);
                    if (hit)
                    {
                        bombs.RemoveAt(0);
                    }
                }

                missileAndBombCounter = 0;
            }
            else
            {
                missileAndBombCounter++;
            }


            moveMountainAndFlyingObjectsCounter++;
            if (moveMountainAndFlyingObjectsCounter == whenToMoveMountainAndFlyingObjects)
            {
                bool canAdd = false;
                bool delete = false;
                moveMountainAndFlyingObjectsCounter = 1;
                for (int i = 0; i < mountains.Count - 1; i++)
                {
                    delete = false;
                    mountains[i].MoveMountain(playGround, missile, bombs, ref endGame, ref delete, ref canAdd);
                    if (delete)
                    {
                        mountains.Remove(mountains[i]);
                    }
                }
                if (mountains.Count > 0)
                {
                    canAdd = false;
                    delete = false;
                    mountains[mountains.Count - 1].MoveMountain(playGround, missile, bombs, ref endGame, ref delete, ref canAdd);
                    if (delete)
                    {
                        mountains.Remove(mountains[mountains.Count - 1]);
                    }
                }
                if (canAdd)
                {
                    if (sparePositionsForMountain > 5 && addBases)
                    {
                        if (passedMountains >= passThisMountain&&sparePositionsForMountain- counterForSpareMountain>=4)
                        {
                            addBases = false;
                            Base base1 = new Base(playGround);
                            bases.Add(base1);
                            passedMountains = 0;
                            passThisMountain = rnd.Next(4, 8);
                        }
                        else
                        {
                            passedMountains++;
                        }
                    }

                    if (counterForSpareMountain == sparePositionsForMountain)
                    {
                        Mountain mountainObject1 = new Mountain(playGround);

                        mountains.Add(mountainObject1);
                        counterForSpareMountain = 0;
                        sparePositionsForMountain = rnd.Next(4, 16);
                        addBases = true;
                    }
                    else
                    {
                        counterForSpareMountain++;
                    }
                }
                //moved mountains

                for (int i = 0; i < flyingObjects.Count - 1; i++)
                {
                    delete = false;
                    flyingObjects[i].MoveFlyingObjects(playGround, missile, bombs, ref endGame, ref delete, ref canAdd, ref playerScore);
                    if (delete)
                    {
                        flyingObjects.Remove(flyingObjects[i]);
                    }
                }

                if (flyingObjects.Count > 0)
                {
                    canAdd = false;
                    delete = false;
                    flyingObjects[flyingObjects.Count - 1].MoveFlyingObjects(playGround, missile, bombs, ref endGame, ref delete, ref canAdd, ref playerScore);
                    if (delete)
                    {
                        flyingObjects.Remove(flyingObjects[flyingObjects.Count - 1]);
                    }
                }

                if (canAdd)
                {
                    if (counterForSpareFlyingObject == sparePositionsForFlyingObjects)
                    {
                        FlyingObjects flyingObject1 = new FlyingObjects(playGround);
                        flyingObjects.Add(flyingObject1);
                        counterForSpareFlyingObject = 0;
                        sparePositionsForFlyingObjects = rnd.Next(25, 40);
                    }
                    else
                    {
                        counterForSpareFlyingObject++;
                    }
                }
                //moved flyingObjects

                if (bases.Count > 0)
                {
                    for (int i = 0; i < bases.Count; i++)
                    {
                        hit = false;
                        bases[i].MoveBase(playGround, missile, bombs, ref endGame, ref hit);
                        if (hit)
                        {
                            bases.RemoveAt(i);
                        }
                    }
                }

                if (playerScore==change)
                {
                    change += 100;
                    whenToMoveMountainAndFlyingObjects -= 50;
                }
                Console.SetCursorPosition(apache.x, apache.y + 5);
            }
        }
        EndGameScreen._EndGameScreen(playerScore);
    }

    public static void ScoreUpdate(BigInteger score)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(0, 2);
        Console.WriteLine(" Player score: {0}", score);
    }
}