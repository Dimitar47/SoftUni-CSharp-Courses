using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        protected override double WeightGain => 0.35;

        public override void Eat(Food food)
        {
            this.Weight += WeightGain * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string Sound()
        {
            return "Cluck";
        }
    }
}
