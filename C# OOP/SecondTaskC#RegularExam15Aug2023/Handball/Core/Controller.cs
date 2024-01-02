using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<ITeam> teams;
        private IRepository<IPlayer> players;
        public Controller() 
        {
            teams = new TeamRepository();
            players = new PlayerRepository();
        
        }

        public string NewTeam(string name)
        {
            ITeam team = teams.GetModel(name);
            if(team != null)
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name,nameof(TeamRepository));
            }
            team = new Team(name);
            teams.AddModel(team);
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, nameof(TeamRepository));

            
        }
        public string NewPlayer(string typeName, string name)
        {
            if(typeName!= "CenterBack" && typeName!= "ForwardWing" && typeName != "Goalkeeper")
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }
            IPlayer player = players.GetModel(name);
            if(player != null)
            {
                return string.Format(OutputMessages.PlayerIsAlreadyAdded,name, nameof(PlayerRepository),
                    player.GetType().Name);
            }
            if(typeName == "CenterBack")
            {
                player = new CenterBack(name);
            }
            else if(typeName == "ForwardWing")
            {
                player = new ForwardWing(name);
            }
            else if(typeName == "Goalkeeper")
            {
                player = new Goalkeeper(name);
            }
            players.AddModel(player);
            return string.Format(OutputMessages.PlayerAddedSuccessfully,name);
        }
        public string NewContract(string playerName, string teamName)
        {
            if (!players.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, nameof(PlayerRepository));
            }
            if (!teams.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));
            }
            IPlayer player = players.GetModel(playerName);
            ITeam team = teams.GetModel(teamName);
            if(player.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName,
                    player.Team);
            }
            player.JoinTeam(teamName);
            team.SignContract(player);
            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }
        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);
            string winningTeamName = "";
            string losingTeamName = "";

            if(firstTeam.OverallRating > secondTeam.OverallRating)
            {
                winningTeamName = firstTeam.Name;
                losingTeamName = secondTeam.Name;
                firstTeam.Win();
                secondTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, winningTeamName, losingTeamName);
            }
            else if (secondTeam.OverallRating > firstTeam.OverallRating)
            {
                winningTeamName = secondTeam.Name;
                losingTeamName = firstTeam.Name;
                secondTeam.Win();
                firstTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, winningTeamName, losingTeamName);
            }
            else 
            {
                winningTeamName = firstTeam.Name;
                losingTeamName = secondTeam.Name;
                firstTeam.Draw();
                secondTeam.Draw();
                return string.Format(OutputMessages.GameIsDraw, winningTeamName, losingTeamName);
            }
        }
        public string PlayerStatistics(string teamName)
        {
            ITeam team = teams.GetModel(teamName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***{teamName}***");
            foreach(var player in team.Players.OrderByDescending(x=>x.Rating).ThenBy(x=>x.Name))
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
        public string LeagueStandings()
        {
            List<ITeam> arranged =  teams.Models.OrderByDescending(x=>x.PointsEarned)
                .ThenByDescending(x=>x.OverallRating)
                .ThenBy(x=>x.Name).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***League Standings***");
            foreach(var team in arranged)
            {
                sb.AppendLine(team.ToString());
            }
            return sb.ToString().TrimEnd();
        }

      
    }
}
