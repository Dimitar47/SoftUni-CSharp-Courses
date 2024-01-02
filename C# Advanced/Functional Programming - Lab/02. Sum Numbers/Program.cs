using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sum_Numbers
{
    internal class Program
    {
       
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Sum());

         /*   static Action<int[]> output = x => Console.WriteLine($"{x.Count()}\n{x.Sum()}");

            static void Main()
            {
                output(Console.ReadLine()
                      .Split(", ")
                      .Select(int.Parse)
                      .ToArray());
            }
         */


        }
    }
}



    
