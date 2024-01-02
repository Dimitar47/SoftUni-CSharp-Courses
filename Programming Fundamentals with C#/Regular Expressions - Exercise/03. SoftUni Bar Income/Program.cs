using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            string pattern = @"^%(?<customer>[A-Z][a-z]+)%[^|$.%]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";

            double totalIncome = 0;

            while ((command = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(command, pattern);
                if (match.Success)
                {
                    double money = double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["count"].Value) ;
                    totalIncome += money;
                    Console.WriteLine($"{match.Groups["customer"]}: {match.Groups["product"]} - {money:f2}");
                }
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
