using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates_events_demos
{
   public class MouseEventArgs:EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }

        public MouseEventArgs(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
