using System;
using System.Collections.Generic;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string someString = "";
            Stack<string> stack = new Stack<string>();
            
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int num = int.Parse(info[0]);
                if(num==1)
                {
                    stack.Push(someString);
                     someString += info[1];
                   
                    stack.Push("1");
                   
                }
                else if(num==2)
                {
                    // string
                    // remove the last 2 characters - ng
                    // startIndex = 6 -2 = 4
                    int count = int.Parse(info[1]);
                    int startIndex = someString.Length - count;
                    string substring = someString.Substring(startIndex,count);
                    someString = someString.Remove(startIndex, count);
                    stack.Push(substring);
                    stack.Push("2");
                   
                }
                else if (num == 3)
                {
                    int index = int.Parse(info[1]);
                    Console.WriteLine(someString[index-1]);
                }
                else if (num == 4)
                {
                    int number = int.Parse(stack.Pop());
                    if (number ==2)
                    {
                        someString += stack.Pop();
                    }
                    else
                    {
                       someString = stack.Pop(); 
                    }
                    
                }
            }
        }
    }
}
