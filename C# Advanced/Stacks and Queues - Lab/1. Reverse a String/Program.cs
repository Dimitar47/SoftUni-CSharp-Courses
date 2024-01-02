using System;
using System.Collections.Generic;

namespace _1._Reverse_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < text.Length; i++)
            {
                stack.Push(text[i].ToString());
            }
            Console.WriteLine(string.Join("", stack.ToArray()));
        }
    }
}
//string input = Console.ReadLine();
//Stack<string> stack = new Stack<string>();
//for (int i = 0; i < input.Length; i++)
//{
//    stack.Push(input[i].ToString());
//}
//while (stack.Count > 0)
//{
//    Console.Write(stack.Pop());
//}