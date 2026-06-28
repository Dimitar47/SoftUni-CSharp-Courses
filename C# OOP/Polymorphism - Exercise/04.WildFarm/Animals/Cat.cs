using _04.WildFarm.Foods;

namespace _04.WildFarm.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string region, string breed)
            : base(name, weight, region, breed) { }

        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += 0.30 * food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
