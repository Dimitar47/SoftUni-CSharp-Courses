using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray() ;
            int rows = matrixSize[0] ;
            int cols = matrixSize[1] ;
            int[,] matrix = new int[rows, cols] ;
            int biggestSum = int.MinValue;
            int saveRow = 0;
            int saveCol = 0;
            for (int row = 0; row < rows; row++)
            {
                int[] inner = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
              
                for (int col = 0; col < cols; col++)
                {

                    matrix[row,col] = inner[col] ;

                   
                }
            }
            for (int row = 0; row < rows; row++)
            {
               
                for (int col = 0; col < cols; col++)
                {
                    int currentSum = 0;
                    if (col == cols - 1 || row ==rows-1)
                    {
                        continue;
                    }

                    currentSum += matrix[row, col];
                    currentSum += matrix[row, col + 1];
                    currentSum += matrix[row + 1, col];
                    currentSum += matrix[row + 1, col + 1];
                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        saveRow = row;
                        saveCol = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[saveRow,saveCol]} {matrix[saveRow, saveCol + 1]}");
            Console.WriteLine($"{matrix[saveRow+1,saveCol]} {matrix[saveRow + 1, saveCol + 1]}");
            Console.WriteLine(biggestSum);
        
           
        }
    }
}
