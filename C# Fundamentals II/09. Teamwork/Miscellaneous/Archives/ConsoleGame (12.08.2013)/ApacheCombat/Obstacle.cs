using System;
using System.Collections.Generic;
using System.Linq;

namespace ApacheCombat
{
    class Obstacle
    {
        private int startX;
        private int startY;
        private string[,] obstacleRows;
               
        public string[,] ObstacleElements
        {
            get
            {
                return this.obstacleRows;
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
            get { return startX + obstacleRows.GetLength(1) - 1; }
        }
        public int EndY
        {
            get { return startY + obstacleRows.GetLength(0) - 1; }
        }
        public int Height
        {
            get { return obstacleRows.GetLength(0); }
        }
        public int Width
        {
            get { return obstacleRows.GetLength(1); }
        }

        public Obstacle(string[,] obstacleRows, int startX, int startY)
        {
            this.obstacleRows = obstacleRows;
            this.startX = startX;
            this.startY = startY;
        }

        public void MoveLeft()
        {
            startX--;
        }        
    }
}
