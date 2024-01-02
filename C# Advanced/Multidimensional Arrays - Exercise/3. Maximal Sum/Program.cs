using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] matrix = new int[rows, cols];
            int maxSum = int.MinValue;
            int saveRow = 0;
            int saveCol = 0;
            for (int row = 0; row < rows; row++)
            {
                int[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = info[col];

                }
            }

            for (int row = 0; row < rows - 2; row++)
            {

                for (int col = 0; col < cols - 2; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                    + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        saveRow = row;
                        saveCol = col;
                    }

                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = saveRow; row < saveRow+3; row++)
            {
                for (int col = saveCol; col < saveCol+3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }


        }
        

        private static void PrintMatrix(int[,] matrix, int rows,int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row,col]+ " ");
                }
                Console.WriteLine();
            }
        }
    }
}
