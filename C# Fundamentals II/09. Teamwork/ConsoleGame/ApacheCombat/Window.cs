using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;

class Window
{

    public static int nukeSlowDownABit = 0;
    //Obstacle  -----------------------------------------------------------------------------------------------------------------
    public static void PrintObstacle(Obstacle obstacle)
    {
        Console.ForegroundColor = obstacle.Color;
        if (obstacle.EndX >= StartScreen.consoleWindowWidth - 1)
        {
            PrintObstacleOnEntrance(obstacle);
        }
        else if (obstacle.StartX <= 0)
        {
            PrintObstacleOnExit(obstacle);
        }
        else
        {
            PrintObstacleInConsoleInnerPart(obstacle);
        }
        Console.ResetColor();
    }

    private static void PrintObstacleOnEntrance(Obstacle obstacle)
    {
        int currentRow = obstacle.StartY;
        int firstColumn = 0;  //obstacle's first column that should be printed on the console                    
        int lastColumn = StartScreen.consoleWindowWidth - obstacle.StartX - 1; //obstacle's last column that should be printed on the console

        for (int row = 0; row < obstacle.Height; row++)
        {
            Console.SetCursorPosition(obstacle.StartX, currentRow);

            for (int col = firstColumn; col <= lastColumn; col++)
            {
                Console.Write(obstacle.ObstacleRows[row, col]);
            }
            currentRow++;
        }
    }

    private static void PrintObstacleOnExit(Obstacle obstacle)
    {
        int currentRow = obstacle.StartY;
        int firstColumn = (-1) * obstacle.StartX;
        int lastColumn = obstacle.Width - 1;

        for (int row = 0; row < obstacle.Height; row++)
        {
            Console.SetCursorPosition(0, currentRow);

            for (int col = firstColumn; col <= lastColumn; col++)
            {
                Console.Write(obstacle.ObstacleRows[row, col]);
            }
            Console.Write(" ");
            currentRow++;
        }
    }

    public static void PrintObstacleInConsoleInnerPart(Obstacle obstacle)
    {
        Console.SetCursorPosition(0, StartScreen.consoleWindowHeight - 1);
        Console.MoveBufferArea(obstacle.StartX + 1, obstacle.StartY, obstacle.Width, obstacle.Height,
            obstacle.StartX, obstacle.StartY);
    }

    public static void DeleteAllObstacles(List<Obstacle> obstacles)
    {
        foreach (Obstacle obstacle in obstacles)
        {
            Window.DeleteObstacle(obstacle);
        }
    }

    public static void DeleteObstacle(Obstacle obstacle)
    {
        if (obstacle.StartX < StartScreen.consoleWindowWidth)
        {
            int currentRow = obstacle.StartY;
            for (int i = 0; i < obstacle.ObstacleRows.GetLength(0); i++)
            {
                Console.SetCursorPosition(obstacle.StartX, currentRow);
                for (int j = 0; j < obstacle.ObstacleRows.GetLength(1); j++)
                {
                    Console.Write(" ");
                }
                currentRow++;
            }
        }
    }

    //Helicopter  ---------------------------------------------------------------------------------------------------------
    public static void HelicopterInitialPrint(Helicopter helicopter)
    {
        int helicopterPositionY = helicopter.StartY;

        Console.ForegroundColor = ConsoleColor.Red;
        foreach (var helicopterRow in helicopter.helicopterRows)
        {
            Console.SetCursorPosition(helicopter.StartX, helicopterPositionY);

            Console.Write(helicopterRow);
            helicopterPositionY++;
        }

        Console.ResetColor();
    }

    public static void PrintHelicopter(Helicopter helicopter)
    {
        Console.SetCursorPosition(0, StartScreen.consoleWindowHeight - 1);

        Console.MoveBufferArea(helicopter.PreviousStartX, helicopter.PreviousStartY, helicopter.Width, helicopter.Height,
        helicopter.StartX, helicopter.StartY);
    }


    //Shots   -----------------------------------------------------------------------------------------------------------------------
    public static void PrintShot(Shot shot)
    {
        Console.ForegroundColor = shot.Color;
        if (shot.EndX >= StartScreen.consoleWindowWidth)
        {
            PrintShotOnExit(shot);
        }
        else
        {
            PrintShotInConsoleInnerPart(shot);
        }
    }

    public static void PrintShotStart(Shot shot)
    {
        Console.ForegroundColor = shot.Color;
        if (shot.StartX < StartScreen.consoleWindowWidth - 2)
        {
            Console.SetCursorPosition(shot.StartX, shot.StartY);
            Console.Write(shot.ShotForm);
        }

    }

    public static void PrintShotInConsoleInnerPart(Shot shot)
    {
        Console.SetCursorPosition(0, StartScreen.consoleWindowHeight - 1);
        Console.MoveBufferArea(shot.StartX - 1, shot.StartY, shot.Width, shot.Height,
            shot.StartX, shot.StartY);
    }

    public static void PrintShotOnExit(Shot shot)
    {
        Console.SetCursorPosition(StartScreen.consoleWindowWidth - 2, shot.StartY);
        Console.Write("  ");
    }

    public static void DeleteShot(Shot shot)
    {
        Console.SetCursorPosition(shot.StartX - 1, shot.StartY);
        Console.Write("   ");
    }

    //Nuklear BOMB!--------------------------------------------------------------------------------------------------------------------
    public static void NuclearBOMB(Helicopter helicopter)
    {
        string nukedEm =
        "*****###*****###**###*****###**###*****###**###########**#########******##*###########*****###******###*********###*****" +
        "*****####****###**###*****###**###****###***###########**###*****###****#**###########*****###******###*********###*****" +
        "*****#####***###**###*****###**###***###****###**********###*****###*******###************######***######*******###*****" +
        "*****######**###**###*****###**###*###******###########**###*****###*******###########****######***######*******###*****" +
        "*****###*###*###**###*****###**######*******###########**###*****###*******###########***###*###**###*###*******###*****" +
        "*****###***#####**###*****###**###*####*****###**********###*****###*******###***********###*###**###*###*******###*****" +
        "*****###****####**###*****###**###***###****###########**###*****###*******###########**###***######***###**************" +
        "*****###*****###***#########***###****####**###########**#########*********###########**###***######***###******###*****";

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(0, 3);
        for (int i = 0; i < 19; i++)
        {
            Console.Write(new string('*', 120));
        }
        for (int i = 0; i < nukedEm.Length; i++)
        {
            if (nukedEm[i] == '*')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write(nukedEm[i]);
        }
        for (int i = 0; i < 19; i++)
        {
            Console.Write(new string('*', 120));
        }
        Thread.Sleep(2000);
        Console.Clear();
        HelicopterInitialPrint(helicopter);
    }


    //Update Score and Lives ----------------------------------------------------------------------------------------------------------
    public static void UpdateScoreAndLives(int lives, int bombs, BigInteger score, bool nuke, int nukeInSec)
    {
        Console.SetCursorPosition(0, 1);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" Lives: {0}  Bombs: {1}  Score: {2}".PadRight(80), lives, bombs, score);

        if (nuke)
        {
            Console.SetCursorPosition(80, 1);
            Console.WriteLine("The NUKE is comming in {0}".PadRight(40), nukeInSec);
        }
    }

    //How to Play
    public static void HowToPlay()
    {
        Console.Clear();
        Console.SetCursorPosition(1, 1);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("  ^");
        Console.WriteLine("   |");
        Console.Write(" <--->");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  You move with the arrows.");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("   |");
        Console.WriteLine("  \\/");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n\nYou get points by killing those:\n");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(
            "  P     o     *        ***             \n" +
            " P P   oOo   ***   @   ***    *****     *\n" +
            "                       ***   *******   ***\n"
            );

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\n\nYou fire missiles(\'");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("-");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("') with Space bar.");

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\n\nYou ask for NUKLEAR BOMB with Z.");


        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n\n\n To go back press Escape.");

        while (Console.ReadKey().Key != ConsoleKey.Escape)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(' ');
            Console.SetCursorPosition(0, Console.CursorTop);
        }
        StartScreen.Main();
    }
}