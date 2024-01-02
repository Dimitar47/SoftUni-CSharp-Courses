using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            Queue<string> queue = new Queue<string>();
            while((name = Console.ReadLine()) != "End")
            {
                if (name == "Paid")
                {
                    while(queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(name);
                }
                
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
