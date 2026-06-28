using System.Text;
using _04.WildFarm.Foods;

namespace _04.WildFarm.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string region)
            : base(name, weight, region) { }

        public override void MakeSound()
        {
            Console.WriteLine("Squeak");
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                FoodEaten += food.Quantity;
                Weight += 0.10 * food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
