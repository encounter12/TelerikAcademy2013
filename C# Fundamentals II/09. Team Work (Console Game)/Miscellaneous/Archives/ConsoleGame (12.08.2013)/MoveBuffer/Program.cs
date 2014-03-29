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

            for (int row = 0; row < rock.GetLength(0); row++)
            {
                Console.SetCursorPosition(rockStartX, currentRow);
                for (int col = 0; col < rock.GetLength(1); col++)
                {
                    Console.Write(rock[row, col]);
                }

                currentRow++;
            }

            Console.Read();

            int mainLoopCount = 0;

            while (true)
            {
                if (mainLoopCount % 3000000 == 0)
                {
                    if (rockStartX > 0)
                    {
                        Console.MoveBufferArea(rockStartX, rockStartY, rock.GetLength(1), rock.GetLength(0), rockStartX - 1, rockStartY);
                        rockStartX--;
                    }
                    else
                    {
                        break;
                    }                    
                }                
                mainLoopCount++;
            }          
        }


    }
}
