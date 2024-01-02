using System;
using System.Collections.Generic;

namespace _06._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> hashset = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                hashset.Add(s);
            }
            foreach(var element in hashset)
            {
                Console.WriteLine(element);
            }
        }
    }
}
