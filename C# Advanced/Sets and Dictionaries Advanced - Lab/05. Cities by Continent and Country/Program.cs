using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> dictionary =
                new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ",
                    StringSplitOptions.RemoveEmptyEntries).ToArray();
                string continent = info[0];
                string country = info[1];
                string city = info[2];
                if (!dictionary.ContainsKey(continent))
                {
                    dictionary.Add(continent,
                        new Dictionary<string, List<string>>());
                }
                if (!dictionary[continent].ContainsKey(country))
                {
                    dictionary[continent].Add(country, new List<string>());
                }
                dictionary[continent][country].Add(city);
            }
            foreach(var continents in dictionary)
            {
                Console.WriteLine($"{continents.Key}:");
                foreach(var (countries,cities) in continents.Value)
                {
                    Console.WriteLine($"  {countries} -> {string.Join(", ",cities)}");
                }
            }
        }
    }
}
