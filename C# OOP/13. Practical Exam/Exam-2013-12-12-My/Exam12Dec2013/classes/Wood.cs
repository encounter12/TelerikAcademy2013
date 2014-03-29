using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class Wood : Item
    {
        private int woodValue;

        public Wood(string name, Location location) : base(name, 2 , ItemType.Wood, location)
        {
        }

        public int WoodValue
        {
            get
            {
                return this.woodValue;
            }
            set
            {
                this.woodValue = value;
            }
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop" && this.WoodValue > 0)
            {
                this.WoodValue -= 1;
            }
        }
    }
}
