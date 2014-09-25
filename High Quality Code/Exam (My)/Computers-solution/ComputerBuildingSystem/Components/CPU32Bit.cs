using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildingSystem.Components
{
    internal class Cpu32Bit: Cpu
    {
        private const int MinValue = 0;
        private const int MaxValue = 500;

        public Cpu32Bit(int coresNumber): base(coresNumber)
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
