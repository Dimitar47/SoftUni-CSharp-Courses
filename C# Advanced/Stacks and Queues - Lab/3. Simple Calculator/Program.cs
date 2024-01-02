using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().Split().ToList();
            text.Reverse();
            Stack<string> stack = new Stack<string>(text);
            while (stack.Count > 1)
            {
                int operand1 = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int operand2 = int.Parse(stack.Pop());
                if (sign == "+")
                {
                    stack.Push((operand1 + operand2).ToString());
                }
                else if (sign == "-")
                {
                    stack.Push((operand1 - operand2).ToString());
                }
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
