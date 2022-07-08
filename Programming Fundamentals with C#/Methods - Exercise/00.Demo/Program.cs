using System;
using System.Linq;

namespace _00.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int[] newArray = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                newArray[i] = numbers[i];
            }

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (command[0] != "end")
            {

                if (command[0] == "exchange")
                {


                    if (int.Parse(command[1]) < 0 || int.Parse(command[1]) >= numbers.Length)
                    {
                        Console.WriteLine("Invalid index");

                    }
                    else
                    {
                        int indexer = 0;
                        int oldArrayIndexer = 0;


                        for (int i = int.Parse(command[1]) + 1; i < numbers.Length; i++)
                        {
                            newArray[indexer] = numbers[i];
                            indexer++;
                        }

                        for (int i = indexer; i < newArray.Length; i++)
                        {
                            newArray[indexer] = numbers[oldArrayIndexer];
                            indexer++;
                            oldArrayIndexer++;
                        }

                        for (int i = 0; i < newArray.Length; i++)
                        {
                            numbers[i] = newArray[i];
                        }

                        Console.WriteLine(String.Join(", ", newArray));
                        Console.WriteLine(String.Join(", ", numbers));
                    }
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
        }
    }
}
