using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding
{
    public class Warrior :BaseHero
    {
        public override string Name { get; set; }
        public override int Power { get; set; }

        public Warrior(string name)
        {
            Name = name;
            Power = 100;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";

        }


    }
}
