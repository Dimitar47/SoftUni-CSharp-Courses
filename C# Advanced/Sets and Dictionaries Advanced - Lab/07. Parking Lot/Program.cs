using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            HashSet<string> set = new HashSet<string>();
            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.
                    Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string direction = input[0];
                string carNumber = input[1];
                if (direction == "IN")
                {
                    set.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    set.Remove(carNumber);

                }
            }
            if (set.Count > 0)
            {
                foreach (var element in set)
                    Console.WriteLine(element);
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
