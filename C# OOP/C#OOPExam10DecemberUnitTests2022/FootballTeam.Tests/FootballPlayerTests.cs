using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class Tests
    {

        /*
         private string name;
        private int playerNumber;
        private string position;
        private int scoredGoals;

        public FootballPlayer(string name, int playerNumber, string position)
        {
            Name = name;
            PlayerNumber = playerNumber;
            Position = position;
            this.scoredGoals = 0;
        }
         
       public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }
                name = value;
            }
        }

        public int PlayerNumber
        {
            get => playerNumber;
            private set
            {
                if (value < 1 || value > 21)
                {
                    throw new ArgumentException("Player number must be in range [1,21]");
                }
                playerNumber = value;
            }
        }

        public string Position
        {
            get => position;
            private set
            {
                if (value != "Goalkeeper" && value != "Midfielder" && value != "Forward")
                {
                    throw new ArgumentException("Invalid Position");
                }
                position = value;
            }
        }
         public int ScoredGoals => scoredGoals;

        public void Score()
        {
            this.scoredGoals++;
        }
        */
        [Test]
        public void Test_FootballPlayerConstructor()
        {
            FootballPlayer validPlayer = new FootballPlayer("Ronaldo", 7, "Forward");
            Assert.IsNotNull(validPlayer);
            Assert.AreEqual(validPlayer.Name, "Ronaldo");
            Assert.AreEqual(validPlayer.PlayerNumber, 7);
            Assert.AreEqual(validPlayer.Position, "Forward");
            Assert.AreEqual(validPlayer.ScoredGoals, 0);

            validPlayer.Score();
            Assert.AreEqual(validPlayer.ScoredGoals, 1);

            //Name
            Assert.That(() => new FootballPlayer(null, 10, "Forward"), Throws.ArgumentException);
            Assert.That(() => new FootballPlayer("", 10, "Forward"), Throws.ArgumentException);

            //Number
            Assert.That(() => new FootballPlayer("", 0, "Forward"), Throws.ArgumentException);
            Assert.That(() => new FootballPlayer("", -1, "Forward"), Throws.ArgumentException);
            Assert.That(() => new FootballPlayer("", 22, "Forward"), Throws.ArgumentException);
            Assert.That(() => new FootballPlayer("", 100, "Forward"), Throws.ArgumentException);

            Assert.That(() => new FootballPlayer("Messi", 10, "Forward"), Throws.Nothing);
            Assert.That(() => new FootballPlayer("Messi", 10, "Midfielder"), Throws.Nothing);
            Assert.That(() => new FootballPlayer("Messi", 10, "Goalkeeper"), Throws.Nothing);

            Assert.That(() => new FootballPlayer("Messi", 10, ""), Throws.ArgumentException);
            Assert.That(() => new FootballPlayer("Messi", 10, " "), Throws.ArgumentException);
            Assert.That(() => new FootballPlayer("Messi", 10, "zdr"), Throws.ArgumentException);




            //Assert.That(()=>new FootballPlayer(" ", 10, "Forward"), Throws.ArgumentException);
        }
    }
}