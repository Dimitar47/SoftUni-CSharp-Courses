using System;
using System.Collections.Generic;
using System.Linq;

namespace _00.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();

            foreach(var digit in list)
            {
                if (!keyValuePairs.ContainsKey(digit))
                {
                    keyValuePairs.Add(digit, 0);
                }
                keyValuePairs[digit]++;
            }
            foreach(var dictionar in keyValuePairs.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{dictionar.Key} -> {dictionar.Value}");
            }

        }
    }
}
