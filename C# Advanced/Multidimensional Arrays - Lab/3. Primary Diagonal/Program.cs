using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfSquareMatrix = int.Parse(Console.ReadLine());
          
            int[,]matrix = new int[sizeOfSquareMatrix,sizeOfSquareMatrix];

            for (int row = 0; row < sizeOfSquareMatrix; row++)
            {
                int[] inner = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < sizeOfSquareMatrix; col++)
                {
                    matrix[row, col] = inner[col];

                }
            }
            int sum = 0;
            for (int row = 0; row < sizeOfSquareMatrix; row++)
            {
                
                    sum += matrix[row, row];
                
            }
            Console.WriteLine(sum);
        }
    }
}
