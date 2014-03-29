using System;
using System.IO;
using System.Linq;

namespace ApacheCombatMockUp
{
    class ApacheCombatMockUp
    {
        static void Main()
        {
            Console.SetWindowSize(120, 46);

            //StreamReader reader = new StreamReader("../../txt/01-StartScreen.txt");
            StreamReader reader = new StreamReader("../../txt/04-PlayGameScreen.txt");
            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();


                while (line != null)
                {
                    lineNumber++;
                    if (lineNumber < 7)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }
    }
}
