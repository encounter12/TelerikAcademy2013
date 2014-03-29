using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnakeGame.GameObjects;

namespace SnakeGameJMTestProject.Objects
{
    class GameObjectInheritor:GameObject
    {
        public GameObjectInheritor(int x, int y, int size)
            : base(x, y, size)
        {
        }
    }
}
