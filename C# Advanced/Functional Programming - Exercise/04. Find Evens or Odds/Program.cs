using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Predicate<int> predicateEven = (x) => x % 2 == 0;
            Predicate<int> predicateOdd = (x) => x % 2 != 0;
            int[] range = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            string sth = Console.ReadLine();
            List<int> numbers = Enumerable.Range(range[0], range[1] - range[0]+1).ToList();
            numbers = sth == "even" ? numbers.Where(x => predicateEven(x)).ToList() 
                : numbers.Where(x=>predicateOdd(x)).ToList();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
