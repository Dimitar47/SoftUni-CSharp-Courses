using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string vloggerName = tokens[0];
                string command = tokens[1];

                if (command == "joined")
                {
                  

                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        vloggers.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                        vloggers[vloggerName].Add("followers", new HashSet<string>());
                        vloggers[vloggerName].Add("following", new HashSet<string>());
                    }
                }
                else if (command == "followed")
                {
               
                    string vloggerToFollow = tokens[2];

                    if (vloggers.ContainsKey(vloggerName) &&
                        vloggers.ContainsKey(vloggerToFollow) &&
                        vloggerName != vloggerToFollow)
                    {
                        vloggers[vloggerName]["following"].Add(vloggerToFollow);
                        vloggers[vloggerToFollow]["followers"].Add(vloggerName);
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int i = 1;
            var orderedVloggers = vloggers.OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(v => v.Value["following"].Count)
                .ToDictionary(x => x.Key, x => x.Value);

            List<string> mostFamousVloggerList = orderedVloggers.SelectMany(x => x.Value["followers"]).Take(2).ToList();

            foreach (var vlogger in orderedVloggers)
            {
                Console.WriteLine($"{i}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");


                if (i == 1)
                {
                    foreach (var following in vlogger.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {following}");
                    }
                }


                i++;
            }
        }
    }
}
