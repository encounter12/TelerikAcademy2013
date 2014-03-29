using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.GameObjects
{
    public interface IDestroyable
    {
        void Destroy();

        bool IsDestroyed { get; set; }
    }
}
