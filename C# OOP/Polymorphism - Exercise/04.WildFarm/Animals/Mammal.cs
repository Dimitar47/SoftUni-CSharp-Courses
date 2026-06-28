namespace _04.WildFarm.Animals
{

    public abstract class Mammal : Animal
    {
        public string LivingRegion { get; set; }

        protected Mammal(string name, double weight, string region)
            : base(name, weight)
        {
            LivingRegion = region;
        }
    }
}
