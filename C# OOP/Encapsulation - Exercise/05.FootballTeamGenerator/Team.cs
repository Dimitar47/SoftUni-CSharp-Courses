using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private readonly List<Player> players;
        private string name;
     
        public Team(string name)
        {
            players = new List<Player>();
            Name = name;



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

        public double Rating
        {
            get
            {
                if (players.Count > 0)
                {
                    List<double> currentPlayerStats = players.SelectMany(x => x.stats).ToList();

                    return currentPlayerStats.Average(x=>x);
                }
                return 0;
            }
        }


        public void AddPlayer(Player player)
        {

            players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
           
            Player player = players.FirstOrDefault(p => p.Name == playerName);

            if (player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            }

            players.Remove(player);

        }


        /*private string name;
        private readonly List<Player> players;
        private double rating;
        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public double Rating
        {
            get
            {
                if (players.Any())
                {
                    List<double> doubles = players.SelectMany(x => x.stats).ToList();
                    return doubles.Average(x => x);
                }

                return 0;
            }
        }

        public void AddPlayer(Player player) => players.Add(player);

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);

            if (player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            }

            players.Remove(player);
        }
        */


    }
}
