using System;
using System.Linq;
using ComputerBuildingSystem.Interfaces;
using ComputerBuildingSystem.Computers;

namespace ComputerBuildingSystem.Components
{
    class Motherboard : IMotherboard
    {
        private Computer computer;

        public Computer Computer
        {
            get
            {
                return this.computer;
            }
            set
            {
                this.computer = value;
            }
        }

        public int LoadRamValue()
        {
            int ramValue = this.Computer.Ram.Value;
            return ramValue;
        }
        
        public void SaveRamValue(int value)
        {
            this.Computer.Ram.Value = value;
        }
        
        public void DrawOnVideoCard(string data)
        {
            // TODO: DrawOnVideoCard to be implemented.
        }
    }
}
