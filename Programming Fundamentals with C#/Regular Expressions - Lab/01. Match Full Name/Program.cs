using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"\b([A-Z][a-z]+) ([A-Z][a-z]+)\b";
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach(Match match in matches)
            {
                Console.Write($"{match.Value} ");
            }
            Console.WriteLine();
        }
    }
}
