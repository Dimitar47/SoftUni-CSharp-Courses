using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] cupsCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] filledBottles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int amountOfWastedWater = 0;
            Queue<int> queueCupsCapacity = new Queue<int>(cupsCapacity);
            Stack<int> stackFilledBottles = new Stack<int>(filledBottles);
           

           
            while (queueCupsCapacity.Count > 0 && stackFilledBottles.Count > 0)
            {
                int currentCup = queueCupsCapacity.Peek();
                int currentBottle = stackFilledBottles.Peek();

                if (currentCup > currentBottle)
                {
                    int reducedCupValue = currentCup - currentBottle; // filling is done and there is left capacity in the cup
                    stackFilledBottles.Pop();

                    while (reducedCupValue > 0 && stackFilledBottles.Any())
                    {
                        int nextBottle = stackFilledBottles.Peek();
                        if (nextBottle > reducedCupValue)
                        {
                            amountOfWastedWater = amountOfWastedWater + (nextBottle - reducedCupValue); //there are wastedWater
                            reducedCupValue -= nextBottle;
                        }

                        else
                        {
                            reducedCupValue -= nextBottle; // reducedCupValue <= 0 and there aren't wastedWater
                        }
                        stackFilledBottles.Pop();


                    }
                    queueCupsCapacity.Dequeue();
                }
                else if (currentBottle >= currentCup)
                {
                    
                    amountOfWastedWater += (currentBottle-currentCup);
                    queueCupsCapacity.Dequeue();
                    stackFilledBottles.Pop();
              
                }
               
                
            }
            if (stackFilledBottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",stackFilledBottles)}");
                Console.WriteLine($"Wasted litters of water: {amountOfWastedWater}");
            }
            else if (queueCupsCapacity.Count > 0)
            {
                  Console.WriteLine($"Cups: {string.Join(" ",queueCupsCapacity)}");
                  Console.WriteLine($"Wasted litters of water: {amountOfWastedWater}");
            }
            
        }
    }
}
