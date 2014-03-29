using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnakeGame;

namespace SnakeGame.GameObjects
{
    public class SnakeHead : SnakePart
    {
        public SnakeHead(Position pos, int size,int speed)
            : base(pos, size,speed)
        {
        }
    }
}
