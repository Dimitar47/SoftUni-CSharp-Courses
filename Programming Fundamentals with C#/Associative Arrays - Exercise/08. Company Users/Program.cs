using System;
using System.Collections.Generic;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            while((command = Console.ReadLine()) != "End")
            {
                string[] commandArray = command.Split(" -> ");
                string companyName = commandArray[0];
                string employeeId = commandArray[1];
                if (!dictionary.ContainsKey(companyName))
                {
                    dictionary.Add(companyName, new List<string>());
                    dictionary[companyName].Add(employeeId);
                }
                else
                {
                    if (!dictionary[companyName].Contains(employeeId))
                    {
                        dictionary[companyName].Add(employeeId);
                    }
                }

            }
            foreach(var dictionar in dictionary)
            {
                Console.WriteLine($"{dictionar.Key}");
                for (int i = 0; i < dictionar.Value.Count; i++)
                {
                    Console.WriteLine($"-- {dictionar.Value[i]}");

                }
            }
        }
    }
}
