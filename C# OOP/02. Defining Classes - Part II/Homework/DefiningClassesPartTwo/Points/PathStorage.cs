using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Points
{
    public static class PathStorage
    {
        static readonly string fileName = "PointsPaths.txt";

        public static void SavePaths(List<Path> paths)
        {                        
            using (StreamWriter file = new StreamWriter(fileName, true))
            {
                foreach (Path path in paths)
                {
                    StringBuilder pathBuild = new StringBuilder();

                    for (int i = 0; i < path.Points.Count; i++)
                    {
                        pathBuild.Append(path.Points[i].X);
                        pathBuild.Append(" ");
                        pathBuild.Append(path.Points[i].Y);
                        pathBuild.Append(" ");
                        pathBuild.Append(path.Points[i].Z);

                        if (i < path.Points.Count - 1)
                        {
                            pathBuild.Append(" | ");
                        }
                    }

                    //appends the current path to the text file, see: http://msdn.microsoft.com/en-us/library/36b035cb.aspx 
                    file.WriteLine(pathBuild.ToString());                   
                }                      
            }                                          
        }

        public static List<Path> LoadPaths()
        {
            List<Path> paths = new List<Path>();

            if (File.Exists(fileName) == true)
            {
                string line;                
                StreamReader file = new StreamReader(fileName);

                while ((line = file.ReadLine()) != null)
                {                    
                    string[] pointsString = line.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                    Path points = new Path();
                    
                    foreach (string pointString in pointsString)
                    {
                        Point3D point = new Point3D();                       
                        string[] pointCoordinates = pointString.Split(' ');
                        point.X = double.Parse(pointCoordinates[0]);
                        point.Y = double.Parse(pointCoordinates[1]);
                        point.Z = double.Parse(pointCoordinates[2]);
                        points.AddPoint(point);
                    }

                    paths.Add(points);
                }

                file.Close();
            }
            else
            {
                throw new InvalidOperationException("The paths text file has not been found");
            }

            return paths;
        }

    }
}
