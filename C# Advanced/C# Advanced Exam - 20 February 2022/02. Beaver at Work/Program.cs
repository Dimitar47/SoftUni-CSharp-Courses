using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _02._Beaver_at_Work
{
    internal class Program
    {
        private static int beaverRow = 0;
        private static int beaverCol = 0;
        private static char[,] pond;
        
        private static List<char> woodBranches = new List<char>(); // a collection of wood branches/lower letter (i.e.
                                                                   // every wood branch is a lower letter
        private static int totalBranches = 0;
        
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            pond = new char[size, size];
                                               
            for (int row = 0; row < size; row++)
            {
                char[] tokens= Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < tokens.Length; col++)
                {
                    pond[row, col] = tokens[col];
                    if (pond[row,col] == 'B')
                    {
                        //beaver[row,col] = '-';
                        beaverRow = row;
                        beaverCol = col;
                    }
                    else if (char.IsLower(pond[row, col]))
                    {

                        totalBranches++;
                       

                    }
                }

            }
            string command = "";
            while((command = Console.ReadLine())!="end" && totalBranches >0)
            {
                if (command == "up")
                {
                    Move(-1, 0,command);
                }
                else if (command == "down")
                {
                    Move(1, 0,command);
                }
                else if (command == "left")
                {
                   Move(0,-1,command);
                }
                else if (command == "right")
                {
                 Move(0,1,command);
                }
               
               
            }

            if (totalBranches >0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalBranches} branches left.");
                PrintMatrix(size, pond);
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {woodBranches.Count} wood branches: {string.Join(", ",woodBranches)}.");
                PrintMatrix(size, pond);
            }
        }
        private static void Move(int row, int col,string command)
        {
            if (isInside(beaverRow+row,beaverCol+col))
            {
                pond[beaverRow, beaverCol] = '-';
                beaverRow += row;
                beaverCol += col;
                if (pond[beaverRow,beaverCol] == 'F')
                {
                    pond[beaverRow, beaverCol] = '-';
                    if(command == "up")
                    {
                        if (beaverRow == 0)
                        {
                            if (char.IsLower(pond[pond.GetLength(0)-1, beaverCol]))
                            {
                                totalBranches--;
                                woodBranches.Add(pond[pond.GetLength(0)-1,beaverCol]);

                            }
                            beaverRow = pond.GetLength(0)-1;
                            pond[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {

                            if (char.IsLower(pond[0, beaverCol]))
                            {
                                totalBranches--;
                                woodBranches.Add(pond[0, beaverCol]);

                            }
                            beaverRow = 0;
                            pond[beaverRow, beaverCol] = 'B';
                        
                        }

                    }
                    else if (command == "down")
                    {
                        if (beaverRow == pond.GetLength(0)-1)
                        {
                            if (char.IsLower(pond[0, beaverCol]))
                            {
                                totalBranches--;
                                woodBranches.Add(pond[0, beaverCol]);

                            }
                            beaverRow = 0;
                            pond[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {

                            if (char.IsLower(pond[pond.GetLength(0)-1, beaverCol]))
                            {
                                totalBranches--;
                                woodBranches.Add(pond[pond.GetLength(0)-1, beaverCol]);

                            }
                            beaverRow = pond.GetLength(0)-1;
                            pond[beaverRow, beaverCol] = 'B';

                        }

                    }
                    else if(command=="left")
                    {
                        if (beaverCol == 0)
                        {
                            if (char.IsLower(pond[beaverRow, pond.GetLength(1)-1]))
                            {
                                totalBranches--;
                                woodBranches.Add(pond[beaverRow, pond.GetLength(1)-1]);

                            }
                            beaverCol = pond.GetLength(1)-1;
                            pond[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {

                            if (char.IsLower(pond[beaverRow, 0]))
                            {
                                totalBranches--;
                                woodBranches.Add(pond[beaverRow, 0]);

                            }
                            beaverCol = 0;
                            pond[beaverRow, beaverCol] = 'B';

                        }
                    }
                    else if(command== "right")
                    {
                        if (beaverCol == pond.GetLength(1)-1)
                        {
                            if (char.IsLower(pond[beaverRow, 0]))
                            {
                                totalBranches--;
                                woodBranches.Add(pond[beaverRow, 0]);

                            }
                            beaverCol = 0;
                            pond[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {

                            if (char.IsLower(pond[beaverRow, pond.GetLength(1)-1]))
                            {
                                totalBranches--;
                                woodBranches.Add(pond[beaverRow, pond.GetLength(1)-1]);

                            }
                            beaverCol = pond.GetLength(1)-1;
                            pond[beaverRow, beaverCol] = 'B';

                        }
                    }
                }
                else if (char.IsLower(pond[beaverRow, beaverCol]))
                {
                    
                    totalBranches--;
                    woodBranches.Add(pond[beaverRow,beaverCol]);
                    pond[beaverRow, beaverCol] = 'B';

                }
                else if (pond[beaverRow,beaverCol] == '-')
                {
                    pond[beaverRow, beaverCol] = 'B';
                }
            }
            else
            {
                if (woodBranches.Count > 0)
                {
                    woodBranches.RemoveAt(woodBranches.Count-1);
                }
            }
        }
        static bool isInside(int row, int col)
        {
            return row >= 0 && row < pond.GetLength(0) && col >= 0 && col < pond.GetLength(1);
        }
        static void PrintMatrix(int size, char[,]matrix)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
