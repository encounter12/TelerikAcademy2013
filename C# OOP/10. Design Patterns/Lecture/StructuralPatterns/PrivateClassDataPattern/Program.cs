using System;

namespace PrivateClassDataPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(20, 33);

            Console.WriteLine("Rect area: {0:0.00}", rect.Area());
        }
    }
}