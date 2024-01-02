using System;
using System.Collections.Generic;
using System.Linq;


namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int petrolPerKilometer = 1;
            Queue<int[]> pumps = new();
            int petrolPumps = int.Parse(Console.ReadLine());

            for (int i = 0; i < petrolPumps; i++)
            {
                pumps.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
            }
            int startIndex = 0;
            while (true)
            {
                int totalLiters = 0;
                bool isComplete = true;
                foreach(var pump in pumps)
                {
                    int petrolLiters = pump[0];
                    int petrolDistance = pump[1];
                    totalLiters+=petrolLiters;
                    if(totalLiters - petrolDistance * petrolPerKilometer < 0)
                    {
                        startIndex++;
                        pumps.Enqueue(pumps.Dequeue());
                        isComplete = false;
                        break;
                    }
                    totalLiters-=petrolDistance* petrolPerKilometer;
                }
                if (isComplete)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }
        }
    }
}