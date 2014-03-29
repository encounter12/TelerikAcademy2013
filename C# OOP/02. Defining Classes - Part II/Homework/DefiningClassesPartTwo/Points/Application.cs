using System;
using System.Collections.Generic;

namespace Points
{    
    class Application
    {       
        static void Main()
        {
            Window.PrintPoint0();
            
            Point3D pointA = RandomPoint.CreateRandomPoint();
            Point3D pointB = RandomPoint.CreateRandomPoint();

            double distance = Distance.CalculateDistance(pointA, pointB);

            Window.PrintDistanceBetweenTwoPoints(distance, pointA, pointB);
            
            List<Path> paths = RandomPaths.CreateRandomNumberOfPaths();
            PathStorage.SavePaths(paths);
            paths = PathStorage.LoadPaths();
            Window.PrintPaths(paths);
        }
    }
}
