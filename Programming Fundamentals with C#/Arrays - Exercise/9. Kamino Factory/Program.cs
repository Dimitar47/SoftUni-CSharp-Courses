using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayLenght = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int[] DNA = new int[arrayLenght];
            int lenght = 0;
            int index = 0;
            int sum = 0;
            int currentRow = 0;
            int row = 0;

            while (input != "Clone them!")
            {
                int[] currentDNA = input.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                currentRow++;

                int currentSum = 0;
                for (int i = 0; i < currentDNA.Length; i++)
                {
                    if (currentDNA[i] == 1)
                    {
                        currentSum++;
                    }
                }

                int currentLenght = 0;
                int currentIndex = 0;

                for (int i = 0; i < currentDNA.Length; i++)
                {
                    if (currentDNA[i] == 1)
                    {

                        currentLenght++;
                        if (currentLenght == 1)
                        {
                            currentIndex = i;
                        }

                        if (currentLenght > lenght || currentLenght == lenght && (currentIndex < index || currentSum > sum))
                        {
                            lenght = currentLenght;
                            index = currentIndex;
                            row = currentRow;
                            DNA = currentDNA;
                            sum = currentSum;

                        }

                    }
                    else
                    {
                        currentIndex = 0;
                        currentLenght = 0;
                    }

                }

                input = Console.ReadLine();
            }

            if (row == 0)
            {
                row = 1;
            }

            Console.WriteLine($"Best DNA sample {row} with sum: {sum}.");
            Console.WriteLine(string.Join(" ", DNA));
        }
    }
}