using System;

using System.Collections.Generic;
using System.Linq;

namespace _01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Queue<double> water = new Queue<double>(Console.ReadLine().Split(" ",
                StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList());
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split(" ",
                StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList());
           

            Dictionary<double, string> percentages = new Dictionary<double, string>
            {
                {50.0/50, "Croissant"},
                {40.0/60,"Muffin" },
                {30.0/70,"Baguette" },
                {20.0/80,"Bagel" }
            };
            Dictionary<string, int> products = new Dictionary<string, int>();
            while(water.Count > 0 && flour.Count>0)
            {
                double currWater = water.Dequeue();
                double currFlour = flour.Pop();
                double sum = currWater + currFlour;

                double currWaterPercentage = currWater * 100 / sum;
                double currFlourPercentage = currFlour * 100 / sum;
                double ratio = currWaterPercentage / currFlourPercentage;
           
                if (percentages.ContainsKey(ratio))
                {
                    string currentProduct = percentages[ratio];
                    if(!products.ContainsKey(currentProduct))
                    {
                        products.Add(currentProduct, 0);
                    }
                    products[currentProduct]++;
                }
                else
                {
                    double diff = currFlour - currWater;
                    currFlour-=diff;
                    currFlourPercentage = currFlour * 100 / sum;
                    ratio = currWaterPercentage/currFlourPercentage;
                    if (percentages.ContainsKey(ratio))
                    {
                        string currentProduct = percentages[ratio];
                        if (!products.ContainsKey(currentProduct))
                        {
                            products.Add(currentProduct, 0);
                        }
                        products[currentProduct]++;
                    }
                    flour.Push(diff);
                }
            }
            if (products.Count > 0)
            {
                foreach (var product in products.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
            }
            if (water.Count > 0)
            {

                Console.WriteLine($"Water left: {string.Join(", ",water)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            if (flour.Count > 0)
            {

                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }

        }
    }
}
