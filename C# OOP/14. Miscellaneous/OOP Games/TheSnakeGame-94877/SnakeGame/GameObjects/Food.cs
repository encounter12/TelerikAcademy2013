using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnakeGame;

namespace SnakeGame.GameObjects
{
    public class Food : GameObject, IDestroyable
    {
        public Food(Position pos, int size)
            : base(pos, size)
        {
        }

        public void Destroy()
        {
            this.IsDestroyed = true;            
        }

        public bool IsDestroyed
        {
            get;
            set;
        }
    }
}