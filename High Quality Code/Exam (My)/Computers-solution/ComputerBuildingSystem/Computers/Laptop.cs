using System;
using System.Collections.Generic;
using System.Linq;
using ComputerBuildingSystem.Components;

namespace ComputerBuildingSystem.Computers
{
    internal class Laptop: Computer
    {
        private IVideoCard videocard;
        private LaptopBattery battery;

        public Laptop(ICpu cpu, Ram ram, List<HardDrive> hardDrives, IVideoCard videocard): base(cpu, ram, hardDrives)
        {
            this.Videocard = videocard;
        }

        public IVideoCard Videocard
        {
            get
            {
                return this.videocard;
            }
            set
            {
                this.videocard = value;
            }
        }

        public LaptopBattery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public void ChargeBattery(int chargingPowerPercenrage)
        {
            this.battery.Charge(chargingPowerPercenrage);
            string statusMessage = "Battery status: " + chargingPowerPercenrage + "%";
            this.Videocard.PrintOnConsole(statusMessage);
        }
    }
}
