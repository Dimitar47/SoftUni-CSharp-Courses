using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string command = "";
            Queue<string> queue = new Queue<string>();
            int countCars = 0;
            while((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                   
                        for (int i = 0; i < n; i++)
                        {
                            if (queue.Count == 0)
                            {
                                break;
                            }
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            countCars++;
                        
                        }   
                }
                else
                {
                    queue.Enqueue(command);
                }
            }
            Console.WriteLine($"{countCars} cars passed the crossroads.");
        }
    }
}
