using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string,int> parse = (x) => int.Parse(x);
            List<int> numbers = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(parse).Where(x=>x%2==0).OrderBy(x=>x).ToList();
       
            Console.WriteLine(string.Join(", ", numbers));


        }
    }
}
