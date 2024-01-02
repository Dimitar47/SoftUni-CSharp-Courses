using System;
using System.Collections.Generic;
using System.Linq;


namespace _00.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray() ;
            Queue<string> queue = new Queue<string>(songs);
            while(queue.Count > 0)
            {
                string commands = Console.ReadLine();
                string[] info = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = info[0];
                if (action == "Play")
                {
                    if (queue.Count > 0)
                    {
                        queue.Dequeue();
                    }
                }
                else if(action == "Add")
                {
                    string song = commands.Substring(4);
                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }
                }
                else if(action == "Show")
                {
                    Console.WriteLine(string.Join(", ",queue));
                }

            }
            Console.WriteLine("No more songs!");
        }
    }
}