using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;
        public string Corps
        {
            get => corps;
            private set
            {
                if(value == "Airforces" || value == "Marines")
                {
                    corps = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public SpecialisedSoldier(string id, string firtName, string lastName, decimal salary, string corps) : base(id, firtName, lastName, salary)
        {
            Corps = corps;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());

            stringBuilder.AppendLine($"Corps: {Corps}");



            return stringBuilder.ToString().TrimEnd();
        }
    }
}
