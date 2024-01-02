using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            string[,] matrix = new string[matrixSize,matrixSize];
            for (int row = 0; row < matrixSize; row++)
            {
                string inner = Console.ReadLine();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = inner[col].ToString();
                }
            }
            string symbol = Console.ReadLine();
          
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row,col] == symbol)
                    {
                        
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix");
       }
    }
}
