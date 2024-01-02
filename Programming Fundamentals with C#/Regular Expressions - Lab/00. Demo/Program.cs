using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _00._Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<day>[\d]{2})([\/\-.])(?<month>[A-Z][a-z]+)\1(?<year>[\d]{4})";
            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"].Value}, Month: {match.Groups["month"].Value}, Year: {match.Groups["year"].Value}");
            }


        }
    }
}
