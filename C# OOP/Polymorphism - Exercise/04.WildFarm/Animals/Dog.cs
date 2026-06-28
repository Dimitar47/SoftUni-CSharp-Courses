using System.Text;
using _04.WildFarm.Foods;

namespace _04.WildFarm.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string region)
            : base(name, weight, region) { }

        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += 0.40 * food.Quantity;
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
