using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApacheCombatRocks
{
    class Rock
    {
        private int startX;
        private int startY;
        private string[,] rockElements;

        public string[,] RockElements
        {
            get
            {
                return this.rockElements;
            }
        }

        public int StartX
        {
            get { return startX; }
            set { startX = value; }
        }

        public int StartY
        {
            get { return startY; }
            set { startY = value; }
        }
        public int EndX
        {
            get { return startX + rockElements.GetLength(1); }
        }
        public int EndY
        {
            get { return startY + rockElements.GetLength(0); }
        }
        public int Height
        {
            get { return rockElements.GetLength(0); }
        }
        public int Width
        {
            get { return rockElements.GetLength(1); }
        }

        public Rock(string[,] rockElements, int startX, int startY)
        {
            this.rockElements = rockElements;
            this.startX = startX;
            this.startY = startY;
        } 
    }
}
