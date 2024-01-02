using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
               string pattern = @"(\+359([ -])2(\2)(\d{3})(\2)(\d{4}))\b"; //\+359 2 \d{3} \d{4}\b|\+359-2-\d{3}-\d{4}\b
            MatchCollection matches = Regex.Matches(text, pattern);
            string[] filteredMatches = matches.Cast<Match>().Select(a => a.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ", filteredMatches));
        }
    }
}
