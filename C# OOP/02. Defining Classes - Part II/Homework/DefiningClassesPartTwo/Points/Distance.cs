using System;

namespace Points
{
    public static class Distance
    {
        public static double CalculateDistance(Point3D point1, Point3D point2)
        {
            double distance = 0;
            distance = Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow(point2.Y - point1.Y, 2) + Math.Pow(point2.Z - point1.Z, 2));
            return distance;
        }
    }
}
