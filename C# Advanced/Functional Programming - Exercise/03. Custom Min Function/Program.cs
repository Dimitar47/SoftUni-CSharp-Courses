using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Func<int[], int> smallestNumber = FindSmallest;
            Console.WriteLine(smallestNumber(numbers));
            int FindSmallest(int[] numbers)
            {
                int smallest = int.MaxValue;
                foreach(int number in numbers)
                {
                    if (number < smallest)
                    {
                        smallest = number;
                    }
                }
                return smallest;
            }
        }
    }
}
