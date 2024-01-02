using System;
using System.Collections.Generic;
using System.Linq;

namespace _00.Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var data = new Dictionary<string, SortedDictionary<string, int[]>>();
            

            for (int i = 0; i < n; i++)
            {
                string[] commandArray = Console.ReadLine().Split();
                string type = commandArray[0];
                string name = commandArray[1];
                string damage = commandArray[2];
                string health = commandArray[3];
                string armor = commandArray[4];
                int validDamage = 0;
                int validHealth = 0;
                int validArmor = 0;
                if(damage == "null")
                {
                    damage = "45";
                }
                if(health == "null")
                {
                    health = "250";

                }
                if(armor == "null")
                {
                    armor = "10";
                }
                if(int.TryParse(damage,out int dam))
                {
                    validDamage = int.Parse(damage);
                }
                if(int.TryParse(health,out int hp))
                {
                    validHealth = int.Parse(health);
                }
                if(int.TryParse(armor,out int arm))
                {
                    validArmor = int.Parse(armor);
                }
                if (!data.ContainsKey(type))
                {
                    data.Add(type, new SortedDictionary<string, int[]>());
                }
                if (!data[type].ContainsKey(name))
                {
                    data[type][name] = new int[3];
                }
                if(data.ContainsKey(type) && data[type].ContainsKey(name))
                {
                    data[type][name][0] = validDamage;
                    data[type][name][1] = validHealth;
                    data[type][name][2] = validArmor;
                }

            }
            foreach(var outerKvp in data)
            {
                Console.WriteLine($"{outerKvp.Key}::({outerKvp.Value.Select(x=>x.Value[0]).Average():f2}/{outerKvp.Value.Select(x=>x.Value[1]).Average():f2}/{outerKvp.Value.Select(x=>x.Value[2]).Average():f2})");
                foreach(var innerKvp in outerKvp.Value)
                {
                    Console.WriteLine($"-{innerKvp.Key} -> damage: {innerKvp.Value[0]}, health: {innerKvp.Value[1]}, armor: {innerKvp.Value[2]}");
                }
            }
        }
    }
}
