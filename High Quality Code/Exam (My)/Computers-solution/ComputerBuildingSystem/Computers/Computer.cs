namespace ComputerBuildingSystem.Computers
{
    using ComputerBuildingSystem.Components;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Computer
    {
        private ICpu cpu;
        private Ram ram;
        private List<HardDrive> hardDrives;

        public Computer(ICpu cpu, Ram ram, List<HardDrive> hardDrives)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
        }
        public ICpu Cpu
        {
            get
            {
                return this.cpu;
            }
            set
            {
                this.cpu = value;
            }
        }

        public Ram Ram
        {
            get
            {
                return this.ram;
            }
            set
            {
                this.ram = value;
            }
        }

        public List<HardDrive> HardDrives
        {
            get
            {
                return this.hardDrives;
            }
            set
            {
                this.hardDrives = value;
            }
        }
    }
}
