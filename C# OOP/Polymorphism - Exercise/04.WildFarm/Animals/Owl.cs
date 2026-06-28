using _04.WildFarm.Foods;

namespace _04.WildFarm.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize) { }

        public override void MakeSound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += 0.25 * food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
