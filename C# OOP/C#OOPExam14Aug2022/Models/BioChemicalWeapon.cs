using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models
{
    public class BioChemicalWeapon : Weapon
    {
        private const double BioChemicalWeaponPrice = 3.2;
        public BioChemicalWeapon(int destructionLevel) : base(destructionLevel, BioChemicalWeaponPrice)
        {
        }
    }
}
