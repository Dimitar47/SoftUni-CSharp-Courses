using System.Xml.Serialization;

namespace _09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            List<Trainer> trainers = new List<Trainer>();
            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] info = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);
                if (trainers.Any(x => x.Name == trainerName))
                {
                    Trainer trainer = trainers.Where(x=>x.Name == trainerName).FirstOrDefault();
                    trainer.Pokemons.Add(new Pokemon
                    {
                        Name = pokemonName,
                        Element = pokemonElement,
                        Health = pokemonHealth
                    });
                }
                else
                {
                    Trainer trainer = new Trainer();

                    trainer.Name = trainerName;

                    trainer.Pokemons.Add(new Pokemon
                    {
                        Name = pokemonName,
                        Element = pokemonElement,
                        Health = pokemonHealth
                    });
                    trainers.Add(trainer);
                }
            }
            while((command = Console.ReadLine()) != "End")
            {
                for(int i = 0;i< trainers.Count;i++)
                {
                    Trainer trainer = trainers[i];
                    if (trainer.Pokemons.Any(x => x.Element == command))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(x => x.Health -= 10);
                        List<Pokemon> pokemons= trainer.Pokemons.Where(x=>x.Health<=0).ToList();
                        foreach(var pokemon in pokemons)
                        {
                            trainer.Pokemons.Remove(pokemon);
                        }
                    }
                }
            }
            foreach(var  trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");

            }
         
        }
    }
}