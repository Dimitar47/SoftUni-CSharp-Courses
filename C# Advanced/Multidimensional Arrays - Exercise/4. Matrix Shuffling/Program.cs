using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string[,]matrix = new string[rows,cols];
            for (int row = 0; row < rows; row++)
            {
                string[] info = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < cols; col++)
                {
                    matrix[row,col] = info[col];
                }
            }
            string command = "";
            while((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 5 && tokens[0] == "swap")
                {
                    string action = tokens[0];
                    int row1 = int.Parse(tokens[1]);
                    int col1 = int.Parse(tokens[2]);
                    int row2 = int.Parse(tokens[3]);
                    int col2 = int.Parse(tokens[4]);

                    if (row1 >= 0 && row1 < rows && col1 >= 0 && col1 < cols
                        && row2 >= 0 && row2 < rows && col2 >= 0 && col2 < cols)
                    {
                        string tempVal = matrix[row1, col1];
                        matrix[row1,col1] = matrix[row2,col2];
                        matrix[row2,col2] = tempVal;
                        PrintMatrix(matrix, rows, cols);
                    }

                    else
                    {
                        
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
            }
        
          
        }
        private static void PrintMatrix(string[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
