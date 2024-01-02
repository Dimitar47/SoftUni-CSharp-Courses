using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override string LivingRegion { get; set; }
        protected override string Name { get; set; }
        protected override double Weight { get; set; }
        protected override int FoodEaten { get; set; }

        protected override double WeightGain => 0.40;

        public override void Eat(Food food)
        {
            if ( food.GetType().Name == "Meat")
            {
                this.Weight += this.WeightGain * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string Sound()
        {
            return "Woof!";
        }
    }
}
