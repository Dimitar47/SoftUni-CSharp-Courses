using System;

namespace _0.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfBoard = int.Parse(Console.ReadLine());
            if (sizeOfBoard < 3)
            {
                Console.WriteLine(0);
                return;
            }
            char[,] matrix = new char[sizeOfBoard, sizeOfBoard];
            for (int row = 0; row < sizeOfBoard; row++)
            {
                string info = Console.ReadLine();
                for (int col = 0; col < sizeOfBoard; col++)
                {
                    matrix[row, col] = info[col];
                }
            }
            int removedKnights = 0;
            while (true)
            {
                int countMostAttackedKnights = 0;
                int rowMostAttacking = 0;
                int colMostAttacking = 0;
                for (int row = 0; row < sizeOfBoard; row++)
                {
                    for (int col = 0; col < sizeOfBoard; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int attackedKnights = CountAttackedKnights(row, col, sizeOfBoard, matrix);
                            if(countMostAttackedKnights < attackedKnights)
                            {
                                countMostAttackedKnights = attackedKnights;
                                rowMostAttacking = row;
                                colMostAttacking = col; 
                            }
                        }
                    }
                }
                if(countMostAttackedKnights == 0)
                {
                    break;  
                }
                else
                {
                    matrix[rowMostAttacking, colMostAttacking] = '0';
                    removedKnights++;
                }
               
            }
            Console.WriteLine(removedKnights);
        }

        private static int CountAttackedKnights(int row, int col, int size, char[,] matrix)
        {
            int attackedKnights = 0;

            //positions to move
            //horizontal up-left
            if (ValidateCell(row-2, col-1, size))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            //horizontal up-right
            if(ValidateCell(row-2,col+1, size))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }



            //horizontal left-up
            if (ValidateCell(row - 1, col - 2, size))
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            //horizontal right-up
            if (ValidateCell(row - 1, col + 2, size))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            //horizontal down-right
            if(ValidateCell(row+2, col+1, size))
            {
                if (matrix[row +2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            //horizontal down-left
            if (ValidateCell(row + 2, col - 1, size))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            //horizontal right-down
            if (ValidateCell(row + 1, col + 2, size))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            //horizontal left-down
            if (ValidateCell(row + 1, col-2 , size))
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            return attackedKnights;
        }

        private static bool ValidateCell(int row, int col, int size)
        {
            return row>=0 && row<size && col>=0 && col<size;
        }
    }
}
