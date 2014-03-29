using System;

namespace ApacheCombat
{
    class Window
    {
        //firstColumn - rock's first column that should be printed on the console
        //lastColumn - rock's last column that should be printed on the console
        
        public static void PrintObstacle(Obstacle obstacle)
        {

            if (obstacle.StartX <= 0)
            {
                PrintOnExit(obstacle);
            }
            else if (Game.consoleWindowWidth - obstacle.StartX + 1 <= obstacle.Width)
            {
                PrintOnEntrance(obstacle);
            }
            else if (obstacle.EndX == Game.consoleWindowWidth - 1)
            {
                PrintWholeObstacleInitially(obstacle);
            }
            else
            {
                Console.MoveBufferArea(obstacle.StartX, obstacle.StartY, obstacle.Width, obstacle.Height,
                    obstacle.StartX - 1, obstacle.StartY);
            }
        }

        private static void PrintOnEntrance(Obstacle obstacle)
        {
            int currentRow = obstacle.StartY;
            int firstColumn = 0;
            int lastColumn = Game.consoleWindowWidth - obstacle.StartX + 1;

            for (int row = 0; row < obstacle.Height; row++)
            {
                Console.SetCursorPosition(obstacle.StartX, currentRow);

                for (int col = firstColumn; col < lastColumn; col++)
                {
                    Console.Write(obstacle.ObstacleElements[row, col]);
                }
                currentRow++;
            }
        }

        private static void PrintOnExit(Obstacle obstacle)
        {
            int currentRow = obstacle.StartY;            
            int firstColumn = (-1) * obstacle.StartX;
            int lastColumn = obstacle.Width;
            for (int row = 0; row < obstacle.Height; row++)
            {
                Console.SetCursorPosition(0, currentRow);

                for (int col = firstColumn; col < lastColumn; col++)
                {
                    Console.Write(obstacle.ObstacleElements[row, col]);
                }
                currentRow++;
            }
        }

        private static void PrintWholeObstacleInitially(Obstacle obstacle)
        {
            int currentRow = obstacle.StartY;
            int firstColumn = 0;
            int lastColumn = obstacle.Width;

            for (int row = 0; row < obstacle.Height; row++)
            {
                
                Console.SetCursorPosition(obstacle.StartX, currentRow);

                for (int col = firstColumn; col < lastColumn; col++)
                {
                    Console.Write(obstacle.ObstacleElements[row, col]);
                }
                currentRow++;
            }
        }

        public static void PrintHelicopter(Helicopter helicopter)
        {
            Console.MoveBufferArea(helicopter.PreviousStartX, helicopter.PreviousStartY, helicopter.Width, helicopter.Height,
            helicopter.StartX, helicopter.StartY);            
        }

        public static void HelicopterInitialPrint(Helicopter helicopter)
        {
            int helicopterPositionY = helicopter.StartY;

            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var helicopterRow in helicopter.helicopterRows)
            {
                Console.SetCursorPosition(helicopter.StartX, helicopterPositionY);

                Console.Write(helicopterRow);
                helicopterPositionY++;
            }

            Console.ResetColor();
        }
               
    }
}
