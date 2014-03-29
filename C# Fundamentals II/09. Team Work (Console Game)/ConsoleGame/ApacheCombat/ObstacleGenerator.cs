using System;
using System.Collections.Generic;
using System.Linq;


namespace ApacheCombat
{
    class ObstacleGenerator
    {
        public static List<string[,]> RockTypes = new List<string[,]>()
        {
            new string[,] { { " ", "P", " " }, { "P", " ", "P" } },
            new string[,] { { "o", "O", "o" }, { " ", "o", " " } },
            new string[,] { { " ", "*", " " }, { "*", "*", "*" }, { " ", "*", " " } },
            new string[,] { {"@"} }

        };

        public static List<string[,]> GroundTargetsTypes = new List<string[,]>()
        {
            new string[,] { { "*", "*", "*" }, { "*", "*", "*" }, { "*", "*", "*" } },
            new string[,] { { " ", "*", "*", "*", "*", " " }, { "*", "*", "*", "*", "*", "*" } },
            new string[,] { { " ", "*", " " }, { "*", "*", "*"} }

        };

        public static Obstacle CreateRock()
        {
            int randomRockNumber = new Random().Next(0, RockTypes.Count);
            int startX = StartScreen.consoleWindowWidth;
            int startY = new Random().Next(StartScreen.playgroundStartY + 2, StartScreen.consoleWindowHeight - 6);
            ConsoleColor color = SetRandomColor();
            Obstacle rock = new Obstacle(RockTypes[randomRockNumber], startX, startY, color);
            return rock;
        }

        public static Obstacle CreateGroundTaget()
        {
            int randomGroundTargetNumber = new Random().Next(0, GroundTargetsTypes.Count);
            int startX = StartScreen.consoleWindowWidth;
            int startY = StartScreen.consoleWindowHeight - GroundTargetsTypes[randomGroundTargetNumber].GetLength(0) - 1;
            ConsoleColor color = SetRandomColor();

            Obstacle groundTarget = new Obstacle(GroundTargetsTypes[randomGroundTargetNumber], startX, startY, color);
            return groundTarget;
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
