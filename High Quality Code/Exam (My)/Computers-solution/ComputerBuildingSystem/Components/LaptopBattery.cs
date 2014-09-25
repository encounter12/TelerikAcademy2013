namespace ComputerBuildingSystem.Components
{
    using System;

    internal class LaptopBattery : Battery
    {
        private const int DefaultPowerInPercentage = 50;
        private int powerLeftInPercentage;

        internal LaptopBattery()
        {
            this.PowerLeftInPercentage = DefaultPowerInPercentage;
        }

        public int PowerLeftInPercentage
        {
            get
            {
                return this.powerLeftInPercentage;
            }
            set
            {
                this.powerLeftInPercentage = value;
            }
        }

        public void Charge(int chargingPower)
        {
            int currentPower = this.powerLeftInPercentage + chargingPower;
            if (currentPower > 100)
            {
                this.PowerLeftInPercentage = 100;
            }
            else if (currentPower < 0)
            {
                this.PowerLeftInPercentage = 0;
            }
            else
            {
                throw new ArgumentException("Charging power not of correct type!");
            }
        }
    }
}