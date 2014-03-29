namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;

        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            set
            {
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }
            set
            {
                this.defensePoints = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }
            set
            {
                this.targets = value;
            }
        }

        public void Attack(string target)
        {
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("- {0}", this.Name).AppendLine();
            sb.AppendFormat(" *Type: {0}", this is Tank ? "Tank" : "Fighter").AppendLine();
            sb.AppendFormat(" *Health: {0}", this.HealthPoints).AppendLine();
            sb.AppendFormat(" *Attack: {0}", this.AttackPoints).AppendLine();
            sb.AppendFormat(" *Defense: {0}", this.DefensePoints).AppendLine();
            sb.AppendFormat(" *Targets: ");
            if (this.Targets.Count == 0)
            {
		        sb.Append("None");
            }
            else
            {
                string targets = string.Join(", ", this.Targets.ToArray());
                sb.Append(targets);
            }
            sb.AppendLine();
            if (this is Tank)
            {
                Tank currentTank = (Tank)this;
		        sb.AppendFormat(" *Defense: {0}", currentTank.DefenseMode == true ? "ON" : "OFF");
                sb.AppendLine();
            }
            else
            {
                Fighter currentFighter = (Fighter)this;
                sb.AppendFormat(" *Stealth: {0}", currentFighter.StealthMode == true ? "ON" : "OFF");
            }
            
            return sb.ToString();
        }
    }
}
