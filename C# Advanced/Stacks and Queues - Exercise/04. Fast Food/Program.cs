using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(orders);
            Console.WriteLine(queue.Max());
            for (int i = 0; i < orders.Length; i++)
            {
                if (quantity - orders[i] >= 0)
                {
                    quantity -= orders[i];
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if(queue.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ",queue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
