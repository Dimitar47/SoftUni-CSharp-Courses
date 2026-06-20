

namespace _05.FootballTeam
{
    public class Player
    {


        private string name;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"A name should not be empty.");
                }
                name = value;

            }
        }
        public int Endurance
        {
            get => endurance;
            private set
            {
                if (value >= 0 && value <= 100)
                {
                    endurance = value;

                }
                else
                {
                    throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");
                }
            }
        }
        public int Sprint
        {
            get => sprint;
            private set
            {
                if (value >= 0 && value <= 100)
                {
                    sprint = value;

                }
                else
                {
                    throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");
                }
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {
                if (value >= 0 && value <= 100)
                {
                    dribble = value;

                }
                else
                {
                    throw new ArgumentException($"{nameof(Dribble)} should be between 0 and 100.");
                }
            }
        }
        public int Passing
        {
            get => passing;
            private set
            {
                if (value >= 0 && value <= 100)
                {
                    passing = value;

                }
                else
                {
                    throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
                }
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                if (value >= 0 && value <= 100)
                {
                    shooting = value;

                }
                else
                {
                    throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
                }
            }
        }


        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }


        public double Skill => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
    }
}
