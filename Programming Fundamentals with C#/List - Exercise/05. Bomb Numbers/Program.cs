using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split(' ')
                 .Select(int.Parse)
                 .ToList();

            int[] bomb = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int bombNumber = bomb[0];
            int power = bomb[1];

            while (numbers.Contains(bombNumber))
            {
                int index = numbers.IndexOf(bombNumber);
                numbers.RemoveRange(Math.Max(index - power, 0), Math.Min(power * 2 + 1, numbers.Count - Math.Max(index - power, 0)));
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
