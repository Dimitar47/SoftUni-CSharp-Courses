using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class Soldier : ISoldier
    {
        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }


        public Soldier(string id, string firtName, string lastName)
        {
            Id = id;
            FirstName = firtName;
            LastName = lastName;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();


            stringBuilder.AppendLine($"Name: {FirstName} {LastName} Id: {Id}");
            return stringBuilder.ToString().TrimEnd();

        }
    }
}
