using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class Repair : IRepair
    {
        public string PartName { get; private set; }

        public int HoursWorked { get; private set; }

        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Part Name: {PartName} Hours Worked: {HoursWorked}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
