using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firtName, string lastName, decimal salary, string corps, List<IRepair> repairs) : base(id, firtName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public List<IRepair> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine($"Repairs:");

            foreach(var repair in Repairs)
            {
                stringBuilder.AppendLine($"  {repair}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }

   
}
