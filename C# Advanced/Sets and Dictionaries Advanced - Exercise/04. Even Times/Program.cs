using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int,int> keyValuePairs= new Dictionary<int,int>();
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!keyValuePairs.ContainsKey(number))
                {
                    keyValuePairs.Add(number, 0);
                }
                keyValuePairs[number]++;
            }
            foreach(var s in keyValuePairs)
            {
                if (s.Value % 2 == 0)
                {
                    Console.WriteLine(s.Key);
                }
            }

        }
    }
}
