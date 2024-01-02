using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding
{
    public abstract class BaseHero
    {
        public abstract string Name { get; set; }
        public abstract int Power { get; set; }

        public abstract string CastAbility();
    }
}
