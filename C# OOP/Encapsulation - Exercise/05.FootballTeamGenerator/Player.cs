using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private string name;
        public List<double> stats;
        public Player(string name) 
        {
            Name = name;
            stats = new List<double>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"A name should not be empty.");
                }
                name = value;
            }
        }
        public void AddStat(int currentStat,string name)
        {
            if(currentStat<0 || currentStat > 100)
            {
                name = char.ToUpper(name[0]) + name.Substring(1);
                throw new ArgumentException($"{name} should be between 0 and 100.");
            }
            stats.Add(currentStat);
        }
    }
}
