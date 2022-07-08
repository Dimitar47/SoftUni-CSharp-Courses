using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int commands = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();

            for (int i = 1; i <= commands; i++)
            {
                string[] text = Console.ReadLine().Split();
                if (text.Length > 3)
                {
                    if (list.Contains(text[0]))
                    {
                        list.Remove(text[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{text[0]} is not in the list!");
                    }
                }
                else
                {
                    if (!list.Contains(text[0]))
                    {
                        list.Add(text[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{text[0]} is already in the list!");
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, list));
        }
    }
}
