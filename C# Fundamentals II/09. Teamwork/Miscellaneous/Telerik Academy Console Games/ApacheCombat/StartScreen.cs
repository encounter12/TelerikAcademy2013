using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApacheCombat
{
    class StartScreen
    {
        public static void DrawASCIIHelicopter(string pathToAsciFile)
        {
            StreamReader reader = new StreamReader(pathToAsciFile);
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
                    Thread.Sleep(20);
                }
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
