using System;

using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] steel = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] carbon = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> steelQueue = new Queue<int>(steel);
            Stack<int> carbonStack = new Stack<int>(carbon);
            
            int totalSwordsForged = 0;
            Dictionary<string, int> forging = new Dictionary<string, int>();
            while(steelQueue.Count > 0 && carbonStack.Count>0)
            {
                int currSteel = steelQueue.Dequeue();
                int currCarbon = carbonStack.Pop();

                int sum = currSteel + currCarbon;
                string currentSword = "";
                if(sum==70)
                {
                    currentSword = "Gladius";
                    if(!forging.ContainsKey(currentSword))
                    {
                        forging.Add(currentSword, 0);
                    }
                    totalSwordsForged++;
                    forging[currentSword]++;
                }
                else if(sum == 80)
                {
                    currentSword = "Shamshir";
                    if (!forging.ContainsKey(currentSword))
                    {
                        forging.Add(currentSword, 0);
                    }
                    totalSwordsForged++;
                    forging[currentSword]++;
                }
                else if (sum == 90)
                {
                    currentSword = "Katana";
                    if (!forging.ContainsKey(currentSword))
                    {
                        forging.Add(currentSword, 0);
                    }
                    totalSwordsForged++;
                    forging[currentSword]++;
                }
                else if(sum == 110)
                {
                    currentSword = "Sabre";
                    if (!forging.ContainsKey(currentSword))
                    {
                        forging.Add(currentSword, 0);
                    }
                    totalSwordsForged++;
                    forging[currentSword]++;
                }
                else if (sum == 150)
                {
                    currentSword = "Broadsword";
                    if (!forging.ContainsKey(currentSword))
                    {
                        forging.Add(currentSword, 0);
                    }
                    totalSwordsForged++;
                    forging[currentSword]++;
                }
                else
                {
                
                    currCarbon += 5;
                    carbonStack.Push(currCarbon);

                }

            }
            
            if (totalSwordsForged > 0)
            {
                Console.WriteLine($"You have forged {forging.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steelQueue.Count == 0)
            {
                Console.WriteLine($"Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ",steelQueue)}");
            }
            
            if (carbonStack.Count == 0)
            {
                Console.WriteLine($"Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbonStack)}");
            }
           
            foreach (var sword in forging.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
            
        }
    }
}
