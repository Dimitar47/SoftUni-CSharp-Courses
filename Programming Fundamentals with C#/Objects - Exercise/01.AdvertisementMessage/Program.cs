using System;
using System.Collections.Generic;

namespace _01.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Random random = new Random();
            List<string> phrases = new List<string>
            {
                "Excellent product.", "Such a great product.", "I always use that product.",
                "Best product of its category.", "Exceptional product.", "I can’t live without this product."
            };
            List<string> events = new List<string>
            {
                "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };
            List<string> authors = new List<string>{"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
            List<string> cities = new List<string> { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
            for (int i = 0; i < n; i++)
            {
                int rndPhrase = random.Next(0, phrases.Count);
                int rndEvent = random.Next(0, events.Count);
                int rndAuthor = random.Next(0, authors.Count);
                int rndCity = random.Next(0,cities.Count);
                Console.WriteLine($"{phrases[rndPhrase]} {events[rndEvent]} {authors[rndAuthor]} – {cities[rndCity]}.");
            }
        }
    }
}
