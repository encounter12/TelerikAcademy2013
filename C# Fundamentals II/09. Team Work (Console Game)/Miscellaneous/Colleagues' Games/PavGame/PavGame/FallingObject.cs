using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavGame
{
    class FallingObject
    {
        private int startX;
        private int endY;
        private string[,] obstacleRows;
        private ConsoleColor color;

        public string[,] ObstacleRows
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
           get { return endY - obstacleRows.GetLength(0) + 1; }
        }
        public int EndX
        {
            get { return startX + obstacleRows.GetLength(1) - 1; }
        }
        public int EndY
        {
            get { return endY; }
            set { endY = value; }
        }
        public int Height
        {
            get { return obstacleRows.GetLength(0); }
        }
        public int Width
        {
            get { return obstacleRows.GetLength(1); }
        }

        public ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }

        public FallingObject(string[,] obstacleRows, int startX, int endY, ConsoleColor color)
        {
            this.obstacleRows = obstacleRows;
            this.startX = startX;
            this.endY = endY;
            this.color = color;
        }

        public void MoveDown()
        {
            endY++;
        }
    }
}
