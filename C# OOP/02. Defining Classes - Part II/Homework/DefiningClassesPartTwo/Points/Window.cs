using System;
using System.Collections.Generic;
using System.Text;

namespace Points
{
    public static class Window
    {
        public static void PrintPaths(List<Path> paths)
        {
            foreach (Path path in paths)
            {
                int counter = 0;
                StringBuilder pathBuild = new StringBuilder();

                foreach (Point3D point in path.Points)
                {
                    pathBuild.Append(point.X);
                    pathBuild.Append(" ");
                    pathBuild.Append(point.Y);
                    pathBuild.Append(" ");
                    pathBuild.Append(point.Z);

                    if (counter < path.Points.Count - 1)
                    {
                        pathBuild.Append(" | ");
                    }
                    counter++;
                }
                Console.WriteLine(pathBuild.ToString());
            }            
        }

        public static void PrintPoint0()
        {
            Console.WriteLine(Point3D.Point0);
        }

        public static void PrintDistanceBetweenTwoPoints(double distance, Point3D pointA, Point3D pointB)
        {
            Console.WriteLine("Distance between point A({0}, {1}, {2}) and point B({3}, {4}, {5}) : {6:F2}", 
                pointA.X, pointA.Y, pointA.Z, pointB.X, pointB.Y, pointB.Z, distance);
        }
    }
}
