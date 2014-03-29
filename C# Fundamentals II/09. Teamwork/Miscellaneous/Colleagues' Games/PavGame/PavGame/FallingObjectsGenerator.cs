using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavGame
{
    class FallingObjectsGenerator
    {
        public static List<string[,]> RockTypes = new List<string[,]>()
        {
            new string[,] { { " ", "P", " " }, { "P", " ", "P" } },
            new string[,] { { "o", "O", "o" }, { " ", "o", " " } },
            new string[,] { { " ", "*", " " }, { "*", "*", "*" }, { " ", "*", " " } },
            new string[,] { {"@"} }

        };
      
        public static FallingObject CreateRock()
        {
            int randomRockNumber = new Random().Next(0, RockTypes.Count);
            int startX = new Random().Next(0, Console.WindowWidth - RockTypes[0].Length);
            int EndY = 0;
            ConsoleColor color = SetRandomColor();
            FallingObject rock = new FallingObject(RockTypes[randomRockNumber], startX, EndY, color);
            return rock;
        }
    
        public static ConsoleColor SetRandomColor()
        {
            ConsoleColor randomColor;
            List<ConsoleColor> colors = new List<ConsoleColor>()
            {
                ConsoleColor.Red, 
                ConsoleColor.Blue,
                ConsoleColor.Cyan,
                ConsoleColor.Green,
                ConsoleColor.DarkGreen, 
                ConsoleColor.Magenta,
                ConsoleColor.Yellow,
                ConsoleColor.DarkYellow
            };

            int randomColorNumber = new Random().Next(0, colors.Count);
            randomColor = colors[randomColorNumber];
            return randomColor;
        }
    }
}
