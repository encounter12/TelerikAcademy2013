using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildingSystem.Components
{
    internal abstract class Battery
    {
        public int PowerLeftInPercentage{ get; set;};

        public void Charge(int chargingPower)
        {
        }
    }
}
