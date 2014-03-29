using System;
using System.Collections.Generic;
using System.Threading;
using ApacheCombat;
using System.Numerics;
using System.Diagnostics;

class Game
{
    public static void PlayApacheCombat()
    {
        Console.Clear();
        int lives = 3;
        int bombs = 1;
        BigInteger score = 0;
        int nukeCounter = 10;
        bool bombAway = false;
        int bombScoreCounter = 0;

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 0);
        Console.Write(new string('*', StartScreen.consoleWindowWidth));
        Window.UpdateScoreAndLives(lives, bombs, score, false, 0);
        Console.Write(new string('*', StartScreen.consoleWindowWidth));


        Helicopter helicopter = new Helicopter();

        helicopter.SetStartPosition(15, StartScreen.playgroundHeight / 2 - helicopter.Height / 2 - 2);

        List<Obstacle> obstacles = new List<Obstacle>();
        List<Shot> shots = new List<Shot>();

        Window.HelicopterInitialPrint(helicopter);

        int mainLoopCount = 0;
        int createRocksInMillisecs = 5000;
        int createGroundTargetInMillisecs = 10000;
        int moveObstaclesInMillisecs = 200;
        int moveShotsInMillisecs = 15;


        Stopwatch createRocksStopwatch = new Stopwatch();
        createRocksStopwatch.Start();

        Stopwatch createGroundTargetsStopwatch = new Stopwatch();
        createGroundTargetsStopwatch.Start();

        Stopwatch moveObstaclesStopwatch = new Stopwatch();
        moveObstaclesStopwatch.Start();

        Stopwatch moveShotsStopwatch = new Stopwatch();
        moveShotsStopwatch.Start();

        Stopwatch speedWatch = new Stopwatch();
        speedWatch.Start();

        Stopwatch densityWatch = new Stopwatch();
        densityWatch.Start();
               
        obstacles.Add(ObstacleGenerator.CreateRock());

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    helicopter.MoveUp();
                    Collision.HelicopterObstacleColision(obstacles, helicopter, ref lives,ref score, bombs);
                    Window.PrintHelicopter(helicopter);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    helicopter.MoveDown();
                    Collision.HelicopterObstacleColision(obstacles, helicopter, ref lives,ref score, bombs);
                    Window.PrintHelicopter(helicopter);
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    helicopter.MoveLeft();
                    Collision.HelicopterObstacleColision(obstacles, helicopter, ref lives,ref score, bombs);
                    Window.PrintHelicopter(helicopter);
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    helicopter.MoveRight();
                    Collision.HelicopterObstacleColision(obstacles, helicopter, ref lives,ref score, bombs);
                    Window.PrintHelicopter(helicopter);
                }
                else if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    shots.Add(helicopter.Shoot());
                }

                else if (keyInfo.Key == ConsoleKey.Z)
                {
                    if (!bombAway)
                    {
                        if (bombs != 0)
                        {
                            bombAway = true;
                            bombs--;
                        }
                    }
                    Console.SetCursorPosition(0, Console.CursorTop);
                    if (Console.CursorTop == 2)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(' ');
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
            }

            if (createRocksStopwatch.ElapsedMilliseconds >= createRocksInMillisecs)
            {
                obstacles.Add(ObstacleGenerator.CreateRock());
                createRocksStopwatch.Restart();
            }

            if (createGroundTargetsStopwatch.ElapsedMilliseconds >= createGroundTargetInMillisecs)
            {
                obstacles.Add(ObstacleGenerator.CreateGroundTaget());
                createGroundTargetsStopwatch.Restart();
            }

            if (moveShotsStopwatch.ElapsedMilliseconds >= moveShotsInMillisecs)
            {
                for (int i = 0; i < shots.Count; i++)
                {
                    shots[i].MoveRight();
                    bool hit = false;
                    Collision.HandleShotObstacleCollisions(obstacles, shots[i], ref hit, lives, ref score, bombs);
                    if (hit)
                    {
                        shots.Remove(shots[i]);
                        i--;
                        if (bombScoreCounter >= 100)
                        {
                            if (bombs < 3)
                            {
                                bombs++;
                            }
                            bombScoreCounter = 0;
                        }
                        bombScoreCounter += 10;
                    }
                    else
                    {
                        Window.PrintShot(shots[i]);

                        if (shots[i].EndX >= StartScreen.consoleWindowWidth)
                        {
                            if (shots[i].EndX == StartScreen.consoleWindowWidth + 1)
                            {
                                Window.DeleteShot(shots[i]);
                            }
                            shots.Remove(shots[i]);
                            i--;
                        }
                    }
                }

                moveShotsStopwatch.Restart();
            }

            if (moveObstaclesStopwatch.ElapsedMilliseconds >= moveObstaclesInMillisecs)
            {
                for (int i = 0; i < obstacles.Count; i++)
                {
                    obstacles[i].MoveLeft();
                    bool hit = false;

                    if (obstacles.Count > 0)
                    {
                        Collision.HandleObstacleCollisionsWithShots(obstacles, obstacles[i], shots, ref hit, lives, ref score, bombs); 
                    }
                   

                    if (hit && i > 0)
                    {
                        i--;
                    }

                    if (obstacles.Count > 0)
                    {
                        Collision.ObstacleHelicopterColision(obstacles, obstacles[i], helicopter, ref hit, ref lives, ref score, bombs);
                    }
                                                         
                    if (hit)
                    {                        
                        i--;
                        if (bombScoreCounter >= 100)
                        {
                            if (bombs < 3)
                            {
                                bombs++;
                            }
                            bombScoreCounter = 0;
                        }
                        bombScoreCounter += 10;
                    }
                    else
                    {
                        Window.PrintObstacle(obstacles[i]);

                        //checks if obstacle has exit the console and if so removes it from the obstacles list.  
                        if (obstacles[i].EndX < 0)
                        {
                            obstacles.Remove(obstacles[i]);
                        }
                    }
                }

                moveObstaclesStopwatch.Restart();
            }

            if (bombAway)
            {
                if (nukeCounter == 0)
                {
                    bombAway = false;
                    nukeCounter = 10;
                    Collision.NuclearBombExplosion(obstacles, ref score);
                    Window.NuclearBOMB(helicopter);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 0);
                    Console.Write(new string('*', StartScreen.consoleWindowWidth));
                    Window.UpdateScoreAndLives(lives, bombs, score, false, 0);
                    Console.Write(new string('*', StartScreen.consoleWindowWidth));
                }
                else
                {
                    if (Window.nukeSlowDownABit == 20000)
                    {
                        nukeCounter--;
                        Window.UpdateScoreAndLives(lives, bombs, score, true, nukeCounter);
                        Window.nukeSlowDownABit = 0;
                    }
                    else
                    {
                        Window.nukeSlowDownABit++;
                    }
                }
            }

            if (speedWatch.ElapsedMilliseconds >= 5000 && moveObstaclesInMillisecs >= 60)
            {                
                moveObstaclesInMillisecs -= 5;
                createRocksInMillisecs -= 150;
                speedWatch.Restart();
            }           
            
            mainLoopCount = (mainLoopCount + 1) % int.MaxValue;                        
        }
    }
}