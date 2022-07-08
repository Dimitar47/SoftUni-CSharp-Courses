using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string command = "";
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArray = command.Split();

                if (commandArray[0] == "Add")
                {
                    wagons.Add(int.Parse(commandArray[1]));
                }
                else if (int.TryParse(commandArray[0], out int result))
                {
                    int passengers = int.Parse(commandArray[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passengers <= maxCapacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
