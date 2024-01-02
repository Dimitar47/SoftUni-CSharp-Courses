using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public abstract class Bird : Animal
    {
        
      protected override string Name { get; set; }
        protected override double Weight {get; set; }
        protected override int FoodEaten { get; set; }
        protected double WingSize { get; set; }
        protected Bird(string name, double weight, double wingSize):base(name,weight)
        {
         
            
            WingSize = wingSize;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
