using System;
using System.Linq;
using ComputerBuildingSystem.Components;
using System.Collections.Generic;

namespace ComputerBuildingSystem.Computers
{
    internal class PersonalComputer: Computer
    {
        private const int MinGameValue = 1;
        private const int MaxGameValue = 10;
        private IVideoCard videocard;

        public PersonalComputer(ICpu cpu, Ram ram, List<HardDrive> hardDrives, IVideoCard videocard): base(cpu, ram, hardDrives)
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

        public void PlayGame(int userGuessNumber)
        {
            int randomNumber = this.Cpu.GenerateRandomNumber(MinGameValue, MaxGameValue);
            string displayMessage = "You win!";
            if (randomNumber == userGuessNumber)
            {
                this.videocard.PrintOnConsole(displayMessage);
            }
            else
            {
                displayMessage = "You didn’t guess the number " + randomNumber + ".";
                this.videocard.PrintOnConsole(displayMessage);
            }
        }
    }
}
