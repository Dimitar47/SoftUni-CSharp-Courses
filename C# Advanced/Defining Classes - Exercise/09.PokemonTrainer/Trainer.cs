using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PokemonTrainer
{
    public class Trainer
    {

        private string name;
        private List<Pokemon> pokemons;
        private int numOfBadges=0;
        public Trainer()
        {
            pokemons = new List<Pokemon>();
        }
        public string Name { get { return name; } set { name = value; } }
        public int NumberOfBadges { get {  return numOfBadges; } set {  numOfBadges = value; } }
        public List<Pokemon> Pokemons { get { return pokemons; } set {  pokemons = value; } }

    }
}
