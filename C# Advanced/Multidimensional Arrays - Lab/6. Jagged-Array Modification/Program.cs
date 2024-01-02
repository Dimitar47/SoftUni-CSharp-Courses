using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixRows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[matrixRows][];
            for (int i = 0; i < matrixRows; i++)
            {
                int[] matrixElements = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                jaggedArray[i] = matrixElements;

            }
            string command = "";
            while((command= Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (row >= 0 && row < matrixRows && col >= 0 && col < jaggedArray[row].Length)
                {
                    if (action == "Add")
                    {
                        jaggedArray[row][col] += value;
                    }
                    else
                    {
                        jaggedArray[row][col] -= value;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
