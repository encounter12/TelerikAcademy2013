using System;
using System.Collections.Generic;
using System.Linq;


namespace ApacheCombat
{
    class ObstacleGenerator
    {
        public static List<string[,]> rockTypes = new List<string[,]>()
        {
            new string[,] { { " ", "P", " " }, { "P", " ", "P" } },
            new string[,] { { "o", "O", "o" }, { " ", "o", " " } },
            new string[,] { { " ", "*", " " }, { "*", "*", "*" }, { " ", "*", " " } },
            new string[,] { {"@"} }

        };

        public static List<string[,]> groundTargetsTypes = new List<string[,]>()
        {
            new string[,] { { "*", "*", "*" }, { "*", "*", "*" }, { "*", "*", "*" } },
            new string[,] { { " ", "*", "*", "*", "*", " " }, { "*", "*", "*", "*", "*", "*" } },
            new string[,] { { " ", "*", " " }, { "*", "*", "*"} }

        };
        
        public static Obstacle CreateRock()
        {
            int groundTargetsMaxHeight = 6;

            int randomRockNumber = new Random().Next(0, rockTypes.Count);
            int randomYPosition = new Random().Next(0, Game.consoleWindowHeight - groundTargetsMaxHeight);
            Obstacle rock = new Obstacle(rockTypes[randomRockNumber], Game.consoleWindowWidth - 1, randomYPosition);
            return rock;
        }

        public static Obstacle CreateGroundTaget()
        {
            int randomGroundTargetNumber = new Random().Next(0, groundTargetsTypes.Count);                       
            Obstacle groundTarget = new Obstacle(groundTargetsTypes[randomGroundTargetNumber],
                Game.consoleWindowWidth - groundTargetsTypes[randomGroundTargetNumber].GetLength(1), 
                Game.consoleWindowHeight - groundTargetsTypes[randomGroundTargetNumber].GetLength(0) - 1);
            
            return groundTarget;
        }
                
    }
}
