using System;
using System.Drawing;
using System.Linq;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size,size];
            for (int row = 0; row < size; row++)
            {
                char[] truffles = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < truffles.Length; col++)
                {
                    matrix[row,col] = truffles[col];

                }

            }
            int blackTruffles = 0;
            int whiteTruffles = 0;
            int summerTruffles = 0;
            int trufflesEaten = 0;
            string command = "";
           
            while((command = Console.ReadLine())!="Stop the hunt")
            {
                string[] tokens = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
               
                if (action == "Collect")
                {

                    if (matrix[row, col] == 'B')
                    {
                        blackTruffles++;
                    }
                    else if (matrix[row, col] == 'S')
                    {
                        summerTruffles++;
                    }
                    else if (matrix[row, col] == 'W')
                    {
                        whiteTruffles++;

                    }
                    matrix[row, col] = '-';
                    
                  
                }
                else
                {
                    string direction = tokens[3];
                    if (direction == "up")
                    {
                        for (int i = row; i >=0; i -= 2)
                        {
                          
                            if (matrix[i, col] == 'B' || matrix[i, col] == 'S' || matrix[i, col] == 'W')
                            {
                                trufflesEaten++;
                            }
                            matrix[i, col] = '-';

                        }
                        
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i < matrix.GetLength(0); i += 2)
                        {
                            if (matrix[i, col] == 'B' || matrix[i, col] == 'S' || matrix[i, col] == 'W')
                            {
                                trufflesEaten++;
                            }
                     
                            matrix[i, col] = '-';
                        }
                     
                    }
                    else if (direction == "left")
                    {
                        for(int i = col; i >= 0; i -= 2)
                        {

                            if (matrix[row, i] == 'B' || matrix[row, i] == 'S' || matrix[row,i] == 'W')
                            {
                                trufflesEaten++;
                            }

                            matrix[row, i] = '-';

                        }
                       
                    }
                    else if (direction == "right")
                    {
                        for (int i = col; i < matrix.GetLength(0); i += 2)
                        {
                            if (matrix[row, i] == 'B' || matrix[row, i] == 'S' || matrix[row, i] == 'W')
                            {
                                trufflesEaten++;
                            }
                            matrix[row, i] = '-';
                        
                            
                        }
                        
                    }
                    
                }
            }
            Console.WriteLine($"Peter manages to harvest {blackTruffles} black, {summerTruffles} summer, and {whiteTruffles} white truffles.");
            Console.WriteLine($"The wild boar has eaten {trufflesEaten} truffles.");
            PrintMatrix(size, matrix);




        }

        

        static void PrintMatrix(int n, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

    }
}
