using System;
using System.Globalization;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols];
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                int[] inner = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {

                    matrix[i, j] = inner[j];
                    
                    sum += matrix[i, j];
                }
            }
        
            Console.WriteLine(sum);
        }
    }
}
