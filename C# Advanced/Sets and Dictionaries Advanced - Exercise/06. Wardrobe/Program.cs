using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> dictionary = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string color = info[0];
                
                string[] separatesClothes = info[1].Split(",",StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (!dictionary.ContainsKey(color))
                {
                    dictionary.Add(color,new Dictionary<string, int>());
                }
                for (int j = 0; j < separatesClothes.Length; j++)
                {
                    string currentCloth = separatesClothes[j];
                    if (!dictionary[color].ContainsKey(currentCloth))
                    {
                        dictionary[color].Add(currentCloth, 1);
                    }
                    else
                    {
                        dictionary[color][currentCloth]++;
                    }
                }
                
            }
            string[] lookingItem = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
            string lookingColor = lookingItem[0];
            string lookingClothing = lookingItem[1];

            foreach(var dict in dictionary)
            {
                Console.WriteLine($"{dict.Key} clothes:");
                foreach(var (cloth,num) in dict.Value)
                {
                    if (cloth == lookingClothing && dict.Key == lookingColor)
                    {
                        Console.WriteLine($"* {cloth} - {num} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth} - {num}");
                    }
                }
            }
        }
    }
}
