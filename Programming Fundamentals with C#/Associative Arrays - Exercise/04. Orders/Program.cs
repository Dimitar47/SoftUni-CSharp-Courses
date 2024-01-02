using System;
using System.Collections.Generic;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> dictionary = new Dictionary<string, List<double>>();
           
            string input = Console.ReadLine();
            while (input != "buy")
            {
                string[] tokens = input.Split();
                string product = tokens[0] ;
                if (!dictionary.ContainsKey(tokens[0]))
                {
                    dictionary.Add(product, new List<double>());
                    dictionary[product].Add(double.Parse(tokens[1]));
                    dictionary[product].Add(double.Parse(tokens[2]));
                }
                else
                {
                    dictionary[product][1] += double.Parse(tokens[2]);
                    dictionary[product][0] = double.Parse(tokens[1]);
                }
                input = Console.ReadLine();
            }
            foreach (var item in dictionary)
            {
                Console.Write($"{item.Key} -> ");
                double allPrice = 1;
                foreach (var value in item.Value)
                {
                    allPrice *= value;
                }
                Console.WriteLine($"{allPrice:F2}");
            }

        }
    }
}
