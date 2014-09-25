using System;
using System.Linq;
using ComputerBuildingSystem.Components;
using System.Collections.Generic;

namespace ComputerBuildingSystem.Computers
{
    internal class Server: Computer
    {
        private IVideoCard videocard;

        public Server(ICpu cpu, Ram ram, List<HardDrive> hardDrives) : base(cpu, ram, hardDrives)
        {
            this.Videocard = new MonochromeVideoCard();
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
    }
}
