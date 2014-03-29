using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnakeGame.GameObjects;

namespace SnakeGame
{
    public class Obstacle : GameObject
    {
        public Obstacle(Position pos,int size)
            :base(pos,size)
        {
        }
    }
}
