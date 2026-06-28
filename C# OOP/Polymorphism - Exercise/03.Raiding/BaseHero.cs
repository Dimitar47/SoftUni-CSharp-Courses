namespace _03.Raiding
{
    public abstract class BaseHero
    {

        public string Name { get; protected set; }
        public int Power { get; protected set; }
        public abstract string CastAbility();

        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }
    }
}
