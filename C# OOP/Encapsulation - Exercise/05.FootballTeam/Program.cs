namespace _05.FootballTeam
{
    public class Program
    {
        static void Main(string[] args)
        {


            string command;
            List<Team> teams = new List<Team>();
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] tokens = command.Split(";", StringSplitOptions.RemoveEmptyEntries);

                    string action = tokens[0];
                    string teamName = tokens[1];
                    if (action == "Team")
                    {
                        teams.Add(new Team(teamName));

                    }
                    else if (action == "Add")
                    {
                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);

                        Team? existingTeam = teams.FirstOrDefault(x => x.Name == teamName);
                        if (existingTeam == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        existingTeam.AddPlayer(player);
                    }
                    else if (action == "Remove")
                    {
                        string playerName = tokens[2];

                        Team existingTeam = teams.FirstOrDefault(x => x.Name == teamName);
                        Player existingPlayer = existingTeam.Players.FirstOrDefault(x => x.Name == playerName);
                        if (!existingTeam.RemovePlayer(existingPlayer))
                        {
                            throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
                        }

                    }

                    else if (action == "Rating")
                    {
                        Team existingTeam = teams.FirstOrDefault(x => x.Name == teamName);
                        if (existingTeam == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        Console.WriteLine(existingTeam);
                    }


                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }



        }
    }
}
