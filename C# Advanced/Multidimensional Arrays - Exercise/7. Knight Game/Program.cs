using System;
using System.Drawing;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int sizeOfBoard = int.Parse(Console.ReadLine()); // dimension(rows,cols) - a square with equal rows and cols
            if (sizeOfBoard < 3)
            {
                Console.WriteLine(0);
                return;
            }
           
            char[,] matrix = new char[sizeOfBoard,sizeOfBoard];
            for (int row = 0; row < sizeOfBoard; row++)
            {
                string command = Console.ReadLine();
                for (int col = 0; col < sizeOfBoard; col++)
                {

                matrix[row, col] = command[col];
                }

            }
            int knightsRemoved = 0;
            while (true) {

                int countMostAttacking = 0;
                int rowMostAttacking = 0;
                int colMostAttacking = 0;
              
                for (int row = 0; row < sizeOfBoard; row++)
                {
                    for (int col = 0; col < sizeOfBoard; col++)
                    {

                        if (matrix[row, col] == 'K')
                        {
                            int attackedKnights = CountAttackedKnights(row, col, sizeOfBoard, matrix);

                            if (countMostAttacking < attackedKnights)
                            {
                                countMostAttacking = attackedKnights;
                                rowMostAttacking = row;
                                colMostAttacking = col;
                            }

                        }
                    }

                }
                if (countMostAttacking == 0)
                {
                    break;
                }
                else
                {
                    matrix[rowMostAttacking, colMostAttacking] = '0';
                    knightsRemoved++; 
                }
            }
            Console.WriteLine(knightsRemoved);
            




        }

        private static int CountAttackedKnights(int row, int col, int sizeOfBoard, char[,] matrix)
        {
            int attackedKnights = 0;
            //horizontal left-up
            //moving two squares horizontally to the left, then one square vertically
            if (ValidateCell(row-1, col-2, sizeOfBoard))
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            //horizontal left-down
            //moving two squares horizontally to the left,then one square down
            if (ValidateCell(row + 1, col - 2, sizeOfBoard))
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            //horizontal right-up
            //moving two squares horizontally to the right,then one square vertically
            if (ValidateCell(row-1, col+2, sizeOfBoard))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }
           
            //horizontal right-down
            //moving two squares horizontally to the right,then one square down
            if (ValidateCell(row + 1, col + 2, sizeOfBoard))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            //horizontal up-left
            //moving two squares vertically,then one square horizontally to the left
            if (ValidateCell(row -2, col -1, sizeOfBoard))
            {
                if (matrix[row -2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            //horizontal up-right
            //moving two squares vertically,then one square horizontally to the right
            if (ValidateCell(row - 2, col + 1, sizeOfBoard))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            //horizontal down-left
            //moving two squares down,then one square horizontally to the left
            if (ValidateCell(row +2, col - 1, sizeOfBoard))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            //horizontal down-right
            //moving two squares down,then one square horizontally to the right
            if (ValidateCell(row + 2, col + 1, sizeOfBoard))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }




            return attackedKnights;
        }

        private static bool ValidateCell(int row, int col, int sizeOfBoard)
        {
            return row>=0 && row < sizeOfBoard && col>=0 && col < sizeOfBoard;
        }

        private static void PrintMatrix(char[,] matrix, int rows, int cols)
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
