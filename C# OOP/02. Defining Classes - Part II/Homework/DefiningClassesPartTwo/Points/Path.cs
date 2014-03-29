using System;
using System.Collections.Generic;

namespace Points
{
    public class Path
    {
        private readonly List<Point3D> points = new List<Point3D>();
       
        public List<Point3D> Points
        {
            get
            {
                return this.points;
            }       
        }

        public void AddPoint(Point3D point)
        {
            points.Add(point);
        }
    }
}
