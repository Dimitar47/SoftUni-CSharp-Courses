using System.Text;

namespace _05.FootballTeam
{
    public class Team
    {
        private string name;
    

        private List<Player> players;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"A name should not be empty.");
                }
                name = value;

            }
        }

        public IReadOnlyCollection<Player> Players => players.AsReadOnly();
        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public double Rating => Players.Count > 0 ?  (int)Math.Round(this.players.Average(x => x.Skill)) : 0;

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public bool RemovePlayer(Player player)
        {

            return players.Remove(player);


        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{Name} - {Rating}");

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
