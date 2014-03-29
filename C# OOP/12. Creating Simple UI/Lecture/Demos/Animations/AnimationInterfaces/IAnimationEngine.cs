using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Animations.AnimationInterfaces
{
    public interface IAnimationEngine
    {
        int MaxX { get; set; }

        int MaxY { get; set; }

        void Start();

        void Stop();
    }
}