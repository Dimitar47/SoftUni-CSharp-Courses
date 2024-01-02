using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CoffeeLover
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> coffees = Console.ReadLine().Split().ToList();
            int n = int.Parse(Console.ReadLine());
           
            for (int i = 0; i < n; i++)
            {
               string command = Console.ReadLine();
                string[] commandArray = command.Split();
                if (commandArray[0] == "Include")
                {
                    string coffee = commandArray[1];
                    coffees.Add(coffee);
                    
                }
                else if (commandArray[0] == "Remove")
                {
                    if (coffees.Count > int.Parse(commandArray[2]))
                    {
                        if (commandArray[1] == "first")
                        {
                            for (int j = 0; j < int.Parse(commandArray[2]); j++)
                            {
                                coffees.RemoveAt(0);
                                
                            }
                        }
                        else if (commandArray[1] == "last")
                        {
                            for (int j = 0; j < int.Parse(commandArray[2]); j++)
                            {
                                coffees.RemoveAt(coffees.Count - 1);
                            }
                        }
                        
                    }
                }

                else if (commandArray[0] == "Prefer")
                {
                    int firstIndex = int.Parse(commandArray[1]);
                    int secondIndex = int.Parse(commandArray[2]);
                 
                    if (firstIndex >= 0 && firstIndex < coffees.Count && secondIndex >= 0 &&
                        secondIndex < coffees.Count)
                    {
                        string firstCoffee = coffees[firstIndex];
                        string secondCoffee = coffees[secondIndex];
                        coffees[secondIndex] = firstCoffee;
                        coffees[firstIndex] = secondCoffee;

                    }
                }
                else if (commandArray[0] == "Reverse")
                {
                    coffees.Reverse();
                }
            }

            Console.Write("Coffees:");
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", coffees));

        }
    }
}
