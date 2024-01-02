using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder stringBuilderOuter = new StringBuilder();
            string pattern = @"@(?<name>[A-Za-z]+)[^@:!\->]*:(?<population>\d+)[^@:!\->]*!(?<type>A|D)![^@:!\->]*->(?<soldierCount>\d+)";
            string starPattern = @"[STARstar]";
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            for (int i = 0; i < n; i++)
            {

                string encryptedMessage = Console.ReadLine();
      
                StringBuilder stringBuilderInner = new StringBuilder();
                MatchCollection matches = Regex.Matches(encryptedMessage, starPattern);
                int count = matches.Count;
                for (int j = 0; j < encryptedMessage.Length; j++)
                {
                    stringBuilderInner.Append((char)(encryptedMessage[j]-count));
                }

                Match match1 = Regex.Match(stringBuilderInner.ToString(), pattern);

                if(match1.Success && match1.Groups["type"].Value == "A")
                {
                    attackedPlanets.Add(match1.Groups["name"].Value);
                }
                else if (match1.Success && match1.Groups["type"].Value == "D")
                {
                    destroyedPlanets.Add(match1.Groups["name"].Value);
                }
              
            }
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            if (attackedPlanets.Count != 0)
            {
                foreach (var attacked in attackedPlanets.OrderBy(x=> x))
                {
                    Console.WriteLine($"-> {attacked}");
                }
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            if (destroyedPlanets.Count != 0)
            {
                foreach (var destroyed in destroyedPlanets.OrderBy(x=>x))
                {
                    Console.WriteLine($"-> {destroyed}");
                }
            }

        }
    }
}
