using System;
using System.Collections.Generic;

namespace Figures
{
    public class Program
    {
        static void Main()
        {
            Shape[] shapes = new Shape[]
            {
                new Circle(3, 3),
                new Triangle(2, 4),
                new Rectangle(4, 8)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0, -17}, Area: {1}", shape.GetType(), shape.CalculateSurface());
            }

        }
    }
}
