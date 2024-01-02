using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char,int> symbols = new Dictionary<char,int>();
            foreach (var s in text)
            {
                if (!symbols.ContainsKey(s))
                {
                    symbols.Add(s, 0);
                }
                symbols[s]++;
            }
            symbols = symbols.OrderBy(x => x.Key).ToDictionary(x=>x.Key, x => x.Value);
            foreach(var s in symbols)
            {
                Console.WriteLine($"{s.Key}: {s.Value} time/s");
            }
        }
    }
}
