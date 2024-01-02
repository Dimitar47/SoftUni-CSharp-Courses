using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int commands = int.Parse(Console.ReadLine());
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            for(int i = 0; i < commands; i++)
            {
                string[] commandArray = Console.ReadLine().Split();
                if (commandArray[0] == "register")
                {
                    string username = commandArray[1];
                    string license = commandArray[2];
                    if (!dictionary.ContainsKey(username))
                    {
                        dictionary.Add(username, license);
                        Console.WriteLine($"{username} registered {license} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {license}");
                    }
                }
                else
                {
                    string username = commandArray[1];
                    if (!dictionary.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{username} unregistered successfully");
                        dictionary.Remove(username);
                    }
                }
            }
            foreach(KeyValuePair<string,string> keyValuePair in dictionary)
            {
                Console.WriteLine($"{keyValuePair.Key} => {keyValuePair.Value}");
            }
        }
    }
}
