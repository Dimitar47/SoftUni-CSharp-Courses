using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new Queue<string>();

            int carsPassed = 0;
            string car = "";
            while ((car = Console.ReadLine())!="END")
            {
                

                int greenLightsCopy = greenLightSeconds;
                int freeWindowCopy = freeWindowSeconds;


                if (car == "green")
                {
                    while (greenLightsCopy > 0 && carsQueue.Count != 0)
                    {

                        string firstInQueue = carsQueue.Dequeue();
                        greenLightsCopy -= firstInQueue.Length;
                        if (greenLightsCopy >= 0)
                        {
                            carsPassed++;
                        }

                        else
                        {
                            freeWindowCopy += greenLightsCopy;
                            if (freeWindowCopy < 0)
                            {

                            Console.WriteLine($"A crash happened!");

                            Console.WriteLine($"{firstInQueue} was hit at " +
                                $"{firstInQueue[firstInQueue.Length + freeWindowCopy]}.");

                            return;

                            }
                            carsPassed++;
                        }
                    }
                }

                else
                {
                    carsQueue.Enqueue(car);
                }
            }
            Console.WriteLine($"Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
           
    }
}
