using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] query = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int firstNum = query[0];
                if(firstNum == 1)
                {
                    int pushNum = query[1];
                    stack.Push(pushNum);
                }
                else if(firstNum == 2)
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                }
                else if(firstNum == 3)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if(firstNum == 4)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
