using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] locks = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int intelligence = int.Parse(Console.ReadLine());
         
            Stack<int> bulletsStack = new Stack<int>(bullets);
            Queue<int> locksQueue = new Queue<int>(locks);
            int countBulletsRemoved = 0;
            while(locksQueue.Count>0 && bulletsStack.Count > 0)
            {


                

                int currentLock = locksQueue.Peek();
                
                int currentBullet = bulletsStack.Pop();
                countBulletsRemoved++;
                if (currentBullet > currentLock)
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    locksQueue.Dequeue();
                    Console.WriteLine("Bang!");
                }


                if (countBulletsRemoved % sizeOfBarrel == 0 && bulletsStack.Any())
                {
                    Console.WriteLine("Reloading!");
                }


            }
            if (locksQueue.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                int bulletCost = countBulletsRemoved * priceOfBullet;
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${intelligence - bulletCost}");
            }
        }
    }
}
