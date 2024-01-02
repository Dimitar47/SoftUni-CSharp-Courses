using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack= new Stack<int>(clothes);
            int capacityRack = int.Parse(Console.ReadLine());
            int rack = 1;
            int saveCapacityRack = capacityRack;

        
            while(stack.Count > 0)
            {
                capacityRack -= stack.Peek();
                if(capacityRack< 0)
                {
                    capacityRack = saveCapacityRack;
                    rack++;
                    continue;
                }
                stack.Pop();
            }
            
         Console.WriteLine(rack);
        }
    }
}
