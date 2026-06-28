namespace _03.Raiding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();
            while(heroes.Count<n)
            {
                try
                {
                    string name = Console.ReadLine();
                    string type = Console.ReadLine();

                    BaseHero baseHero = type switch
                    {
                        "Druid" => new Druid(name),
                        "Paladin" => new Paladin(name),
                        "Rogue" => new Rogue(name),
                        "Warrior" => new Warrior(name),
                        _ => throw new ArgumentException("Invalid hero!")
                    };

                    heroes.Add(baseHero);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            
            
            heroes.ForEach(x => Console.WriteLine(x.CastAbility()));
            int heroPower = heroes.Sum(x => x.Power);
            if (heroPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
