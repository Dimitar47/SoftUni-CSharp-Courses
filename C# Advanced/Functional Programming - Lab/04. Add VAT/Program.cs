using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select((n)=>double.Parse(n))
                .Select((n)=>n*1.20)
                .ToList();
            numbers.ForEach(n=>Console.WriteLine($"{n:f2}"));

        }
    }
}
