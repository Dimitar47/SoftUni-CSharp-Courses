using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            int number = int.Parse(Console.ReadLine());
            
            Queue<string> queue = new Queue<string>(names);
            while(queue.Count > 1)
            {
               
                for (int i = 1; i <number; i++)
                {
                    queue.Enqueue(queue.Dequeue());

                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");

        }
    }
}
//string[] names = Console.ReadLine().Split();
//Queue<string> queue = new Queue<string>(names);
//int n = int.Parse(Console.ReadLine());
//int countKids = 0;
//while (queue.Count > 1)
//{
//    string kid = queue.Dequeue();
//    countKids++;
//    if (countKids == n)
//    {
//        countKids = 0;
//        Console.WriteLine($"Removed {kid}");
//    }
//    else
//    {
//        queue.Enqueue(kid);
//    }
//}
//Console.WriteLine($"Last is {queue.Peek()}");