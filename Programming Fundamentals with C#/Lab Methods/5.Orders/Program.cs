using System;

namespace _5.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double price;
            if (product == "coffee")
            {
                price = 1.50;
            }
            else if (product == "water")
            {
                price = 1.00;
            }
            else if (product == "coke")
            {
                price = 1.40;
            }
            else
            {
                price = 2.00;
            }

            Console.WriteLine($"{Calculate(quantity,price):f2}");
        }

        static double Calculate(int quantity,double price)
        {
            return quantity*price;
        }
    }
}
