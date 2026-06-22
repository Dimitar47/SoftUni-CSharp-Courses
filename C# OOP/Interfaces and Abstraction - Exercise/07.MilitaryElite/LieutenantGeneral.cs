using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firtName, string lastName, decimal salary, List<IPrivate> privates) : base(id, firtName, lastName, salary)
        {
            Privates = privates;
        }

        public List<IPrivate> Privates { get; private set; }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine("Privates:");

            foreach(var pr in Privates)
            {
                stringBuilder.AppendLine($"  {pr}");
            }



            return stringBuilder.ToString().TrimEnd();
        }
    }
}
