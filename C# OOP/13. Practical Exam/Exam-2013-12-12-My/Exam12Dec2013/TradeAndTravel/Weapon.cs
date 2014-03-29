using System;
using System.Linq;

namespace TradeAndTravel
{
    class Weapon : Item
    {
        const int GeneralWeaponValue = 10;

        public Weapon(string name, Location location) : base(name, Weapon.GeneralWeaponValue, ItemType.Weapon, location)
        {
        }
    }
}