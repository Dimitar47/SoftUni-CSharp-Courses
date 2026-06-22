using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public decimal Salary { get; private set; }

        public Private(string id, string firtName, string lastName, decimal salary) : base(id, firtName, lastName)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(base.ToString());
            stringBuilder.AppendLine($" Salary: {Salary:f2}");


            return stringBuilder.ToString().TrimEnd();
        }

    }
}
