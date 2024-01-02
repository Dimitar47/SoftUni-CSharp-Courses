using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parantheses = Console.ReadLine();


            Stack<char> stack = new Stack<char>();
            bool isBalanced = true;
            for (int i = 0; i < parantheses.Length ; i++)
            {
                char current = parantheses[i];
                if (current == '(' || current == '{' || current == '[')
                {
                    stack.Push(current);
                }
                else
                {
                 
                    char topElement = stack.Pop();
                    {
                        if(current== '}' && topElement!='{') 
                        {
                            isBalanced = false;
                            break;
                        }
                        else if(current==')' && topElement != '(')
                        {
                            isBalanced = false;
                            break;
                        }
                        else if(current == ']' && topElement != '[')
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                }
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
