using System;
using System.Collections.Generic;
using System.Numerics;

class EndGameScreen
{
    public  static void _EndGameScreen(BigInteger score)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.SetCursorPosition(40, 20);

        Console.WriteLine("Your score is {0}",score);
        Console.SetCursorPosition(40, 22);
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Retry");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.SetCursorPosition(40, 24);
        Console.WriteLine("Exit");

        bool choise=false;
        int row=0;

        while (!choise)
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        {
                            if (row == 0)
                            {
                                Apache.PlayApacheCombat();
                            }
                            else
                            {
                                System.Diagnostics.Process.GetCurrentProcess().Kill();
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        {
                            if (row == 1)
                            {
                                row--;
                                Console.SetCursorPosition(40, 22);
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Retry");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(40, 24);
                                Console.WriteLine("Exit");

                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        {
                            if (row == 0)
                            {
                                row++;
                                Console.SetCursorPosition(40, 22);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine("Retry");
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                Console.SetCursorPosition(40, 24);
                                Console.WriteLine("Exit");
                                Console.BackgroundColor = ConsoleColor.Black;
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
}
