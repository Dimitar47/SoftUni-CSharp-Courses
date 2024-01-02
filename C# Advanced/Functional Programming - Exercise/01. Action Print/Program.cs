using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Action<string[]> print = n => Console.WriteLine(string.Join(Environment.NewLine,n));
            print(names);
            
           
        }
        
    }
}
