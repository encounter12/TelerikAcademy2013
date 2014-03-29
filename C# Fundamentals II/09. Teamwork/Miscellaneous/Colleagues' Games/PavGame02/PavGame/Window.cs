using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavGame
{
    class Window
    {
        public static void PrintRock(FallingObject rock)
        {
            Console.ForegroundColor = rock.Color;
            if (rock.StartY <= 0)
            {
                PrintRockOnEntrance(rock);
            }
            else if (rock.EndY > Console.WindowHeight - 1)
            {
                PrintRockOnExit(rock);
            }
            else
            {
                PrintRockInConsoleInnerPart(rock);
            }
            Console.ResetColor();
        }

        private static void PrintRockOnEntrance(FallingObject rock)
        {
            int currentRow = 0;                  
            int lastRow = rock.EndY;

            for (int row = 0; row <= lastRow; row++)
            {
                Console.SetCursorPosition(rock.StartX, currentRow);

                for (int col = 0; col < rock.Width; col++)
                {
                    Console.Write(rock.ObstacleRows[row, col]);
                }
                currentRow++;
            }
        }

        private static void PrintRockOnExit(FallingObject rock)
        {
            int currentRow = rock.StartY;
            int lastRow = (rock.Height - (rock.EndY - Console.WindowHeight)) - 1;

            Console.SetCursorPosition(rock.StartX, currentRow - 1);
            Console.Write(new string(' ', rock.Width));

            for (int row = 0; row < lastRow; row++)
            {                
                Console.SetCursorPosition(rock.StartX, currentRow);

                for (int col = 0; col < rock.Width; col++)
                {
                    Console.Write(rock.ObstacleRows[row, col]);
                }
                
                currentRow++;
            }

            if (rock.StartY >= Console.WindowHeight - 1)
            {
                Console.SetCursorPosition(rock.StartX, currentRow - 2);
                Console.Write(new string(' ', rock.Width));
            }

        }

        public static void PrintRockInConsoleInnerPart(FallingObject rock)
        {
            //Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.MoveBufferArea(rock.StartX, rock.StartY - 1, rock.Width, rock.Height,
                rock.StartX, rock.StartY);
        }
    }
}
