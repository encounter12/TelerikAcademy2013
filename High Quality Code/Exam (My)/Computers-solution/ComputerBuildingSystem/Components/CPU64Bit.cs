using System;
using System.Linq;

namespace ComputerBuildingSystem.Components
{
    internal class Cpu64Bit: Cpu
    {
        private const int MinValue = 0;
        private const int MaxValue = 1000;

        public Cpu64Bit(int coresNumber): base(coresNumber)
        {
            this.CoresNumber = coresNumber;
        }

        public int CalculatePowerOfTwo(int number)
        {
            int powerOfTwo;

            if (number < MinValue)
            {
                throw new ArgumentOutOfRangeException("Number too low.");
            }
            else if (number > MaxValue)
            {
                throw new ArgumentOutOfRangeException("Number too high.");
            }
            else 
            {
                powerOfTwo = number * number; 
            }

            return powerOfTwo;
        }
    }
}
