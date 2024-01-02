using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
namespace _00.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string emailPattern = @"(^|\s)[A-Za-z0-9][\w*\-._]*[A-Za-z0-9]@[A-Za-z]+([.-][A-Za-z]+)+\b";
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, emailPattern);
            foreach(Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }

    }
}
