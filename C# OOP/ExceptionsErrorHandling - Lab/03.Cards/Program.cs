namespace _03.Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new List<Card>();
            for (int i = 0; i < input.Length; i++)
            {
                string[] currentCard = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Card card = new Card(currentCard[0], currentCard[1]);
                    cards.Add(card);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(string.Join(" ", cards));
            
        }
    }
    public class Card
    {
        private string face;
        private string suit;
        private string[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J",
            "Q", "K", "A" };
        private string[] suits = { "S", "H", "D", "C" };
        private Dictionary<string, string> keyValuePairs =
        new Dictionary<string, string>()
        {

            {"S","\u2660" },
            {"H","\u2665" },
            {"D","\u2666" },
            {"C","\u2663" }
        };

           

        public Card(string face,string suit)
        {
            Face = face;
            Suit = suit;
        }
        public string Face
        {
            get
            {
                return face;
            }
            private set
            {
                if (!faces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value;


            }
        }
        public string Suit 
        {
            get
            {
                return suit;
            }
            private set
            {
                if (!keyValuePairs.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                suit = keyValuePairs[value];
            }
        
        }
      

        
        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }
    

}