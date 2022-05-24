using System;

namespace _11._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double price = 0;
            double sum = 0;
            for (int i = 0; i <n; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());
                price = ((days * capsulesCount) * pricePerCapsule);
                sum += price;
                Console.WriteLine($"The price for the coffee is: ${price:F2}");
            }

           
            Console.WriteLine($"Total: ${sum:F2}");

        }
    }
}
