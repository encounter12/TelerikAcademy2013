using System;

namespace Points
{
    public static class RandomPoint
    {
        private static readonly Random random = new Random();

        public static Point3D CreateRandomPoint()
        {            
            Point3D point = new Point3D(random.Next(-20, 21), random.Next(-20, 21), random.Next(-20, 21));
            return point;
        }
    }
}
