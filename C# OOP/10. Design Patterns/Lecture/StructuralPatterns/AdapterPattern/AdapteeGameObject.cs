using System;

namespace AdapterPattern
{
    public class AdapteeGameObject
    {
        public void MoveToLocation(int x, int y, int z)
        {
            Console.WriteLine("Moving towards {0}, {1} {2}", x, y, z);
        }
    }
}