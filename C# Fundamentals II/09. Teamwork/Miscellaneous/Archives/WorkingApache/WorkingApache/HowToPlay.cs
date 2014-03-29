using System;
using System.Collections.Generic;

class HowToPlay
{
    public static void _HowToPlay()
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

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n     /\\");
        Console.WriteLine("    ///\\");
        Console.Write("   /////\\");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  Be carefull with the mountains!");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  ///////\\");
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\n\nYou fire missiles(\'");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("-");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("') with Space bar.");

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\n\nYou fire bombs(\'");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("*");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("') with Z.");

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n\n  #");
        Console.Write(" ###");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  Kill those fuckers with missiles or bombs.");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("  #");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\n\n  ^^^");
        Console.Write("  %%%");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  You can kill bases with bombs.");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("  %%%");

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
