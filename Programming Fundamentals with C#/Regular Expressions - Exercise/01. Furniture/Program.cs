using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            string command = "";
            string pattern = @">>(?<furniture>[A-Za-z]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";
            List<string> list = new List<string>();
            while ((command = Console.ReadLine())!= "Purchase")
            {
                Match regex = Regex.Match(command, pattern, RegexOptions.IgnoreCase);

                if (regex.Success)
                {
                    string name = regex.Groups["furniture"].Value;
                    double price = double.Parse(regex.Groups["price"].Value);
                    int quantity = int.Parse(regex.Groups["quantity"].Value);
                    list.Add(name);
                    sum += price * quantity;
                }
             
            }
           
            
                Console.WriteLine("Bought furniture:");
        
                foreach (var some in list)
                {
                    Console.WriteLine(some);
                }
            
                Console.WriteLine($"Total money spend: {sum:f2}");
            
            
        }
    }
}
