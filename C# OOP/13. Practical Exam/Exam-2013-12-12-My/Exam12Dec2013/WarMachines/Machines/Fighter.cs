namespace WarMachines.Machines
{
    using System;
    using System.Linq;
    using WarMachines.Interfaces;

    class Fighter : Machine, IFighter
    {
        private bool stealthMode;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode) : base(name, attackPoints, defensePoints)
        {
            this.StealthMode = stealthMode;
            this.HealthPoints = 200;
        }
        
        public bool StealthMode
        {
            get
            {
                return this.stealthMode;
            }
            set
            {
                this.stealthMode = value;
            }
        }

        public void ToggleStealthMode()
        {
            if (this.StealthMode == true)
            {
                this.StealthMode = false;
            }
            else
            {
                this.StealthMode = true;
            }
        }
    }
}
