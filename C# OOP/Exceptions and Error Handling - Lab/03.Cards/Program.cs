using System.Text;

namespace _03.Cards
{
    public class Card
    {


        public string Face { get; private set; }
        public char Suit { get; private set; }

        public Card(string face, char suit)
        {
            Face = face;
            Suit = suit;
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"[{Face}{Suit}]");

            return stringBuilder.ToString().TrimEnd();
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            Dictionary<string, char> suits = new Dictionary<string, char>()
            {
                {"S",'\u2660' },
                {"H",'\u2665' },
                {"D",'\u2666' },
                {"C",'\u2663' },
            };

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new List<Card>();

            for (int i = 0; i < input.Length; i++)
            {
                try
                {

                    string[] pair = input[i].Split();
                    string face = pair[0];
                    string suit = pair[1];

                    if (faces.Contains(face) && suits.ContainsKey(suit))
                    {

                        Card card = new Card(face, suits[suit]);
                        cards.Add(card);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid card!");
                    }


                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }
    }
}
