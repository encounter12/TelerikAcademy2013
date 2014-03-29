// -----------------------------------------------------------------------
// <copyright file="SnakeObstacle.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace SnakeGame.GameObjects
{
    using System;
    using System.Linq;

    public class SnakeObstacle:Snake
    {
        public SnakeObstacle(Position pos, int size, int speed)
            : base(pos, size,speed)
        {
            
        }
    }
}
