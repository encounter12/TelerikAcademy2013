using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApacheCombatRocks
{    
    class ApacheCombatRocks
    {
        static void Main(string[] args)
        {
            SetConsoleWindowSize(consoleWindowWidth, consoleWindowHeight);
            RemoveScrollBars();
            Console.CursorVisible = false;
            
            Thread.Sleep(300);

            string[,] rockElements = new string[,] { { " ", "P", " " }, { "P", " ", "P" } };
            Rock rock = new Rock(rockElements, consoleWindowWidth - 1, 15);  

            while (true)
            {                              
                DrawRock(rock);
                MoveRockLeft(rock);
                Thread.Sleep(200);
                Console.Clear();
            }
        }

        const int consoleWindowWidth = 120;
        const int consoleWindowHeight = 46;

        static void SetConsoleWindowSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
        }
        static void RemoveScrollBars()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }
        static void DrawRock(Rock rock)
        {
            int firstColumn; //rock's first column that should be printed on the console
            int lastColumn; //rock's last column that should be printed on the console
            int currentRow = rock.StartY;

            for (int row = 0; row < rock.Height; row++)
            {
                firstColumn = 0;

                if (rock.StartX < 0)
                {
                    Console.SetCursorPosition(0, currentRow);
                    firstColumn = (-1) * rock.StartX;
                }
                else
                {
                    Console.SetCursorPosition(rock.StartX, currentRow);
                }


                if (consoleWindowWidth - rock.StartX + 1 > rock.Width)
                {
                    lastColumn = rock.Width;
                }
                else
                {
                    lastColumn = consoleWindowWidth - rock.StartX + 1;
                }

                for (int col = firstColumn; col < lastColumn; col++)
                {
                    Console.Write(rock.RockElements[row, col]);
                }

                currentRow++;
            }            
        }

        static void MoveRockLeft(Rock rock)
        {
            rock.StartX--;
        }
    }
}