using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        public string Name { get; private set; }


        public Team(string name)
        {
            Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }
        public IReadOnlyCollection<Person> FirstTeam => firstTeam.AsReadOnly();
        public IReadOnlyCollection<Person> ReserveTeam => reserveTeam.AsReadOnly();

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"First team has {firstTeam.Count} players.");
            stringBuilder.AppendLine($"Reserve team has {reserveTeam.Count} players.");
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
