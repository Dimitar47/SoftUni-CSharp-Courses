using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine().Split(", ").ToList();
            string command = "";
            string patternName = @"[A-Za-z]";
            string patternDigits = @"\d";
            List<string> list = new List<string>();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            
            while((command = Console.ReadLine())!= "end of race")
            {
                MatchCollection matchesName = Regex.Matches(command, patternName);
                MatchCollection matchesDigits = Regex.Matches(command, patternDigits);
                string name = "";
                int digits = 0;
                foreach (Match match in matchesName)
                {
                    name += match.Value;
                }
                foreach(Match match in matchesDigits)
                {
                    digits += int.Parse(match.Value);
                }
                if (!dictionary.ContainsKey(name) && participants.Contains(name))
                {
                    dictionary.Add(name, digits);
                }
                else if(participants.Contains(name) && dictionary.ContainsKey(name))
                {
                    dictionary[name] += digits;
                }
            }
            int counter = 1;
            List<string> orderBy = dictionary.OrderByDescending(a => a.Value).Select(x=>x.Key).ToList();
            foreach(var order in orderBy)
            {
                if (counter == 1)
                    Console.WriteLine($"1st place: {order}");
                else if (counter == 2)
                    Console.WriteLine($"2nd place: {order}");
                else if (counter == 3)
                    Console.WriteLine($"3rd place: {order}");
                else 
                    break;
                counter++;
            }
        }
    }
}
