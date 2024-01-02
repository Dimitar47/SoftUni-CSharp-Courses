using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;

            // dictPlayerNSkill - player.Key and (position,skill).Value

            var dictPlayerNSkill = new Dictionary<string, Dictionary<string, int>>();
            // dictTotalPlayer - player.Key and (total.Skill).Value
            var dictTotalPlayer = new Dictionary<string, int>();
        
            while ((command = Console.ReadLine()) != "Season end")
            {

               
                if (command.Contains("->"))
                {
                    string[] commandArray = command.Split(" -> ");
                    string player = commandArray[0];
                    string position = commandArray[1];
                    int skill = int.Parse(commandArray[2]);
                    
                    if (!dictPlayerNSkill.ContainsKey(player))
                    {
                        dictPlayerNSkill.Add(player, new Dictionary<string, int>());
                        dictPlayerNSkill[player].Add(position, skill);
                    }
                    else
                    {
                        if (!dictPlayerNSkill[player].ContainsKey(position))
                        {
                            dictPlayerNSkill[player][position] = skill;
                        }
                        else
                        {
                            if (dictPlayerNSkill[player][position] < skill)
                            {
                                dictPlayerNSkill[player][position] = skill;
                            }
                        }
                    }
                   
                }
                else if (command.Contains("vs"))
                {
                    string[] commandArray = command.Split(" vs ");
                    string player1 = commandArray[0];
                    string player2 = commandArray[1];
                    if (dictPlayerNSkill.ContainsKey(player1) && dictPlayerNSkill.ContainsKey(player2))
                    {
                        string playerToRemove = "";
                        foreach (var role in dictPlayerNSkill[player1])
                        {
                            foreach (var pos in dictPlayerNSkill[player2])
                            {
                                if (role.Key == pos.Key)
                                {
                                    if (dictPlayerNSkill[player1].Values.Sum() > dictPlayerNSkill[player2].Values.Sum())
                                        playerToRemove = player2;
                                    else if (dictPlayerNSkill[player1].Values.Sum() < dictPlayerNSkill[player2].Values.Sum())
                                        playerToRemove = player1;
                                }
                            }
                        }
                        dictPlayerNSkill.Remove(playerToRemove);
                    }
                }

            }
            foreach (var playerNSkill in dictPlayerNSkill)
            {
                foreach (var totalPlayer in playerNSkill.Value)
                {
                    if (!dictTotalPlayer.ContainsKey(playerNSkill.Key))
                    {
                        dictTotalPlayer.Add(playerNSkill.Key, totalPlayer.Value);
                    }
                    else
                    {
                        dictTotalPlayer[playerNSkill.Key] += totalPlayer.Value;
                    }
                }
            }
          
            foreach (var totalPlayer in dictTotalPlayer.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{totalPlayer.Key}: { totalPlayer.Value} skill");
                foreach (var playerNSkill in dictPlayerNSkill)
                {
                    if (playerNSkill.Key == totalPlayer.Key)
                    {
                        foreach (var name in playerNSkill.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                        {

                            Console.WriteLine($"- {name.Key} <::> {name.Value}");


                        }
                    }
                }

            }

        }
    }
  
}
