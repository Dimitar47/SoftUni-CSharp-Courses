using System;
using System.Linq;
namespace _03._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = Console.ReadLine().Split().Select(double.Parse).ToArray();

            foreach (double num in array)
            {
                Console.WriteLine($"{Convert.ToDecimal(num)} => {Math.Round(Convert.ToDecimal(num), MidpointRounding.AwayFromZero)}");
            }
        
        }
    }
}
