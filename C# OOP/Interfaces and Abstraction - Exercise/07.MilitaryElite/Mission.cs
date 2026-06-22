using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class Mission : IMission
    {
        
        public string CodeName { get; private set; }

        public string State { get; private set; }

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            if(state == "InProgress" || state == "Finished")
            {
                State = state;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void CompleteMission()
        {
            State = "Finished";
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Code Name: {CodeName} State: {State}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
