using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Action<List<string>> action = (List<string> names) => {

                names.ForEach(x => Console.WriteLine($"Sir {x}"));
                
                };
            action(names);
        }
    }
}
