using System;

using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTiles = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] greyTiles = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stackWhite = new Stack<int>(whiteTiles);
            Queue<int> queueGrey = new Queue<int>(greyTiles);
            Dictionary<int, string> tileAreas = new Dictionary<int, string>()
            {
                {40,"Sink" },
                {50,"Oven" },
                {60,"Countertop" },
                {70,"Wall" }
            };
            Dictionary<string, int> locations = new Dictionary<string, int>();
            while(queueGrey.Count > 0 && stackWhite.Count>0)
            {
                int currentWhite = stackWhite.Pop();
                int currentGrey = queueGrey.Dequeue();
                if(currentGrey == currentWhite)
                {
                    int newLargerTile = currentWhite + currentGrey;
                    if (tileAreas.ContainsKey(newLargerTile))
                    {
                        string currentLocation = tileAreas[newLargerTile];
                        if(!locations.ContainsKey(currentLocation))
                        {
                            locations.Add(currentLocation, 0);
                        }
                        locations[currentLocation]++;
                    }
                    else
                    {
                        string currentLocation = "Floor";
                        if(!locations.ContainsKey(currentLocation))
                        {
                            locations.Add(currentLocation, 0);
                        }
                        locations[currentLocation]++;
                    }
                }
                else
                {
                    currentWhite /= 2;
                    stackWhite.Push(currentWhite);
                    queueGrey.Enqueue(currentGrey);
                }
            }
            if(stackWhite.Count>0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ",stackWhite)}");
            }
            else
            {
                Console.WriteLine($"White tiles left: none");
            }
            if (queueGrey.Count > 0)
            {

                Console.WriteLine($"Grey tiles left: {string.Join(", ", queueGrey)}");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: none");
            }
            if (locations.Count > 0)
            {
                foreach (var curLocation in locations.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{curLocation.Key}: {curLocation.Value}");
                }
            }

        }
    }
}
