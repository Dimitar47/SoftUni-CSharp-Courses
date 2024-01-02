using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();         
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < text.Length; i++)
            {

                    if (text[i] == '(')
                    {
                        stack.Push(i);
                        
                    }
                    else if (text[i] == ')')
                    {
                        int startIndex = stack.Pop();
                        string substring = text.Substring(startIndex,i - startIndex+1);
                        Console.WriteLine(substring);
                    }
            }           
        }
    }
}
