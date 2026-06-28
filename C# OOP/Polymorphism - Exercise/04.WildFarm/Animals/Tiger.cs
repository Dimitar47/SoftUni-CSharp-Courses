using _04.WildFarm.Foods;

namespace _04.WildFarm.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string region, string breed)
            : base(name, weight, region, breed) { }

        public override void MakeSound()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
