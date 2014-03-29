using System;
using System.Collections.Generic;
using System.IO;

class StartScreen
{
    public static void Main()
    {
        Console.TreatControlCAsInput = true;
        string[] menu = new string[] { "1. Play game", "2. How to play", "3.Exit" };

        Console.SetWindowSize(120, 47);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();

        StreamReader reader = new StreamReader("01-StartScreen.txt");
        using (reader)
        {
            string line;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(line = reader.ReadLine());
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 7; i < 41; i++)
            {
                Console.WriteLine(line = reader.ReadLine());
            }
        }

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        bool choise = false;
        int row = 0;

        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.WriteLine(menu[0]);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("\n" + menu[1]);
        Console.WriteLine("\n" + menu[2]);

        while (!choise)
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        {
                            choise = true;
                            if (row == 0)
                            {
                                Apache.PlayApacheCombat();
                            }
                            else if (row == 1)
                            {
                                HowToPlay._HowToPlay();
                            }
                            else
                            {
                                System.Diagnostics.Process.GetCurrentProcess().Kill();
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        {
                            if (row == 1||row==2)
                            {
                                if (row == 1)
                                {
                                    row--;
                                    Console.SetCursorPosition(0, Console.CursorTop - 5);
                                    Console.BackgroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine(menu[0]);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine("\n" + menu[1]);
                                    Console.WriteLine("\n" + menu[2]);
                                }
                                else
                                {
                                    row--;
                                    Console.SetCursorPosition(0, Console.CursorTop - 5);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine(menu[0]);
                                    Console.BackgroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\n" + menu[1]);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine("\n" + menu[2]);
                                }
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        {
                            if (row == 0||row==1)
                            {
                                if (row == 0)
                                {
                                    row++;
                                    Console.SetCursorPosition(0,Console.CursorTop-5);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine(menu[0]);
                                    Console.BackgroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\n" + menu[1]);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine("\n" + menu[2]);
                                }
                                else
                                {
                                    row++;
                                    Console.SetCursorPosition(0, Console.CursorTop - 5);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine(menu[0]);
                                    Console.WriteLine("\n" + menu[1]);
                                    Console.BackgroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\n" + menu[2]);

                                    Console.BackgroundColor = ConsoleColor.Black;
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
}