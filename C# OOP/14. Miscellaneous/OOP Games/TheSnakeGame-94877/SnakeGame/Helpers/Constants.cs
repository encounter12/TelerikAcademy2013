using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnakeGame.GameObjects;

namespace SnakeGame.Helpers
{
    public static class Constants
    {
        public const int MaxX = 1000;
        public const int MaxY = 540;
        public const int DefaultSnakeSize = 5;
        public const int SquareSize = 15;
        public const int DefaultSnakeSpeed = 15;
        public const int FoodCount = 5;
        //added constant
        public const int MovingFoodCount = 3;

        public static readonly int MinObstaclesCount;
        public static readonly int MaxObstaclesCount;
        public static readonly int MinMovingObstaclesCount;
        public static readonly int MaxMovingObstaclesCount;
        public static readonly int MinMovingObstaclesSpeed;
        public static readonly int MaxMovingObstaclesSpeed;
        public static readonly int MinMovingObstaclesPrescaller;
        public static readonly int MaxMovingObstaclesPrescaller;


        public static readonly int MovingFoodsSpeed;


        public static readonly Position SnakeStartPosition;

        public static readonly Dictionary<MoveDirections, int> DX;
        public static readonly Dictionary<MoveDirections, int> DY;

        static Constants()
        {
            DX = new Dictionary<MoveDirections, int>();
            DX[MoveDirections.Right] = 1;
            DX[MoveDirections.Left] = -1;
            DX[MoveDirections.Down] = 0;
            DX[MoveDirections.Up] = 0;

            DY = new Dictionary<MoveDirections, int>();
            DY[MoveDirections.Right] = 0;
            DY[MoveDirections.Left] = 0;
            DY[MoveDirections.Down] = 1;
            DY[MoveDirections.Up] = -1;

            MinObstaclesCount = 5; //1 * ((MaxY * MaxX) / (SquareSize * SquareSize)) / 100;
            MaxObstaclesCount = 10;//2 * ((MaxY * MaxX) / (SquareSize * SquareSize)) / 100;

            MinMovingObstaclesCount = 5;
            MaxMovingObstaclesCount = 10;

            MinMovingObstaclesSpeed = 1;
            MaxMovingObstaclesSpeed = DefaultSnakeSpeed / 2;

            MovingFoodsSpeed = 7;

            MinMovingObstaclesPrescaller = 20;
            MaxMovingObstaclesPrescaller = 40;
        }
    }
}
