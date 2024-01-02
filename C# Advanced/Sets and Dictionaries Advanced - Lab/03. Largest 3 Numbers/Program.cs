using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int count = Math.Min(numbers.Count, 3); // Get the minimum of the list count and 3

            for (int i = 0; i < count; i++)
            {
                int largestNumber = int.MinValue;

                foreach (int num in numbers)
                {
                    if (num > largestNumber)
                        largestNumber = num;
                }
                if(i<count-1)
                Console.Write(largestNumber + " ");
                else Console.Write(largestNumber);
                numbers.Remove(largestNumber);
            }
        }
    }
}
