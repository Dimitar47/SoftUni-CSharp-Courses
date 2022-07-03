using System;
using System.Collections.Generic;
using System.Linq;
namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
          
            int[] wagons = new int[n];
            for (int i = 0; i < wagons.Length; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
                
                
            }
            Console.WriteLine(string.Join(" ",wagons));
            Console.WriteLine(wagons.Sum());
        }
    }
}
