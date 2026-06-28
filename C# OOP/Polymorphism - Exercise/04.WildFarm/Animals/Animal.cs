using _04.WildFarm.Foods;

namespace _04.WildFarm.Animals
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public abstract void MakeSound();
        public abstract void Eat(Food food);
    }

}
