using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            Dictionary<string,string> contestPassword = new Dictionary<string,string>();
            Dictionary<string, Dictionary<string, int>> userContestPoints = new Dictionary<string, Dictionary<string, int>>();
            while((command = Console.ReadLine())!="end of contests")
            {
                //"{contest}:{password for contest}"

                string[] input = command.Split(":");
                string contest = input[0];
                string password = input[1];
                if (!contestPassword.ContainsKey(contest))
                {
                    contestPassword.Add(contest, password);
                   
                }

            }
            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] input = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = input[0];
                string password = input[1];
                string userName = input[2];
                int points = int.Parse(input[3]);
                if (contestPassword.ContainsKey(contest) && contestPassword[contest] == password)
                {
                    if (!userContestPoints.ContainsKey(userName))
                    {
                        userContestPoints.Add(userName, new Dictionary<string, int>());


                    }
                    if (!userContestPoints[userName].ContainsKey(contest))
                    {
                        userContestPoints[userName].Add(contest, 0);
                    }




                    if (points > userContestPoints[userName][contest])
                    {

                        userContestPoints[userName][contest] = points;
                    }
                }
            }
            

            var bestUser = userContestPoints.OrderByDescending(x => x.Value.Values.Sum()).First().Key;
            var bestPoints = userContestPoints[bestUser].Values.Sum();
            Console.WriteLine($"Best candidate is {bestUser} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach(var userSecondDict in userContestPoints.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{userSecondDict.Key}");
                foreach(var (contest,points) in userSecondDict.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}
