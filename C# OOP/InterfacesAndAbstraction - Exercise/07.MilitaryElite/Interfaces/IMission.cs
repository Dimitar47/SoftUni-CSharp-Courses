using _07.MilitaryElite.Enums;

namespace _07.MilitaryElite.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}