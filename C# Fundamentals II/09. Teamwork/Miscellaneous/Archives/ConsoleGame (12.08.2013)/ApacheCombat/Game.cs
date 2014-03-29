using System;
using System.Collections.Generic;
using System.Threading;

namespace ApacheCombat
{
    class Game
    {
        public static int consoleWindowWidth = 120;
        public static int consoleWindowHeight = 46;
        

        static bool collisionExists = false;

        static void RemoveScrollBars()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        static void HandleCollision(List<Obstacle> obstacles, Helicopter helicopter, out bool collision)
        {
            collision = false;

            foreach (Obstacle rock in obstacles)
            {
                if ((rock.StartX == helicopter.EndX && !(rock.EndY < helicopter.StartY || rock.StartY > helicopter.EndY))
                || ((rock.EndY == helicopter.StartY || rock.StartY == helicopter.EndY) && !(rock.EndX < helicopter.StartX || rock.StartX > helicopter.EndX)))
                {
                    Console.Clear();
                    Console.SetCursorPosition(consoleWindowWidth / 2 - 8, consoleWindowHeight / 2);
                    collision = true;
                    Console.Write("Crash!!!");
                    Console.ReadLine();
                }
            }
            
        }

        static void Main()
        {
            Console.SetWindowSize(consoleWindowWidth, consoleWindowHeight);
            RemoveScrollBars();
            Console.CursorVisible = false;
            StartScreen.DrawAsciiHelicopter("../../txt/01-StartScreen.txt");
            StartScreen.MenuChoice();

            Helicopter helicopter = new Helicopter();

            helicopter.SetStartPosition(15, Console.WindowHeight / 2 - helicopter.Height / 2 - 2);

            List<Obstacle> obstacles = new List<Obstacle>();

            Window.HelicopterInitialPrint(helicopter);

            int mainLoopCount = 0;
            int createRockInLoops = 300000;
            int createGroundTargetInLoops = 500000;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {                        
                        helicopter.MoveUp();
                        Window.PrintHelicopter(helicopter);
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        helicopter.MoveDown();
                        Window.PrintHelicopter(helicopter);
                    }
                }
               
                if (mainLoopCount % createRockInLoops == 0)
                {
                    obstacles.Add(ObstacleGenerator.CreateRock());
                    
                }

                if (mainLoopCount % createGroundTargetInLoops == 0)
                {
                    obstacles.Add(ObstacleGenerator.CreateGroundTaget());
                }

                HandleCollision(obstacles, helicopter, out collisionExists);
                if (collisionExists == true)
                {
                    break;
                }

                if (mainLoopCount % 20000 == 0)
                {
                    for (int i = 0; i < obstacles.Count; i++)
                    {
                        Window.PrintObstacle(obstacles[i]);

                        obstacles[i].MoveLeft();
                       
                        //checks if obstacle has exit the console and if so removes it from the obstacles list.  
                        if (obstacles[i].EndX < 0)
                        {
                            obstacles.Remove(obstacles[i]);
                        }
                    }
                }
                                                                           
                mainLoopCount++;

                if (mainLoopCount == int.MaxValue)
                {
                    mainLoopCount = 0;
                }
            }
        }
    }
}