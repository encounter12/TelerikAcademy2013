using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Threading;
using Animations.AnimationInterfaces;
using Animations.AnimationObjects;

namespace Animations
{
    class AnimationEngine : IAnimationEngine
    {
        private Ball[] Balls { get; set; }

        private DispatcherTimer timer;

        public int MaxX { get; set; }

        public int MaxY { get; set; }

        private static readonly Random rand = new Random();

        private readonly IRenderer renderer;
        
        private void InitializeBalls(int maxWidth, int maxHeight, int count)
        {
            this.Balls = new Ball[count];
            for (int i = 0; i < count; i++)
            {
                this.Balls[i] = this.GetBall(maxWidth, maxHeight);
            }
        }

        private Ball GetBall(int maxX, int maxY)
        {
            var x = rand.Next(maxX);
            var y = rand.Next(maxY);
            var speed = 15;
            var dirX = (rand.Next(2) % 2 == 0) ? Direction.Left : Direction.Right;
            var dirY = (rand.Next(2) % 2 == 0) ? Direction.Down : Direction.Up;
            var ballSize = 15;

            var ball = new Ball(x, y, dirX, dirY, speed, ballSize);
            return ball;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            foreach (var ball in this.Balls)
            {
                this.MoveBall(ball);
            }
            this.Draw();
        }

        private void MoveBall(Ball ball)
        {
            UpdateBallPosition(ball);
            ball.Move();
        }

        private void UpdateBallPosition(Ball ball)
        {
            if (ball.X < 0)
            {
                ball.ChangeDirectionX(Direction.Right);
            }
            if (ball.X > this.MaxX)
            {
                ball.ChangeDirectionX(Direction.Left);
            }
            if (ball.Y < 0)
            {
                ball.ChangeDirectionY(Direction.Down);
            }
            if (ball.Y > this.MaxY)
            {
                ball.ChangeDirectionY(Direction.Up);
            }
        }

        private void Draw()
        {
            this.renderer.Clear();
            foreach (var ball in this.Balls)
            {
                this.renderer.Render(ball);
            }
        }

        public AnimationEngine(Canvas container, int maxX, int maxY)
        {
            this.InitializeBalls((int)container.Width, (int)container.Height, 50);
            this.MaxX = maxX;
            this.MaxY = maxY;
            this.renderer = new Renderer(container);
            this.timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += OnTimerTick;
        }

        public void Start()
        {
            if (this.timer.IsEnabled)
            {
                this.timer.Stop();
            }
            this.timer.Start();
        }

        public void Stop()
        {
            if (this.timer.IsEnabled)
            {
                this.timer.Stop();
            }
        }
    }
}