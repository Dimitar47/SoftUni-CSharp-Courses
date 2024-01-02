using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TheAngryCat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> priceRatings = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            int entryPoint = int.Parse(Console.ReadLine());
            int number = priceRatings[entryPoint];
            string typeOfItems = Console.ReadLine();
            int damageLeft = 0;
            int damageRight = 0;
            for (int i = entryPoint-1; i >=0; i--)
            {
                if (typeOfItems == "cheap")
                {
                    if (priceRatings[i] < number)
                    {
                        damageLeft += priceRatings[i];
                        
                    }
                }
                else
                {
                    if (priceRatings[i] >= number)
                    {
                        damageLeft += priceRatings[i];
                       
                    }
                }

            }
      
            for (int i = priceRatings.Count-1; i >entryPoint; i--)
            {
                if (typeOfItems == "cheap")
                {
                    if (priceRatings[i] < number)
                    {
                        damageRight += priceRatings[i];
                        
                    }
                }
                else
                {
                    if (priceRatings[i] >= number)
                    {
                        damageRight += priceRatings[i];
                       
                    }
                }
            }
            

            if (damageRight != damageLeft)
            {
                int max = Math.Max(damageLeft, damageRight);
                if (max == damageLeft)
                {
                    Console.WriteLine($"Left - {damageLeft}");
                }
                else
                {
                    Console.WriteLine($"Right - {damageRight}");
                }
            }
            else
            {
                Console.WriteLine($"Left - {damageLeft}");
            }


        }
    }
}
