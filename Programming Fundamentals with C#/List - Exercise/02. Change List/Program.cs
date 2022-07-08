using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input.Split();
                if (tokens[0] == "Delete")
                {
                    list.RemoveAll(n => n == int.Parse(tokens[1]));
                }

                else if (tokens[0] == "Insert")
                {
                    list.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
                }
                input = Console.ReadLine();

            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
