using System;
using System.Collections.Generic;
namespace CustomStack5
{
    class Program
    {
        static void Main(string[] args)
        {
            StackOfStrings myStack = new StackOfStrings();

            Console.WriteLine(myStack.IsEmpty()); 

            Stack<string> stack = new Stack<string>();
          
            for (int i = 0; i < 5; i++)
            {
                stack.Push($"element{i}");
            }

            myStack.AddRange(stack);
         

            Console.WriteLine(myStack.Count);
        }
    }
}
        
    

