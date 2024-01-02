using System;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] isle = new char[rows, cols];
            string snake = Console.ReadLine();
            int wordIndex = 0;
          
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {


                        isle[row, col] = snake[wordIndex];

                        if (wordIndex >= snake.Length - 1)
                        {
                            wordIndex = 0;
                        }
                        else
                        {
                            wordIndex++;
                        }

                    }
                }
                else
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {

                            
                        isle[row, j] = snake[wordIndex];

                        if (wordIndex >= snake.Length-1)
                        {
                            wordIndex = 0;
                        }
                        else
                        {
                            wordIndex++;
                        }
                    }
                
                }
            }
            PrintMatrix(isle, rows, cols);
        }
        private static void PrintMatrix(char[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
