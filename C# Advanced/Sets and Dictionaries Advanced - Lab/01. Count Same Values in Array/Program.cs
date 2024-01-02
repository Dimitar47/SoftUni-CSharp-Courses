using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double,int> keyValuePairs= new Dictionary<double,int>();
            List<double> values = Console.ReadLine().Split(" ",
                StringSplitOptions.RemoveEmptyEntries).Select(double.Parse)
                .ToList();
            foreach(var value in values)
            {
                if (!keyValuePairs.ContainsKey(value))
                {
                    keyValuePairs.Add(value, 0);
                }
                keyValuePairs[value]++;
            }
            foreach(var item in keyValuePairs)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
           
        }
    }
}
