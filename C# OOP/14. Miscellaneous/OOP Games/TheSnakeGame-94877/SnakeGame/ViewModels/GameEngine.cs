using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnakeGame.GameObjects;
using System.Windows.Threading;
using SnakeGame.Helpers;
using System.Collections.ObjectModel;

namespace SnakeGame.ViewModels
{
    public class GameEngine : BaseViewModel
    {
        private static readonly Random rand = new Random();
        DispatcherTimer timer;
        private ObservableCollection<Obstacle> obstacles;
        private ObservableCollection<MovingObstacle> movingObstacles;
        private ObservableCollection<Food> foods;
        private ObservableCollection<MovingFood> movingFoods;
        private int movingObstaclesPrescaller;

        public GameEngine()
        {
        }

        public int Height
        {
            get
            {
                return Constants.MaxY;
            }
        }
        public int Width
        {
            get
            {
                return Constants.MaxX;
            }
        }
        public Snake Snake { get; set; }
        public SnakeObstacle SnakeObstacle { get; set; }
        public IEnumerable<Food> Foods
        {
            get
            {
                return this.foods;
            }
            set
            {
                if (this.foods == null)
                {
                    this.foods = new ObservableCollection<Food>();
                }
                else
                {
                    this.foods.Clear();
                }
                foreach (var item in value)
                {
                    this.foods.Add(item);
                }
                this.OnPropertyChanged("Foods");
            }
        }

        public IEnumerable<MovingFood> MovingFoods
        {
            get
            {
                return this.movingFoods;
            }
            set
            {
                if (this.movingFoods == null)
                {
                    this.movingFoods = new ObservableCollection<MovingFood>();
                }
                else
                {
                    this.movingFoods.Clear();
                }
                foreach (var item in value)
                {
                    this.movingFoods.Add(item);
                }
                this.OnPropertyChanged("MovingFoods");
            }
        }
        public IEnumerable<Obstacle> Obstacles
        {
            get
            {
                return this.obstacles;
            }
            set
            {
                if (this.obstacles == null)
                {
                    this.obstacles = new ObservableCollection<Obstacle>();
                }
                else
                {
                    this.obstacles.Clear();
                }
                foreach (var item in value)
                {
                    this.obstacles.Add(item);
                }
                this.OnPropertyChanged("Obstacles");
            }
        }
        public IEnumerable<MovingObstacle> MovingObstacles
        {
            get
            {
                return this.movingObstacles;
            }
            set
            {
                if (this.movingObstacles == null)
                {
                    this.movingObstacles = new ObservableCollection<MovingObstacle>();
                }
                else
                {
                    this.movingObstacles.Clear();
                }
                foreach (var item in value)
                {
                    this.movingObstacles.Add(item);
                }
                this.OnPropertyChanged("MovingObstacles");
            }
        }

        private void MoveObstacles()
        {
            foreach (var obstacle in this.MovingObstacles)
            {
                obstacle.Move();
            }

            OnPropertyChanged("MovingObstacles");
        }

        private void MoveFoods()
        {
            foreach (var movingFood in this.MovingFoods)
            {
                movingFood.Move();
            }

            OnPropertyChanged("MovingFoods");
        }

        public void ChangeDirection(MoveDirections direction)
        {
            Snake.ChangeDirection(direction);
        }

        public void StartGame()
        {
            InitializeSnake();
            InitializeSnakeObstacle();
            InitilizeObstacles();
            InitilizeMovingObstacles();
            InitilizeFood();
            if (timer != null)
            {
                timer.Stop();
            }
            movingObstaclesPrescaller = rand.Next(Constants.MinMovingObstaclesPrescaller, Constants.MaxMovingObstaclesPrescaller);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            int ticksCounter = 0;
            timer.Tick += delegate
            {
                Snake.Move();
                SnakeObstacle.Move();
                
                if (ticksCounter == movingObstaclesPrescaller)
                {
                    MovingObstacleChangeDirection();
                    SnakeObstacleChangeDirection();
                    ticksCounter = 0;
                }

                
                //if (ticksCounter == movingObstaclesPrescaller)
                //{
                    //ticksCounter = 0;

                foreach (var movingFood in this.MovingFoods)
                {
                    var shouldChangeDirection = rand.Next() % 3 == 0;
                    if (shouldChangeDirection)
                    {
                        MoveDirections newDirection = (MoveDirections)rand.Next(0, 4);
                        movingFood.ChangeDirection(newDirection);
                    }
                }
                //}

                ticksCounter++;
                
                this.MoveObstacles();
                this.MoveFoods();

                CheckFoodEaten();
                CheckFoodEatenSnkeObstakle();
                var isDead = CheckSnakeDead();
                if (isDead)
                {
                    GameOver();
                }
                this.OnPropertyChanged("Snake");
                this.OnPropertyChanged("SnakeObstacle");
                this.OnPropertyChanged("Foods");
                this.OnPropertyChanged("Obstacles");
                this.OnPropertyChanged("MovingFoods");
            };
            timer.Start();
        }
  
        

        private void GameOver()
        {
            timer.Stop();
        }

        private void CheckFoodEaten()
        {
            foreach (var food in this.Foods)
            {
                var isOver = IsOver(Snake.Position, Snake.Parts[0].Size,
                    food.Position, food.Size);
                if (isOver)
                {
                    this.Snake.Grow();
                    food.Destroy();
                    ChangeFoodPosition(food);
                    break;
                }
            }

            CheckMovingFoodEaten();
        }

        private void CheckMovingFoodEaten()
        {
            foreach (var movingFood in this.MovingFoods)
            {
                var isOver = IsOver(Snake.Position, Snake.Parts[0].Size,
                    movingFood.Position, movingFood.Size);
                if (isOver)
                {
                    this.Snake.Grow();
                    movingFood.Destroy();
                    ChangeFoodPosition(movingFood);
                    break;
                }
            }
        }

        private void ChangeFoodPosition(Food food)
        {
            Position pos;
            int size = Constants.SquareSize;
            do
            {
                int x = rand.Next(Constants.MaxX - size);
                int y = rand.Next(Constants.MaxY - size);
                pos = new Position(x, y);
            }
            while (CheckFoodOverObstacles(pos, size));
            food.Position.X = pos.X;
            food.Position.Y = pos.Y;
        }

        private bool CheckSnakeDead()
        {
            var eaten = CheckEatenItself();
            var crashed = CheckCrashedInObstacle();
            var crashedInMovingObstacle = CheckCrashedInMovingObstacle();
            var crashedInMovingSnakeObstacke = CheckCrashedInSnakeObstacle();
            return eaten || crashed || crashedInMovingObstacle || crashedInMovingSnakeObstacke;
        }

        private bool CheckCrashedInObstacle()
        {
            var head = this.Snake.Parts[0];
            foreach (var obstacle in this.Obstacles)
            {
                var isOver = IsOver(head.Position, head.Size,
                    obstacle.Position, obstacle.Size);
                if (isOver)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckCrashedInMovingObstacle()
        {
            foreach (var snakePart in this.Snake.Parts)
            {
                foreach (var movingObstacle in this.MovingObstacles)
                {
                    var isOver = IsOver(snakePart.Position, snakePart.Size,
                        movingObstacle.Position, movingObstacle.Size);
                    if (isOver)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool CheckCrashedInSnakeObstacle()
        {
            foreach (var snakePart in this.Snake.Parts)
            {
                foreach (var snakeObstaclePart in this.SnakeObstacle.Parts)
                {
                    var isOver = IsOver(snakePart.Position, snakePart.Size,
                        snakeObstaclePart.Position, snakeObstaclePart.Size);
                    if (isOver)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void MovingObstacleChangeDirection()
        {
            foreach (var movingObstacle in this.MovingObstacles)
            {
                MoveDirections newDirection = (MoveDirections)rand.Next(0, 4);
                movingObstacle.ChangeDirection(newDirection);
            }
        }
        
        private void SnakeObstacleChangeDirection()
        {
            MoveDirections newDirection = (MoveDirections)rand.Next(0, 4);
            SnakeObstacle.ChangeDirection(newDirection);
        }
        private bool CheckEatenItself()
        {
            var head = this.Snake.Parts[0];
            for (int i = 1; i < this.Snake.Parts.Count; i++)
            {
                var part = this.Snake.Parts[i];
                var isOver = IsOver(head.Position, head.Size,
                    part.Position, part.Size);
                if (isOver)
                {
                    return true;
                }
            }
            return false;
        }

        private void InitializeSnake()
        {
            var x = Constants.MaxX / 2;
            var y = Constants.MaxY / 2;
            var position = new Position(x, y);
            var size = Constants.DefaultSnakeSize;
            var speed = Constants.DefaultSnakeSpeed;
            this.Snake = new Snake(position, size, speed);
        }
        private void InitializeSnakeObstacle()
        {
            var x = Constants.MaxX / 4;
            var y = Constants.MaxY / 4;
            var position = new Position(x, y);
            var size = Constants.DefaultSnakeSize;
            var speed = Constants.DefaultSnakeSpeed;
            this.SnakeObstacle = new SnakeObstacle(position, size, speed);
        }
        private void InitilizeObstacles()
        {
            var obstaclesCount = rand.Next(Constants.MinObstaclesCount, Constants.MaxObstaclesCount);
            List<Obstacle> obstacles = new List<Obstacle>();
            for (int i = 0; i < obstaclesCount; i++)
            {
                var size =Constants.SquareSize;

                var x = rand.Next(Constants.MaxX - size);
                var y = 0;
                do
                {
                    y = rand.Next(Constants.MaxY - size - 50);
                }
                while (y >= Constants.MaxY / 2 - Constants.SquareSize && y <= Constants.MaxY / 2 + Constants.SquareSize );

                Position position = new Position(x, y);
                var newObstacle = new Obstacle(position, size);
                obstacles.Add(newObstacle);
            }
            this.Obstacles = obstacles;
        }

        private void InitilizeMovingObstacles()
        {
            var movingObstaclesCount = 
                rand.Next(Constants.MinMovingObstaclesCount, 
                Constants.MaxMovingObstaclesCount);
            List<MovingObstacle> movingObstacles = new List<MovingObstacle>();
            for (int i = 0; i < movingObstaclesCount; i++)
            {
                var size =Constants.SquareSize;

                var x = rand.Next(Constants.MaxX - size);
                var y = rand.Next(Constants.MaxY - size);
                Position position = new Position(x, y);
                var newObstacle = new MovingObstacle(position, size, rand.Next(Constants.MinMovingObstaclesSpeed, Constants.MaxMovingObstaclesSpeed));
                movingObstacles.Add(newObstacle);
            }
            this.MovingObstacles = movingObstacles;
        }

        private void InitilizeFood()
        {
            var foods = new List<Food>();

            var foodCount = Constants.FoodCount;
            for (int i = 0; i < foodCount; i++)
            {
                int size = Constants.SquareSize;
                int x = rand.Next(Constants.MaxX - size);
                int y = rand.Next(Constants.MaxY - size - 50);
                Position pos = new Position(x, y);
                bool isOver;
                if (foods.Count==0)
                {
                    isOver = CheckFoodOverObstacles(pos, size);
                }
                else
                {
                    isOver = CheckFoodOverObstacles(pos, size) || CheckFoodOverFood(pos,size);
                } 
                if (!isOver)
                {
                    Food food = new Food(pos, size);
                    foods.Add(food);
                    this.Foods = foods;
                }
                else
                {
                    i--;
                }
            }

            this.Foods = foods;

            //Added InitializeMovingFood();
            InitializeMovingFood();
        }

        private void InitializeMovingFood()
        {
            var movingFoods = new List<MovingFood>();
            var movingFoodCount = Constants.MovingFoodCount;
            for (int i = 0; i < movingFoodCount; i++)
            {
                int size = Constants.SquareSize;
                int x = rand.Next(Constants.MaxX - size);
                int y = rand.Next(Constants.MaxY - size);
                Position pos = new Position(x, y);
                var isOver = CheckFoodOverObstacles(pos, size);
                if (!isOver)
                {
                    MovingFood movingFood = new MovingFood(pos, size, Constants.MovingFoodsSpeed);
                    movingFoods.Add(movingFood);
                }
                else
                {
                    i--;
                }
            }
            this.MovingFoods = movingFoods;
        }

        //private void CheckFoodEaten()
        //{
        //    foreach (var food in this.Foods)
        //    {
        //        var isOver = IsOver(Snake.Position, Snake.Parts[0].Size,
        //            food.Position, food.Size);
        //        if (isOver)
        //        {
        //            this.Snake.Grow();
        //            this.foods.Remove(food);
        //            GenerateNewFood();
        //            break;
        //        }
        //    }
        //}

        private void CheckFoodEatenSnkeObstakle()
        {
            foreach (var food in this.Foods)
            {
                var isOver = IsOver(SnakeObstacle.Position, SnakeObstacle.Parts[0].Size,
                    food.Position, food.Size);
                if (isOver)
                {
                    this.SnakeObstacle.Grow();
                    this.foods.Remove(food);
                    GenerateNewFood();
                    break;
                }
            }
        }

        private void GenerateNewFood()
        {
            
            Position pos;
            int size = Constants.SquareSize;
            do
            {
                int x = rand.Next(Constants.MaxX - size);
                int y = rand.Next(Constants.MaxY - size - 50);
                pos = new Position(x, y);
            }
            while (CheckFoodOverObstacles(pos, size) || CheckFoodOverFood(pos,size));
            Food food = new Food(pos,size);
            food.Position.X = pos.X;
            food.Position.Y = pos.Y;
            this.foods.Add(food);
        }

        private bool CheckFoodOverObstacles(Position pos, int size)
        {
            foreach (var item in this.Obstacles)
            {
                bool isOver = IsOver(item.Position, item.Size, pos, size);
                if (isOver)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckFoodOverFood(Position pos, int size)
        {
            foreach (var item in this.Foods)
            {
                bool isOver = IsOver(item.Position, item.Size, pos, size);
                if (isOver)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsOver(Position p1, int size1, Position p2, int size2)
        {
            var fX1 = p1.X;
            var fX2 = p1.X + size1 - 1;

            var fY1 = p1.Y;
            var fY2 = p1.Y + size1 - 1;

            var oX1 = p2.X;
            var oX2 = p2.X + size2 - 1;

            var oY1 = p2.Y;
            var oY2 = p2.Y + size2 - 1;

            bool fX1InObstacle = oX1 <= fX1 && fX1 <= oX2;
            bool fX2InObstacle = oX1 <= fX2 && fX2 <= oX2;

            bool fY1InObstacle = oY1 <= fY1 && fY1 <= oY2;
            bool fY2InObstacle = oY1 <= fY2 && fY2 <= oY2;

            return (fX1InObstacle || fX2InObstacle) &&
                   (fY1InObstacle || fY2InObstacle);
        }

        private MoveDirections GetRandomDirection(List<MoveDirections> allowedDirections)
        {
            Random randomGenerator = new Random((int)DateTime.Now.Ticks);
            int randomIndex = randomGenerator.Next(allowedDirections.Count);
            return allowedDirections[randomIndex];
        }

        private List<MoveDirections> GetAllowedDirections(Position currentPosition)
        {
            List<MoveDirections> allowedDirections = new List<MoveDirections>();
            foreach (var obstacle in this.obstacles)
            {
                for (int i = 0; i < Constants.DX.Count; i++)
                {
                    MoveDirections currentDirection = (MoveDirections)i;
                    int changeX = Constants.DX[currentDirection];
                    int changeY = Constants.DY[currentDirection];
                    Position nextPosition =
                        new Position(currentPosition.X + changeX, currentPosition.Y + changeY);
                    //if (obstacle.Position.X != nextPosition.X ||
                    //    obstacle.Position.Y != nextPosition.Y)
                    if (!IsOver(nextPosition, Constants.SquareSize, obstacle.Position, obstacle.Size))
                    {
                        if (!allowedDirections.Contains(currentDirection))
                        {
                            allowedDirections.Add(currentDirection);
                        }
                    }
                }
            }
            return allowedDirections;
        }
    }
}
