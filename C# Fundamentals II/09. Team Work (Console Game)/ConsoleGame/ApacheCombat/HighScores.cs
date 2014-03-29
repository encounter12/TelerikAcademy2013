using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using System.Linq;

class HighScores
{
    public static void HighScoresTop9()
    {
        try
        {
            StreamReader read = new StreamReader("HighScores.txt");
            Console.Clear();
            using (read)
            {
                Console.SetCursorPosition(35, 18);
                Console.WriteLine("HIGH SCORES");
                int i = 21;
                string readLine = read.ReadLine();
                while (readLine != null)
                {
                    i++;
                    Console.SetCursorPosition(35, i);
                    Console.WriteLine(readLine);
                    readLine = read.ReadLine();
                }
            }

            Console.SetCursorPosition(35, 36);
            Console.WriteLine("To go back press Esc.");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(' ');
                Console.SetCursorPosition(0, Console.CursorTop);
            }
            StartScreen.Main();
        }
        catch (FileNotFoundException)
        {
            Console.Clear();
            Console.SetCursorPosition(35, 22);
            Console.WriteLine("Nobody played this game yet! To go back press Esc.");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(' ');
                Console.SetCursorPosition(0, Console.CursorTop);
            }
            StartScreen.Main();
        }
        catch (Exception e)
        {
            Console.WriteLine("I missed this exception:");
            Console.WriteLine(e.Message);
        }
    }

    public static void EndScreenHighScores(BigInteger score)
    {
        try
        {
            StreamReader read = new StreamReader("HighScores.txt");
            Console.Clear();
            Console.SetCursorPosition(5, 20);
            Console.Write("Game ended.You entered top 9 player. Enter your name: ");
            bool canAdd = true;
            Dictionary<string, BigInteger> players = new Dictionary<string, BigInteger>();
            string readLine;
            using (read)
            {
                readLine = read.ReadLine();
                readLine = read.ReadLine();
                while (readLine != null)
                {
                    string[] player = readLine.Split(new char[] { ' ', ',', '|' }, StringSplitOptions.RemoveEmptyEntries);

                    players.Add(player[1], BigInteger.Parse(player[2]));
                    if (score > BigInteger.Parse(player[2]))
                    {
                        canAdd = true;
                    }
                    readLine = read.ReadLine();
                }
            }
            if (players.Count < 9 || canAdd)
            {
                StringBuilder playerName = new StringBuilder();
                int length = 0;
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        EnterName(ref score, ref players, playerName, ref length);
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 20);
            Console.Write("You entered top 9 player. Enter your name: ");

            Dictionary<string, BigInteger> players = new Dictionary<string, BigInteger>();
            StringBuilder playerName = new StringBuilder();
            int length = 0;
            EnterName(ref score, ref players, playerName, ref length);

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(' ');
                Console.SetCursorPosition(0, Console.CursorTop);
            }
            StartScreen.Main();
        }
    }

    private static void EnterName(ref BigInteger score, ref Dictionary<string, BigInteger> players, StringBuilder playerName, ref int length)
    {
        while (true)
        {
            ConsoleKey myKey = Console.ReadKey().Key;
            switch (myKey)
            {
                case ConsoleKey.A:
                case ConsoleKey.B:
                case ConsoleKey.C:
                case ConsoleKey.D:
                case ConsoleKey.E:
                case ConsoleKey.F:
                case ConsoleKey.G:
                case ConsoleKey.H:
                case ConsoleKey.I:
                case ConsoleKey.J:
                case ConsoleKey.K:
                case ConsoleKey.L:
                case ConsoleKey.M:
                case ConsoleKey.N:
                case ConsoleKey.O:
                case ConsoleKey.P:
                case ConsoleKey.Q:
                case ConsoleKey.R:
                case ConsoleKey.S:
                case ConsoleKey.T:
                case ConsoleKey.U:
                case ConsoleKey.V:
                case ConsoleKey.W:
                case ConsoleKey.X:
                case ConsoleKey.Z:
                case ConsoleKey.Y:
                    {
                        if (length < 10)
                        {
                            length++;
                            playerName.Append(myKey.ToString());
                        }
                        else
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            Console.Write(' ');
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        }
                    }
                    break;

                case ConsoleKey.Backspace:
                    {
                        if (length > 0)
                        {
                            length--;
                            playerName.Remove(length, 1);

                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                            Console.Write(' ');
                            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);

                        }
                        Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                    }
                    break;

                case ConsoleKey.Enter:
                    {
                        if (playerName.ToString() != string.Empty)
                        {
                            if (players.ContainsKey(playerName.ToString()))
                            {
                                players.Remove(playerName.ToString());
                            }
                            players.Add(playerName.ToString(), score);

                            List<KeyValuePair<string, BigInteger>> sorted = (from kv in players orderby kv.Value select kv).ToList();
                            sorted.Reverse();

                            StreamWriter write = new StreamWriter("HighScores.txt");
                            int i = 1;
                            using (write)
                            {
                                write.WriteLine(@"No| Name          |");
                                foreach (KeyValuePair<string, BigInteger> player in sorted)
                                {
                                    write.WriteLine(i + @".| " + player.Key.ToString().PadRight(14) + "|" + player.Value);
                                    i++;
                                    if (i == 10)
                                    {
                                        break;
                                    }
                                }
                            }

                            HighScoresTop9();
                        }
                        Console.SetCursorPosition(50, 20);
                    }
                    break;
                default:
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(' ');
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    }
                    break;
            }
        }
    }

}
