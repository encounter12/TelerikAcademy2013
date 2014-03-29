using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnakeGame.Helpers;

namespace SnakeGame.GameObjects
{
    public class MovingFood : Food, IMovable
    {
        private int speed;

        public MovingFood(Position pos, int size, int speed)
            : this(pos, size, speed, MoveDirections.Right)
        {

        }

        public MovingFood(Position pos, int size, int speed, MoveDirections direction)
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
                //this.OnPropertyChanged("Speed");

            }
        }

        public MoveDirections Direction
        {
            get;
            set;
        }

        public void Move()
        {
            var deltaX = Constants.DX[this.Direction];
            var deltaY = Constants.DY[this.Direction];
            this.Position.X += deltaX * this.speed;
            this.Position.Y += deltaY * this.speed;
            this.OnPropertyChanged("X");
            this.OnPropertyChanged("Y");
        }

        public void ChangeDirection(MoveDirections direction)
        {
            this.Direction = direction;            
        }

        
    }
}
