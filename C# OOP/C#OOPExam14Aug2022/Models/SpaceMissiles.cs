using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models
{
    public class SpaceMissiles : Weapon
    {
        private const double SpaceMissilesPrice = 8.75;
        public SpaceMissiles(int destructionLevel) : base(destructionLevel, SpaceMissilesPrice)
        {
        }
    }
}
