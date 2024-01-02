using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nsx = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = nsx[0];
            int s = nsx[1];
            int x = nsx[2];
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(numbers);
            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }
            if (queue.Any())
            {
                if (queue.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
        }
    }
}
