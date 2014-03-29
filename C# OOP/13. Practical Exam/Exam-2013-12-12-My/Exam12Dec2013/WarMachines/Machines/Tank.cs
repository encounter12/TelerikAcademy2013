namespace WarMachines.Machines
{
    using System;
    using System.Linq;
    using WarMachines.Interfaces;

    class Tank : Machine, ITank
    {
        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = 100;
            this.DefenseMode = true;
        }
        
        public bool DefenseMode
        {
            get
            {
                return this.defenseMode;
            }
            set
            {
                if (value == true)
                {
                    this.DefensePoints += 30;
                    this.AttackPoints -= 40;
                }
                else
                {
                    this.DefensePoints -= 30;
                    this.AttackPoints += 40;
                }
                this.defenseMode = value;
            }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
            }
            else
            {
                this.DefenseMode = true;
            }
        }
    }
}
