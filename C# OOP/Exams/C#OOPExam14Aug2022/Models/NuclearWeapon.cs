using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models
{
    public class NuclearWeapon : Weapon
    {
        private const double NuclearWeaponPrice = 15;
        public NuclearWeapon(int destructionLevel) : base(destructionLevel, NuclearWeaponPrice)
        {
        }
    }
}
