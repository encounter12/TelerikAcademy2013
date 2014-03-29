namespace WarMachines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.Machines = new List<IMachine>();
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

        public List<IMachine> Machines
        {
            get
            {
                return this.machines;
            }
            set
            {
                this.machines = value;
            }
        }


        public void AddMachine(IMachine machine)
        {
            this.Machines.Add(machine);
            this.Machines = this.Machines.OrderBy(mach => mach.HealthPoints).ThenBy(mach => mach.Name).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} - ", this.Name);

            if (this.Machines.Count == 0 || this.Machines == null)
            {
                sb.Append("no machines");
            }
            else              
            {
                sb.AppendFormat("{0} {1}", this.Machines.Count, this.Machines.Count == 1 ? "machine" : "machines");
                sb.AppendLine();
                foreach (var machine in this.Machines)
                {
                    sb.Append(machine.ToString());
                }              
            }

            return sb.ToString();      
        }
    }
}
