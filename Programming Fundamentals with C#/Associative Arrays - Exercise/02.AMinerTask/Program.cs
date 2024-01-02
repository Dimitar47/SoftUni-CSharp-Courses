using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            while ((command = Console.ReadLine()) != "stop")
            {

                string resource = command;
                int quantity = int.Parse(Console.ReadLine());
                if (!dictionary.ContainsKey(resource))
                {
                    dictionary.Add(resource, quantity);
                }
                else
                {
                    dictionary[resource] += quantity;
                }

            }
            foreach(var dictionar in dictionary)
            {
                Console.WriteLine($"{dictionar.Key} -> {dictionar.Value}");
            }

        }
    }
}

