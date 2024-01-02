using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> dictionary = new Dictionary<string, Dictionary<string, double>>();
            string command = "";
            while((command = Console.ReadLine()) != "Revision")
            {
                string[] input = command.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);
                if (!dictionary.ContainsKey(shop))
                {
                    dictionary.Add(shop,new Dictionary<string, double>());
                }
                if (!dictionary[shop].ContainsKey(product))
                {
                    dictionary[shop].Add(product, price);

                }
            }
            foreach(var shop in dictionary.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach(var (product,price)in shop.Value)
                {
                     Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}
