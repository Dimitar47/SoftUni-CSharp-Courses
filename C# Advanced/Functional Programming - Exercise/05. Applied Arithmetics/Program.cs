using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string command = "";
            
            while((command = Console.ReadLine()) != "end") 
            {
                switch (command)
                {
                    case "add":
                        Select(numbers, n => n + 1);
                        break;
                    case "multiply":
                        Select(numbers, n => n * 2);
                        break;
                    case "subtract":
                        Select(numbers, n => n - 1);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ",numbers));
                        break;
                    default:
                        break;
                }
            
            
            }
            int[] Select(int[] numbers,Func<int,int> operation)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = operation(numbers[i]);
                }
                return numbers;
            }
        }
    }
}
