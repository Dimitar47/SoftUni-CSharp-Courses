using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaggedArray[row] = numbers;
            }
            for (int row = 0; row < rows-1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row+1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                        
                    }
                    for (int col = 0; col < jaggedArray[row+1].Length; col++)
                    {
                        jaggedArray[row+1][col] /= 2;

                    }
                }
            }
            string command = "";
            while((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                int isValidRow = int.Parse(tokens[1]);
                int isValidCol = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (action == "Add")
                {
                    if (isValidRow >= 0 && isValidRow < jaggedArray.Length)
                    {
                        if (isValidCol >= 0 && isValidCol < jaggedArray[isValidRow].Length)
                        {
                            jaggedArray[isValidRow][isValidCol] += value;
                        }
                    }
                }
                else
                {
                    if (isValidRow >= 0 && isValidRow < jaggedArray.Length)
                    {
                        if (isValidCol >= 0 && isValidCol < jaggedArray[isValidRow].Length)
                        {
                            jaggedArray[isValidRow][isValidCol] -= value;
                        }
                    }
                }
            }


            PrintMatrix(jaggedArray, rows);
           
        }

        private static void PrintMatrix(int[][] jaggedArray, int rows)
        {
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
