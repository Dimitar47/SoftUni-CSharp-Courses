using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];

            for (int row = 0; row < size; row++)
            {
                int[] info = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row,col] = info[col];
                }

            }
            int primary = 0;
            int secondary = 0;
            for (int i = 0; i < size; i++)
            {
                primary += matrix[i, i];
                secondary += matrix[size-i-1, i];
            }
            Console.WriteLine(Math.Abs(primary-secondary));
        }
    }
}
