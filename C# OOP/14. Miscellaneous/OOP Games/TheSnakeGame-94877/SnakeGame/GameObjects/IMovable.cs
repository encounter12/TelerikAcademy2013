using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnakeGame;

namespace SnakeGame.GameObjects
{
    public interface IMovable
    {
        int Speed { get; set; }

        MoveDirections Direction { get; set; }

        void Move();

        void ChangeDirection(MoveDirections direction);
    }
}
