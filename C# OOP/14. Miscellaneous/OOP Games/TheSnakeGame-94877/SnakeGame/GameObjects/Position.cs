using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnakeGame.Helpers;
using SnakeGame.ViewModels;

namespace SnakeGame.GameObjects
{
    public class Position:BaseViewModel
    {
        private int x;
        private int y;
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get
            {
                return this.x;


            }
            set
            {
                //if (value < 0)
                //{
                //    throw new ArgumentException("X cannot be less than 0", "x");
                //}
                //else if (value > Constants.MaxX)
                //{
                //    throw new ArgumentException("X cannot be greater than Max X", "x");
                //}

                var newValue = value;
                if (newValue < 0)
                {
                    newValue += Constants.MaxX;
                }
                else if (newValue >= Constants.MaxX)
                {
                    newValue %= Constants.MaxX;
                }
                this.x = newValue;
                this.OnPropertyChanged("X");
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                //if (value < 0)
                //{
                //    throw new ArgumentException("Y cannot be less than 0", "y");
                //}
                //else if (value > Constants.MaxY)
                //{
                //    throw new ArgumentException("Y cannot be greater than Max Y", "y");
                //}
                var newValue = value;
                if (newValue < 0)
                {
                    newValue += Constants.MaxY;
                }
                else if(newValue>=Constants.MaxY)
                {
                    newValue %= Constants.MaxY;
                }

                this.y = newValue;
                this.OnPropertyChanged("Y");
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Position))
            {
                return false;
            }

            Position other = (Position)obj;

            return this.X == other.x && this.Y == other.Y;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.x, this.y);
        }
    }
}
