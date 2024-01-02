using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {


            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            string legendaryItem = "";
            bool isComplete = false;
          
            while (!isComplete)
            {

                string[] commandArray = Console.ReadLine().Split();
                List<int> quantities = new List<int>();
                List<string> materials = new List<string>();
                for (int i = 0; i < commandArray.Length; i++)
                {
                    if (i % 2 == 0) quantities.Add(int.Parse(commandArray[i]));
                    else materials.Add(commandArray[i].ToLower());
                }
                for (int i = 0; i < materials.Count; i++)
                {
                    if (!dictionary.ContainsKey(materials[i]))
                        dictionary.Add(materials[i], quantities[i]);
                    else dictionary[materials[i]] += quantities[i];

                    if (materials[i] == "shards")
                    {
                        if (dictionary["shards"] >= 250)
                        {

                            legendaryItem = "Shadowmourne";
                            Console.WriteLine($"{legendaryItem} obtained!");
                            dictionary["shards"] -= 250;
                            isComplete = true;
                            break;
                        }
                    }
                    else if (materials[i] =="fragments")
                    {

                        if (dictionary["fragments"] >= 250)
                        {
                            legendaryItem = "Valanyr";
                            Console.WriteLine($"{legendaryItem} obtained!");
                            dictionary["fragments"] -= 250;
                            isComplete = true;
                            break;
                        }
                    }
                    else if (materials[i] == "motes")
                    {
                        if (dictionary["motes"] >= 250)
                        {
                            legendaryItem = "Dragonwrath";
                            Console.WriteLine($"{legendaryItem} obtained!");
                            dictionary["motes"] -= 250;
                            isComplete = true;
                            break;
                        }
                    }
                    else
                    {

                    }

                }

            }

            foreach (KeyValuePair<string, int> pair in dictionary)
                if (pair.Key == "motes" || pair.Key == "fragments" || pair.Key == "shards")
                    Console.WriteLine($"{pair.Key}: {pair.Value}");

            foreach (KeyValuePair<string, int> pair in dictionary)
                if (!(pair.Key == "motes" || pair.Key == "fragments" || pair.Key == "shards"))
                    Console.WriteLine($"{pair.Key}: {pair.Value}");

            //.OrderByDescending(x => x.Value).ThenBy(x => x.Key)

        }

    }
}



