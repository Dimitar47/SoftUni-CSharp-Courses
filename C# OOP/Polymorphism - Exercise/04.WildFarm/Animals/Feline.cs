using System.Text;

namespace _04.WildFarm.Animals
{
    public abstract class Feline : Mammal
    {
        public string Breed { get; set; }

        protected Feline(string name, double weight, string region, string breed)
            : base(name, weight, region)
        {
            Breed = breed;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
