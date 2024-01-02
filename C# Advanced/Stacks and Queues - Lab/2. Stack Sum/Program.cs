using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            string command = "";

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] commandArray = command.Split();
                if (commandArray[0] == "add")
                {
                    stack.Push(int.Parse(commandArray[1]));
                    stack.Push(int.Parse(commandArray[2]));
                }
                else if(commandArray[0] == "remove")
                {
                    int numbersToRemove = int.Parse(commandArray[1]);
                    if (stack.Count >= numbersToRemove)
                    {
                        while (numbersToRemove>0)
                        {
                            stack.Pop();
                            numbersToRemove--;
                        }
                    }
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
