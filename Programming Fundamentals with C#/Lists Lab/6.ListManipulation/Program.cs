using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.ListManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = "";
            while ((command = Console.ReadLine())!="end")
            {
                string[] commandArray = command.Split();
                if (commandArray[0] == "Add")
                {
                    numbers.Add(int.Parse(commandArray[1]));
                }
                else if (commandArray[0] == "Remove")
                {
                    numbers.Remove(int.Parse(commandArray[1]));
                }
                else if (commandArray[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(commandArray[1]));
                }
                else
                {
                    numbers.Insert(int.Parse(commandArray[2]),int.Parse(commandArray[1]));
                }
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
