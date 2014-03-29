using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavGame
{
    class Program
    {
        static void Main()
        {
            
            List<FallingObject> rocks = new List<FallingObject>();

            int mainLoopCount = 0;
            int createRockInLoops = 200000000;
            int printMoveObstaclesInLoops = 9000000;

            Console.WindowHeight = 50;
            Console.WindowWidth = 120;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            Console.ReadLine();

            while (true)
            {
                
                if (mainLoopCount % createRockInLoops == 0)
                {
                    rocks.Add(FallingObjectsGenerator.CreateRock());
                }                              

                if (mainLoopCount % printMoveObstaclesInLoops == 0)
                {
                    for (int i = 0; i < rocks.Count; i++)
                    {
                                                               
                        Window.PrintRock(rocks[i]);
                        rocks[i].MoveDown(); 

                        if (rocks[i].StartY > Console.WindowHeight)
                        {
                            rocks.Remove(rocks[i]);
                        }
                      
                    }
                }
                
                mainLoopCount = (mainLoopCount + 1) % int.MaxValue;                
            }

        }
    }
}
