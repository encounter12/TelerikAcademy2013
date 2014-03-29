using System;

namespace Points
{
    public struct Point3D
    {        
        private static readonly Point3D point0 = new Point3D(0, 0, 0);


        public Point3D(double x, double y, double z): this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        
        public override string ToString()
        {
            return "3D Point: X = " + X + ", Y = " + Y + ", Z = " + Z;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public static Point3D Point0
        {
            get
            {
                return point0;
            }           
        }
    }
}
