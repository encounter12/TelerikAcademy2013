using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnakeGame;
using SnakeGame.GameObjects;
using SnakeGame.Helpers;
using System.Collections.ObjectModel;

namespace SnakeGame.GameObjects
{
    public class Snake : GameObject, IMovable, IDestroyable
    {
        private MoveDirections direction;

        private ObservableCollection<SnakePart> head;
        public Snake(Position pos, int size, int speed)
            : base(pos, size)
        {
            this.Speed = speed;
            this.IsDestroyed = false;

            this.Parts = new ObservableCollection<SnakePart>();
            var head = new SnakeHead(pos, Constants.SquareSize, speed);
            this.Parts.Add(head);
            this.head = new ObservableCollection<SnakePart>() { head };

            for (int i = 1; i < size; i++)
            {
                var position = new Position(pos.X - i * Constants.SquareSize, pos.Y);
                var part = new SnakePart(position, Constants.SquareSize, this.Speed);
                this.Parts.Add(part);
            }
        }

        public int Speed { get; set; }

        public ObservableCollection<SnakePart> Head
        {
            get
            {
                return this.head;
            }
            set
            {
                if (this.head == null)
                {
                    this.head = new ObservableCollection<SnakePart>();
                }
                else
                {
                    this.head.Clear();
                }
                foreach (var item in value)
                {
                    this.head.Add(item);
                }
            }
        }

        public  int Size
        {
            get
            {
                return Parts.Count;
            }
        }

        public int Score
        {
            get
            {
                return Parts.Count-Constants.DefaultSnakeSize;
            }
        }


        public MoveDirections Direction
        {
            get
            {
                return this.Parts[0].Direction;
            }
            set
            {
                Parts[0].ChangeDirection(value);
            }
        }

        public ObservableCollection<SnakePart> Parts { get; set; }

        public override Position Position
        {
            get
            {
                return this.Parts[0].Position;
            }
        }

        public void Grow()
        {
            var tail = this.Parts[this.Parts.Count - 1];
            var x = tail.Position.X;
            var y = tail.Position.Y;
            var direction = tail.Direction;
            var size = tail.Size;

            var newX = x + Constants.SquareSize * (-Constants.DX[direction]);
            var newY = y + Constants.SquareSize * (-Constants.DY[direction]);

            var newTail = new SnakePart(new Position(newX, newY), size, Speed,tail.Direction);

            this.Parts.Add(newTail);
            this.OnPropertyChanged("Size");
        }

        public void Destroy()
        {
            this.IsDestroyed = true;
        }

        public void ChangeDirection(MoveDirections direction)
        {
            this.Direction = direction;
        }

        public bool IsDestroyed { get; set; }

        public void Move()
        {
            foreach (var part in this.Parts)
            {
                part.Move();
            }

            for (int i = this.Size - 1; i > 0; i--)
            {
                var part = this.Parts[i];
                var prevPart = this.Parts[i - 1];
                var prevPartDirection = prevPart.Direction;
                part.ChangeDirection(prevPartDirection);
            }

        }
    }
}
