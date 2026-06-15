namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            



        }
    }
    public class RandomList : List<string>
    {
        private static Random random = new Random();

        public string RandomString()
        {
            int randIndex = random.Next(0, this.Count);

            string randStr = this[randIndex];

            this.RemoveAt(randIndex);

            return randStr;
        }

    }
}
