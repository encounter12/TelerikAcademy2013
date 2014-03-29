using System;
using System.Collections.Generic;

namespace Points
{
    public static class RandomPaths
    {
        private static readonly Random random = new Random();

        public static List<Path> CreateRandomNumberOfPaths()
        {
            List<Path> paths = new List<Path>();

            for (int i = 0; i < random.Next(1, 6); i++)
            {
                paths.Add(CreateSingleRandomPath());
            }

            return paths;
        }

        private static Path CreateSingleRandomPath()
        {            
            Path path = new Path();

            //generates from 1 to 10 points
            for (int i = 0; i < random.Next(1, 11); i++)
            {
                Point3D point = RandomPoint.CreateRandomPoint();
                path.AddPoint(point);
            }

            return path;
        }
    }
}
