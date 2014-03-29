using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Animations.AnimationInterfaces;
using Animations.AnimationObjects;

namespace Animations
{
    class Renderer : IRenderer
    {
        private readonly Brush BallFillColor = Brushes.AliceBlue;
        private readonly Brush BallStrokeColor = Brushes.DarkBlue;

        public Renderer(Canvas container)
        {
            this.Container = container;
        }

        public void Render(object obj)
        {
            if (obj is Ball)
            {
                this.RenderBall(obj as Ball);
            }
        }

        public void Clear()
        {
            this.Container.Children.Clear();
        }

        private void RenderBall(Ball ball)
        {
            var ballElement = new Ellipse();
            ballElement.Height = ball.Size;
            ballElement.Width = ball.Size;
            ballElement.Fill = BallFillColor;
            ballElement.Stroke = BallStrokeColor;

            Canvas.SetLeft(ballElement, ball.X);
            Canvas.SetTop(ballElement, ball.Y);

            this.Container.Children.Add(ballElement);
        }

        private Canvas Container { get; set; }
    }
}
