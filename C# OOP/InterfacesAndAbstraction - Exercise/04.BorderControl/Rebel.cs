using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl
{
    public class Rebel : IBuyer
    {
        public string Name { get;private set; }
        public int Age { get;private set; }
        public string Group { get; private set; }

        public int Food { get; private set; }

        public Rebel(string name,int age,string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public int BuyFood()
        {
            Food = 5;
            return Food;
        }
    }
}
