using System;
using System.Numerics;

namespace Figures
{
    public class Circle: Shape
    {
        public Circle(double width, double height)
        {
            this.Width = width;
            this.Height = height;

            if (this.Width != this.Height)
            {
                throw new Exception("Height and Width should be equal");
            }
        }

        public override double CalculateSurface()
        {
            return Math.PI * this.Height * this.Height;
        }
      
    }
}
