using System;
using System.Linq;

namespace _2.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            double leftRacerTime = 0;
            for (int i = 0; i < array.Length/2; i++)
            {
                leftRacerTime += array[i];
                if (array[i] == 0)
                {
                    leftRacerTime = leftRacerTime * 0.8;
                }
            }

            double rightRacerTime = 0;
            for (int i = array.Length-1; i > array.Length/2; i--)
            {
                rightRacerTime += array[i];
                if (array[i] == 0)
                {
                    rightRacerTime = rightRacerTime * 0.8;
                }
            }

            if (leftRacerTime < rightRacerTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftRacerTime}");
            }
            else if (leftRacerTime > rightRacerTime)
            {
                Console.WriteLine($"The winner is right with total time: {rightRacerTime}");
            }

        }
    }
}
