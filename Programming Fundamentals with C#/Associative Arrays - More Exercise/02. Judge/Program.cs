using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            //contest.Key and (username and points).Value
            var contests = new Dictionary<string, Dictionary<string, int>>();
            //username.Key and total sum of points.Value
            var names = new Dictionary<string, int>();


            while ((command = Console.ReadLine()) != "no more time")
            {
                string[] commandArray = command.Split(" -> ");
                string username = commandArray[0];
                string contest = commandArray[1];
                int points = int.Parse(commandArray[2]);


                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, new Dictionary<string, int>());
                    contests[contest].Add(username, points);
                }
                else
                {
                    if (!contests[contest].ContainsKey(username))
                    {
                        contests[contest][username] = points;

                    }
                    else
                    {
                        if (contests[contest][username] < points)
                        {
                            contests[contest][username] = points;
                        }
                    }
                }


            }

            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                int count = 1;
                foreach (var name in contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{count}. {name.Key} <::> {name.Value}");
                    count++;
                }

            }
            Console.WriteLine($"Individual standings:");
            foreach (var contest in contests)
            {
                foreach (var name in contest.Value)
                {
                    if (!names.ContainsKey(name.Key))
                    {
                        names.Add(name.Key, name.Value);
                    }
                    else
                    {
                        names[name.Key] += name.Value;
                    }

                }
            }
            int counter = 1;
            foreach (var user in names.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {

                Console.WriteLine($"{counter}. {user.Key} -> {user.Value}");

                counter++;
            }
        }
    }
}

