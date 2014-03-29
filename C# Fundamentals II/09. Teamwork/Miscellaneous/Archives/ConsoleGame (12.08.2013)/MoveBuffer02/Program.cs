using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoveBuffer
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            string[,] rock = new string[,] { { " ", "P", " " }, { "P", " ", "P" } };
            int rockStartX = Console.WindowWidth - rock.GetLength(1);

            int rockStartY = 15;
            int currentRow = rockStartY;
            
            int mainLoopCount = 0;

            while (true)
            {
                if (mainLoopCount % 40000000 == 0)
                {
                    PrintRock(rock, rockStartX, rockStartY);
                    rockStartX--;
                }
                mainLoopCount++;
            }
        }

        public static void PrintRock(string[,] rock, int rockStartX, int rockStartY)
        {
            int rockEndX = rockStartX + rock.GetLength(1) - 1;

            if (rockStartX <= 0)
            {
                PrintOnExit(rock, rockStartX, rockStartY);
            }
            else if (Console.WindowWidth - rockStartX + 1 <= rock.GetLength(1))
            {
                PrintOnEntrance(rock, rockStartX, rockStartY);
            }
            else if (rockEndX == Console.WindowWidth - 1)
            {
                PrintWholeObstacleInitially(rock, rockStartX, rockStartY);
            }
            else
            {
                Console.MoveBufferArea(rockStartX, rockStartY, rock.GetLength(1), rock.GetLength(0),
                    rockStartX - 1, rockStartY);
            }
        }

        private static void PrintOnEntrance(string[,] rock, int rockStartX, int rockStartY)
        {
            int currentRow = rockStartX;
            int firstColumn = 0;
            int lastColumn = Console.WindowWidth - rockStartX + 1;

            for (int row = 0; row < rock.GetLength(0); row++)
            {
                Console.SetCursorPosition(rockStartX, currentRow);

                for (int col = firstColumn; col < lastColumn; col++)
                {
                    Console.Write(rock[row, col]);
                }
                currentRow++;
            }
        }

        private static void PrintOnExit(string[,] rock, int rockStartX, int rockStartY)
        {
            int currentRow = rockStartY;
            int firstColumn = (-1) * rockStartX;
            int lastColumn = rock.GetLength(1);
            for (int row = 0; row < rock.GetLength(0); row++)
            {
                Console.SetCursorPosition(0, currentRow);

                for (int col = firstColumn; col < lastColumn; col++)
                {
                    Console.Write(rock[row, col]);
                }
                currentRow++;
            }
        }

        private static void PrintWholeObstacleInitially(string[,] rock, int rockStartX, int rockStartY)
        {
            int currentRow = rockStartY;
            int firstColumn = 0;
            int lastColumn = rock.GetLength(1);

            for (int row = 0; row < rock.GetLength(0); row++)
            {

                Console.SetCursorPosition(rockStartX, currentRow);

                for (int col = firstColumn; col < lastColumn; col++)
                {
                    Console.Write(rock[row, col]);
                }
                currentRow++;
            }
        }
    }
}

