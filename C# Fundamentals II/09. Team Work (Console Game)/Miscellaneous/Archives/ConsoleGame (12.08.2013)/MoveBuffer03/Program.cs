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
            Console.BufferWidth = Console.WindowWidth = 120;
            Console.BufferHeight = Console.WindowHeight = 46;
            string[,] rock = new string[,] { { " ", "P", " " }, { "P", " ", "P" } };
            int rockStartX = Console.WindowWidth;
            int rockStartY = 15;

            int mainLoopCount = 0;

            while (true)
            {
                if (mainLoopCount % 30000000 == 0)
                {
                    rockStartX--;
                    PrintRock(rock, rockStartX, rockStartY); 
                }
                mainLoopCount++;               
            }           
        }

        public static void PrintRock(string[,] rock, int rockStartX, int rockStartY)
        {
            int rockEndX = rockStartX + rock.GetLength(1) - 1;

            if (rockEndX >= Console.WindowWidth - 1)
            {
                PrintOnEntrance(rock, rockStartX, rockStartY);
            } 
            else if (rockStartX <= 0)
            {
                PrintOnExit(rock, rockStartX, rockStartY);
            }                       
            else
            {
                Console.MoveBufferArea(rockStartX + 1, rockStartY, rock.GetLength(1), rock.GetLength(0),
                    rockStartX, rockStartY);
            }
        }

        private static void PrintOnEntrance(string[,] rock, int rockStartX, int rockStartY)
        {
            int currentRow = rockStartY;
            int firstColumn = 0;           
            int lastColumn = Console.WindowWidth - rockStartX - 1;
            
            for (int row = 0; row < rock.GetLength(0); row++)
            {
                Console.SetCursorPosition(rockStartX, currentRow);

                for (int col = firstColumn; col <= lastColumn; col++)
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
            int lastColumn = rock.GetLength(1) - 1;

            for (int row = 0; row < rock.GetLength(0); row++)
            {
                Console.SetCursorPosition(0, currentRow);

                for (int col = firstColumn; col <= lastColumn; col++)
                {
                    Console.Write(rock[row, col]);                    
                }
                Console.Write(" ");
                currentRow++;
            }
        }        
    }
}
