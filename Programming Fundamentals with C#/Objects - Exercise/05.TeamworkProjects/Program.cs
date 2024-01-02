using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{

    class Program
    {

        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());
            List<Teams> teams = new List<Teams>();
            for (int i = 0; i < countOfTeams; i++)
            {
                string[] data = Console.ReadLine().Split("-");
                string user = data[0];
                string teamName = data[1];
                Teams teamObj = new Teams
                {
                    TeamName = teamName,
                    User = user
                };
                if (teams.Any(x => x.User == user))
                {
                    Console.WriteLine($"{user} cannot create another team!");
                    continue;
                }
                if (teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                Console.WriteLine($"Team {teamName} has been created by {user}!");
                teams.Add(teamObj);
            }
            string command = "";
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] commandArray = command.Split("->");
                string user = commandArray[0];
                string teamToJoin = commandArray[1];
                if (!teams.Any(x => x.TeamName == teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                    continue;
                }
                if (teams.Any(x => x.User == user) || teams.Any(x => x.Members.Contains(user)))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamToJoin}!");
                    continue;
                }
                if (teams.Any(x => x.TeamName == teamToJoin))
                {
                    if (!teams.Any(x => x.Members.Contains(user)))
                    {
                        var existingTeam = teams.First(x => x.TeamName == teamToJoin);
                        existingTeam.Members.Add(user);
                    }
                }
            }
            foreach (var team in teams.Where(x => x.Members.Count != 0).OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName))
            {
                Console.WriteLine(team.TeamName);
                Console.WriteLine($"- {team.User}");
                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");
            var teamsToDisband = teams.Where(x => x.Members.Count == 0).Select(x => x.TeamName).ToList();
            foreach (var teamDisb in teamsToDisband.OrderBy(x => x))
            {
                Console.WriteLine(teamDisb);
            }
        }

    }
    class Teams
    {
        public List<string> Members { get; set; } = new List<string>();
        public string TeamName { get; set; }
        public string User { get; set; }
    }

}