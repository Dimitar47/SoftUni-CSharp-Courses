using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firtName, string lastName, int codeNumber) : base(id, firtName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{base.ToString()}");
            stringBuilder.AppendLine($"Code Number: {CodeNumber}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
