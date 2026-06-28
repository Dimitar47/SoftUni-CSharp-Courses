using _04.WildFarm.Foods;

namespace _04.WildFarm.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize) { }

        public override void MakeSound()
        {
            Console.WriteLine("Cluck");
        }

        public override void Eat(Food food)
        {
            FoodEaten += food.Quantity;
            Weight += 0.35 * food.Quantity;
        }
    }
}
