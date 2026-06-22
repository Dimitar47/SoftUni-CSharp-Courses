using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firtName, string lastName, decimal salary, string corps, List<IMission> missions) : base(id, firtName, lastName, salary, corps)
        {
            Missions = missions;

        }

        public List<IMission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine("Missions:");
            foreach(var mission in Missions)
            {
                stringBuilder.AppendLine($"  {mission}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
