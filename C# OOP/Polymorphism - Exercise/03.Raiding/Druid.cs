using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding
{
    public class Druid : BaseHero
    {
        public override string Name { get; set; }
        public override int Power { get; set; }

        public Druid(string name)
        {
            Name = name;
            Power = 80;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
                    
        }
    }
}
