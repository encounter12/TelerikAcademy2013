using System;
using System.Collections.Generic;
using System.Linq;

namespace ApacheCombat
{
    class Helicopter
    {
        private int startX = 0;
        private int startY = 0;
        private int previousStartX = 0;
        private int previousStartY = 0;

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
        public int PreviousStartX
        {
            get { return previousStartX; }
            set { previousStartX = value; }
        }
        public int PreviousStartY
        {
            get { return previousStartY; }
            set { previousStartY = value; }
        }        
        public int EndX
        {
            get { return startX + helicopterRows[0].Length - 1; }
        }

        public int EndY
        {
            get { return startY + helicopterRows.Count - 1; }
        }

        public int Height
        {
            get { return helicopterRows.Count; }
        }
        public int Width
        {
            get { return helicopterRows[0].Length; }
        }

        public List<string> helicopterRows = new List<string>()
        {
            "    ------- # -------",
            "###     -******-     ",
            "**********#    ***   ",
            " #      *******      "
        };
       
        public void SetStartPosition(int startX, int startY)
        {
            this.startX = startX;
            this.startY = startY;
            this.previousStartX = startX;
            this.previousStartY = startY;
        }

        public void MoveUp()
        {
            previousStartY = startY;
            if (startY > 0)
            {                
                startY--;
            }

        }
        public void MoveDown()
        {
            previousStartY = startY;
            if (startY + Height < Game.consoleWindowHeight - 1)
            {                
                startY++;
            }           
        }
    }
}
