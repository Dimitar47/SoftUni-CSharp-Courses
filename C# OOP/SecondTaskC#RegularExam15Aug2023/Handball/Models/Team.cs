using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private int pointsEarned;
        private double overallRating;
        private List<IPlayer> players;
       

        public Team(string name)
        {
            Name = name;
            PointsEarned = 0;
            players = new List<IPlayer>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull); 
                }
                name = value;
            }
        }
        public int PointsEarned
        {
            get => pointsEarned;
            private set => pointsEarned = value;
        }
        public double OverallRating => Players.Any() ? Math.Round(Players.Average(player => player.Rating), 2) : 0;
        public IReadOnlyCollection<IPlayer> Players => players;

        public void SignContract(IPlayer player)
        {
            players.Add(player);
        }
        public void Win()
        {
            PointsEarned += 3;
           players.ForEach(x => x.IncreaseRating());
        }
        public void Draw()
        {
            PointsEarned += 1;
            
           IPlayer player = players.FirstOrDefault(x=>x.GetType() == typeof(Goalkeeper));
            if(player!=null)
            player.IncreaseRating();
        }

        public void Lose()
        {
            players.ForEach(x => x.DecreaseRating());
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            sb.Append("--Players: ");
            string sth = "";
            if (Players.Count > 0)
            {
                sth = string.Join(", ", Players.Select(x => x.Name));
                
            }
            else
            {
                sth = "none";
            }
            sb.AppendLine(sth);
            return sb.ToString().TrimEnd();
        }



    }
}
