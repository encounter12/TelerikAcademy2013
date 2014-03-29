using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

class StartScreen
{
    public static int consoleWindowWidth = 120;
    public static int consoleWindowHeight = 50;

    public static int playgroundStartY = 3;
    public static int playgroundHeight = consoleWindowHeight - playgroundStartY;

    public static void Main()
    {
        Console.TreatControlCAsInput = true;
        Console.CursorVisible = false;
        Console.SetWindowSize(consoleWindowWidth, consoleWindowHeight);
        RemoveScrollBars();


        string[] menu = new string[] { "1. Play game", "2. How to play", "3. High score", "4. Exit" };

        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();

        DrawHelicopter();

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        bool choice = false;
        int row = 0;

        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.WriteLine(menu[0]);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("\n" + menu[1]);
        Console.WriteLine("\n" + menu[2]);
        Console.WriteLine("\n" + menu[3]);

        while (!choice)
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        {
                            choice = true;
                            if (row == 0)
                            {
                                Game.PlayApacheCombat();
                            }
                            else if (row == 1)
                            {
                                Window.HowToPlay();
                            }
                            else if (row == 2)
                            {
                                HighScores.HighScoresTop9();
                            }
                            else
                            {
                                System.Diagnostics.Process.GetCurrentProcess().Kill();
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        {
                            if (row == 1 || row == 2 || row == 3)
                            {
                                if (row == 1)
                                {
                                    row--;
                                    MarkedFirst(menu);
                                }
                                else if (row == 2)
                                {
                                    row--;
                                    MarkedSecound(menu);
                                }
                                else
                                {
                                    row--;
                                    MarkedThird(menu);
                                }
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        {
                            if (row == 0 || row == 1 || row == 2)
                            {
                                if (row == 0)
                                {
                                    row++;
                                    MarkedSecound(menu);
                                }
                                else if (row == 1)
                                {
                                    row++;
                                    MarkedThird(menu);
                                }
                                else
                                {
                                    row++;
                                    MarkedFourth(menu);
                                }
                            }
                        }
                        break;
                    default:
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.Write(' ');
                            Console.SetCursorPosition(0, Console.CursorTop);
                        }
                        break;
                }
            }
        }
    }

    private static void MarkedFourth(string[] menu)
    {
        Console.SetCursorPosition(0, Console.CursorTop - 7);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine(menu[0]);
        Console.WriteLine("\n" + menu[1]);
        Console.WriteLine("\n" + menu[2]);
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n" + menu[3]);
        Console.BackgroundColor = ConsoleColor.Black;
    }

    private static void MarkedThird(string[] menu)
    {
        Console.SetCursorPosition(0, Console.CursorTop - 7);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine(menu[0]);
        Console.WriteLine("\n" + menu[1]);
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n" + menu[2]);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("\n" + menu[3]);
    }

    private static void MarkedSecound(string[] menu)
    {
        Console.SetCursorPosition(0, Console.CursorTop - 7);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine(menu[0]);
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n" + menu[1]);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("\n" + menu[2]);
        Console.WriteLine("\n" + menu[3]);
    }

    private static void MarkedFirst(string[] menu)
    {
        Console.SetCursorPosition(0, Console.CursorTop - 7);
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.WriteLine(menu[0]);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("\n" + menu[1]);
        Console.WriteLine("\n" + menu[2]);
        Console.WriteLine("\n" + menu[3]);
    }

    private static void DrawHelicopter()
    {
        string[] helicopterPicture ={
@"                                                                                                              ",
@"    *      ****     *       ***   *   *  *****     ***    ****   *   *  ****      *    *******                ",
@"   * *     *   *   * *     *   *  *   *  *        *   *  *    *  ** **  *   *    * *      *                   ",
@"  * * *    ****   * * *    *      *****  ****     *      *    *  * * *  ****    * * *     *                   ",
@" *     *   *     *     *   *   *  *   *  *        *   *  *    *  *   *  *   *  *     *    *                   ",
@" *     *   *     *     *    ***   *   *  *****     ***    ****   *   *  ****   *     *    *                   ",
@"                                                                                                 .BM    uM7   ",
@"                                                                                       . .MBBc    MB  3BMW    ",
@"                                                                                  .:r7Lr  .sBMBMH.MMBBBi      ",
@"                                                                             .:vxuv;.          ;1BBBMBMZU     ",
@"                                                                        .:LUX2v:                XMBMBBBMB     ",
@"                                                                    :xXDP3;.                 sMBBBMBMBxJBBMO  ",
@"                                                               :JEMOXr,                    EBMBMBMBMB.    Lu  ",
@"                                                          :JGBMDL:                        :BBBBBMBMBZ         ",
@"                                                     ,JOBMMU;                       .;JZBMBMBMBMBMBBB         ",
@"                                                ,JOBMBPr.                     :cSMMBMBMBMBMBMBMBBB.L:         ",
@"                                           .vDBMBOs,                   .;uWMBMBMBBBMBMBMBBBMBMBBU             ",
@"                                       :JOMBS;                   :7HRBBBBBMBMBBBMBMBMBMBMBMBMS,               ",
@"                               7X3ivOMBMBRWXL.            .;2WBMBMBMBMBMBMBMBMBMBBBMBMBMBMU.                  ",
@"                             ,MBMBMBMBMBBBBBMBMBM;   ;1MMBMBMBMBMBMBMBBBMBMBBBBBMBMBMBM3.                     ",
@"                         .vGBRBBBMBMBBBMBMBMBMBBBMBMBMBMBMBMBMBBBMBMBMBMBMBBBMBMBBBMx                         ",
@"                     .7ERGc.  MBMBBBMBMBMBMBMBBBMBMBMBMBBBMBMZHBMBBBBBMBMBMBBBMBM7                            ",
@"                 ,LKOFi   .7WMBMBMBMBMBMBBBBBMBBBMBMBMBMBMBMB  1BMBBBMBMBMBMBG; LU                            ",
@"             :LGRDc   :SMBMBMBMBMBMBMBMBMBMBMBMBMBMBBBMBMBMBMP.PMBMBMBMBMBMB7    ,i                           ",
@"         ,vSGX7.    BMBBBMBMBMBMBMBMBMBMBMBMBMBMBBBMBMBMBMBMBBBBBMBMBMBMBMBM                                  ",
@"     :rUS1;.       HBBBBBBMBMBBBMBMBMBMBMHiBMBMBMBMBMBMBMBMBMBMBMBMBMBBBBBMR                                  ",
@"    r7:            LBMBMBMBBBMBMBBBM1;BMB; :BBBMBMBMBMBMBBBMBMBBBMBMBMBMBMBMBMB                               ",
@"               ;EBMBMBMBMBMBBBBBMBMB. ,BMB7PMBMBMBMBBBMBBBMBMBMBMBMBZL,   .:EOi                               ",
@"              BMBMBMBMBMBMBMBMBMBBBMBLWBBMBBBMBMBMBBBMBMBMBMBBBH7.                                            ",
@"             BBBB EBMBMBMBBBMBBBMBBBMBMBMBMBMBMBMBMBBBMBMD3;                                                  ",
@"            vMBMB  MBMBBBMBMBMBMBBBMBMBMBMBMBMBMBBBMWs:                                                       ",
@"            MBMBBREBBBBBMBMBMBMBMBMBMBMBMBMBMBMZ7,                                                            ",
@"           MBMBMBMBBBMBMBBBBBBBMBBBMBMBMBMS;.                                                                 ",
@"          SBMBMBBBBBBBMBMBMBMBMBMBMBMs:                                                                       ",
@"          BMBMBMBMBMBMBMBMBMBMBRDMBMO                                                                         ",
@"           BMBMBMBMBMBMBBBDJ:    xMO,                                                                         ",
@"            ,BBOBMBRBMB.                                                                                      ",
@"             x       .                                                                                        "};

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine(helicopterPicture[i]);
        }

        Console.ForegroundColor = ConsoleColor.Red;
        for (int i = 6; i < 38; i++)
        {
            Console.WriteLine(helicopterPicture[i]);
        }
    }

    static void RemoveScrollBars()
    {
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }
}