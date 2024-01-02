using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
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
            Stack<int> stack = new Stack<int>(numbers);
            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }
            if (stack.Any())
            {
                if (stack.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
        }
    }
}
