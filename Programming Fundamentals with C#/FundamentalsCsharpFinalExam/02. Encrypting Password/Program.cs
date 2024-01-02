using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Encrypting_Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"(?<sym>.+)>(?<numbers>\d{3})\|(?<lower>[a-z]{3})\|(?<upper>[A-Z]{3})\|(?<all>[^><]{3})<\1";
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                MatchCollection matches = Regex.Matches(text, pattern);
                 StringBuilder stringBuilder = new StringBuilder();
                if (matches.Count > 0)
                {

                    foreach(Match match in matches)
                    {
                        stringBuilder.Append(match.Groups["numbers"].Value);
                        stringBuilder.Append(match.Groups["lower"].Value);
                        stringBuilder.Append(match.Groups["upper"].Value);
                        stringBuilder.Append(match.Groups["all"].Value);
                        break;
                       

                    }
                    Console.WriteLine($"Password: {stringBuilder.ToString()}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
