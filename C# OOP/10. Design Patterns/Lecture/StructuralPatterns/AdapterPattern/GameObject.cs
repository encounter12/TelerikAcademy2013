using System;

namespace AdapterPattern
{
    public class GameObject
    {
        public virtual void Translate(Vector3 position)
        {
            Console.WriteLine("Translating to position of Vector3 x:{0} y:{1} z:{2}", position.X, position.Y, position.Z);
        }
    }
}