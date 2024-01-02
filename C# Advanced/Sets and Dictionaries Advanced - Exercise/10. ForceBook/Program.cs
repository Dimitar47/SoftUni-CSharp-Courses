using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            Dictionary<string, List<string>> sidesUsers = new Dictionary<string, List<string>>();
            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] info = command.Split(new string[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command.Contains("|"))
                {
                    string side = info[0];
                    string user = info[1];
                    if (!sidesUsers.Values.Any(u => u.Contains(user)))
                    {
                        if (!sidesUsers.ContainsKey(side))
                        {
                            sidesUsers.Add(side, new List<string>());
                        }

                        sidesUsers[side].Add(user);
                    }

                }
                else
                {
                    string user = info[0];
                    string side = info[1];
                    if (!sidesUsers.ContainsKey(side))
                    {
                        sidesUsers.Add(side, new List<string>());
                    }

                    foreach (var sideUsers in sidesUsers)
                    {
                        if (sideUsers.Value.Contains(user))
                        {
                            sideUsers.Value.Remove(user);
                            break;
                        }
                    }
                    sidesUsers[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");

                }
            }
            foreach (var sideList in sidesUsers.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (sideList.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {sideList.Key}, Members: {sideList.Value.Count}");
                    foreach (var name in sideList.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {name}");
                    }
                }
            }

        }
    }
}
