using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();
            foreach(var item in numbers)
            {
                queue.Enqueue(item);
            }
            int some = queue.Count;
            while (some > 0)
            {
                
                if (queue.Peek() % 2 == 0)
                {
                queue.Enqueue(queue.Dequeue());
                }
                else
                {
                    queue.Dequeue();
                }
                some--;
            }
            Console.WriteLine(string.Join(", ",queue));
            
            
        }
    }
}
