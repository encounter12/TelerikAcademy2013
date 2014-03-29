using System;
using System.Collections.Generic;
using System.Linq;

namespace Animations.AnimationObjects
{
    class Ball
    {
        public int X { get; set; }

        public int Y { get; set; }

        private Direction DirectionX { get; set; }

        private Direction DirectionY { get; set; }

        public int Speed { get; set; }

        public double Size { get; set; }

        private static Dictionary<Direction, int> Directions { get; set; }

        public Ball(int x, int y, Direction directionX, Direction directionY, int speed, int size)
        {
            this.X = x;
            this.Y = y;
            this.DirectionX = directionX;
            this.DirectionY = directionY;
            this.Speed = speed;
            this.Size = size;
        }

        static Ball()
        {
            Directions = new Dictionary<Direction, int>();
            Directions[Direction.Left] = -1;
            Directions[Direction.Right] = 1;
            Directions[Direction.Down] = 1;
            Directions[Direction.Up] = -1;
        }

        public void Move()
        {
            this.X += Directions[this.DirectionX] * this.Speed;
            this.Y += Directions[this.DirectionY] * this.Speed;
        }

        public void ChangeDirectionX(Direction dir)
        {
            this.DirectionX = dir;
        }

        public void ChangeDirectionY(Direction dir)
        {
            this.DirectionY = dir;
        }
    }
}