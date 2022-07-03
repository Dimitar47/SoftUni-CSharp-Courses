using System;

namespace _00.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int HEIGHT = int.Parse(Console.ReadLine());



            // Allocate the array in a triangle form

            long[][] triangle = new long[HEIGHT + 1][];

            for (int row = 0; row < HEIGHT; row++)
            {
                triangle[row] = new long[row + 1];
            }

            // Calculate the Pascal's triangle
            triangle[0][0] = 1;

            for (int row = 0; row < HEIGHT-1; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    triangle[row + 1][col] += triangle[row][col];
                    triangle[row + 1][col+1] += triangle[row][col];
                    
                }
            }

            for (int row = 0; row < HEIGHT; row++)
            {
                for (int col = 0; col <=row; col++)
                {
                    Console.Write(triangle[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
