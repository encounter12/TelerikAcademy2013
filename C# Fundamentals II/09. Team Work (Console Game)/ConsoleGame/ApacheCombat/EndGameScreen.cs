using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

class EndGameScreen
{
    public static void FinishGame(BigInteger score)
    {
        Console.Clear();
        bool canAdd = false;
        int i = 0;
        try
        {
            StreamReader read = new StreamReader("HighScores.txt");
            using (read)
            {
                string readLine = read.ReadLine();
                readLine = read.ReadLine();
                while (readLine != null)
                {
                    string[] player = readLine.Split(new char[] { ' ', ',', '|' }, StringSplitOptions.RemoveEmptyEntries);

                    if (score > BigInteger.Parse(player[2]))
                    {
                        canAdd = true;
                        break;
                    }
                    i++;
                    readLine = read.ReadLine();
                }
            }
            if (i < 9 || canAdd)
            {
                HighScores.EndScreenHighScores(score);
            }
            else
            {
                Console.SetCursorPosition(5, 20);
                Console.WriteLine("Game ended.Your score wasn't high enough to enter the top 9 players. Press Esc to go back!");
            }

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
            HighScores.EndScreenHighScores(score);
        }
    }
}