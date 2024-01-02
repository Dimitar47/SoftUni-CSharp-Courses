using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int lengthOfFirstSet = numbers[0];
            int lengthOfSecondSet = numbers[1];
            for (int i = 0; i < lengthOfFirstSet; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstSet.Add(num);
            }
            for (int i = 0; i < lengthOfSecondSet; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondSet.Add(num);
            }
            HashSet<int> united = new HashSet<int>();
            foreach(var first in firstSet)
            {
                foreach(var second in secondSet)
                {
                    if(first == second)
                    {
                        united.Add(first);
                    }
                }
            }
            Console.WriteLine(string.Join(" ",united));

        }
    }
}
