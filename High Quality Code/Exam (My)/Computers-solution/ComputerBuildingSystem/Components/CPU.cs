namespace ComputerBuildingSystem.Components
{
    using System;

    internal class Cpu: ICpu
    {
        private int coresNumber;

        public Cpu(int coresNumber)
        {
            this.CoresNumber = coresNumber;
        }

        public int CoresNumber
        {
            get
            {
                return this.coresNumber;
            }
            set
            {
                this.coresNumber = value;
            }
        }

        public int GenerateRandomNumber(int min, int max)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(min, max + 1);
            return randomNumber;
        }

        public void SaveRandomNumberToRam(int number, Ram ram)
        {
            ram.Value = number;
        }

        public virtual double CalculateSquareNumber(Ram ram)
        {
            double squareNumber = Math.Sqrt(ram.Value);
            return squareNumber;
        }
    }
}