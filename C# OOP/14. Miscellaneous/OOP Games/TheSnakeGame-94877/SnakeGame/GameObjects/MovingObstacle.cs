using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnakeGame.Helpers;

namespace SnakeGame.GameObjects
{
    public class MovingObstacle : Obstacle, IMovable
    {
        private int speed;
        public MovingObstacle(Position pos, int size, int speed)
            : this(pos, size, speed, MoveDirections.Right)
        {
        }

        public MovingObstacle(Position pos, int size, int speed, MoveDirections direction)
            : base(pos, size)
        {
            this.Speed = speed;
            this.Direction = direction;
        }
        public int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Speed cannot be less or equal to 0", "Speed");
                }
                this.speed = value;
                this.OnPropertyChanged("Speed");

            }
        }

        public MoveDirections Direction { get; set; }


        public void Move()
        {
            var deltaX = Constants.DX[this.Direction];
            var deltaY = Constants.DY[this.Direction];
            this.Position.X += deltaX * this.speed;
            this.Position.Y += deltaY * this.speed;
        }

        public void ChangeDirection(MoveDirections direction)
        {
            var dirIndex = (int)direction;
            var currentDirIndex = (int)this.Direction;

            var dirDifference = Math.Abs(dirIndex - currentDirIndex);
            //if (dirDifference != 2)
            //{
                this.Direction = direction;
            //}
        }
    }
}
