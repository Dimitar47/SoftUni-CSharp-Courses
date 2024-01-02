using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace _02._SecondTask
{
    internal class Program
    {
        private static char[,] cupboard;
        private static int mouseRow = -1;
        private static int mouseColumn = -1;
        private static int countCheese = 0;
        static void Main(string[] args)
        {

            int[] dimensions =Console.ReadLine().Split(",",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            cupboard = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string tokens = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    cupboard[row, col] = tokens[col];
                    if (cupboard[row,col] == 'M')
                    {
                        mouseRow = row;
                        mouseColumn = col;
                    }
                    else if (cupboard[row,col] == 'C')
                    {
                        countCheese++;
                    }
                }
               
            }
            string command = "";
            while((command=Console.ReadLine())!="danger")
            {
             
                int currRow;
                int currCol;
               

                if (command == "up")
                {
                    if (isInside(mouseRow - 1, mouseColumn))
                    {
                        currRow = -1;
                        currCol = 0;
                        if (cupboard[mouseRow+currRow, mouseColumn + currCol]== '@')
                        {
                            continue;
                        }
                        cupboard[mouseRow, mouseColumn] = '*';
                        mouseRow += currRow;
                        mouseColumn += currCol;
                        if (cupboard[mouseRow, mouseColumn] == 'T')
                        {
                            cupboard[mouseRow, mouseColumn] = 'M';
                            Console.WriteLine($"Mouse is trapped!");
                            break;
                        }
                        else if (cupboard[mouseRow, mouseColumn] == 'C')
                        {
                            countCheese--;
                            cupboard[mouseRow, mouseColumn] = 'M';
                            if (countCheese == 0)
                            {
                              
                                break;
                            }
                        }
                        else if (cupboard[mouseRow,mouseColumn] == '*')
                        {
                            cupboard[mouseRow, mouseColumn] = 'M';
                        }
                    }
                    else
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        
                        break;
                    }
                }
                else if (command == "down")
                {
                    if(isInside(mouseRow+1, mouseColumn))
                    {
                        currRow = 1;
                        currCol = 0;
                        if (cupboard[mouseRow + currRow, mouseColumn + currCol] == '@')
                        {
                            continue;
                        }
                        cupboard[mouseRow, mouseColumn] = '*';
                        mouseRow += currRow;
                        mouseColumn += currCol;
                        if (cupboard[mouseRow, mouseColumn] == 'T')
                        {
                            cupboard[mouseRow, mouseColumn] = 'M';
                            Console.WriteLine($"Mouse is trapped!");
                            break;
                        }
                        else if (cupboard[mouseRow, mouseColumn] == 'C')
                        {
                            countCheese--;
                            cupboard[mouseRow, mouseColumn] = 'M';
                            if (countCheese == 0)
                            {
                              
                                break;
                            }
                        }
                        else if (cupboard[mouseRow, mouseColumn] == '*')
                        {
                            cupboard[mouseRow, mouseColumn] = 'M';
                        }
                    }
                    else
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                }
                else if (command == "left")
                {
                    if(isInside(mouseRow, mouseColumn-1))
                    {
                        currRow = 0;
                        currCol = -1;
                        if (cupboard[mouseRow + currRow, mouseColumn + currCol] == '@')
                        {
                            continue;
                        }
                        cupboard[mouseRow, mouseColumn] = '*';
                        mouseRow += currRow;
                        mouseColumn += currCol;
                        if (cupboard[mouseRow, mouseColumn] == 'T')
                        {
                            cupboard[mouseRow, mouseColumn] = 'M';
                            Console.WriteLine($"Mouse is trapped!");
                            break;
                        }
                        else if (cupboard[mouseRow, mouseColumn] == 'C')
                        {
                            countCheese--;
                            cupboard[mouseRow, mouseColumn] = 'M';
                            if (countCheese == 0)
                            {
                              
                                break;
                            }
                        }
                        else if (cupboard[mouseRow, mouseColumn] == '*')
                        {
                            cupboard[mouseRow, mouseColumn] = 'M';
                        }
                    }
                    else
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                }
                else if (command == "right")
                {
                    if (isInside(mouseRow, mouseColumn +1))
                    {
                        currRow = 0;
                        currCol = 1;
                        if (cupboard[mouseRow + currRow, mouseColumn + currCol] == '@')
                        {
                            continue;
                        }
                        cupboard[mouseRow, mouseColumn] = '*';
                        mouseRow += currRow;
                        mouseColumn += currCol;
                        if (cupboard[mouseRow, mouseColumn] == 'T')
                        {
                            cupboard[mouseRow, mouseColumn] = 'M';
                            Console.WriteLine($"Mouse is trapped!");
                            break;
                        }
                        else if (cupboard[mouseRow, mouseColumn] == 'C')
                        {
                            countCheese--;
                            cupboard[mouseRow, mouseColumn] = 'M';
                            if (countCheese == 0)
                            {
                              
                                break;
                            }
                        }
                        else if (cupboard[mouseRow, mouseColumn] == '*')
                        {
                            cupboard[mouseRow, mouseColumn] = 'M';
                        }

                    }
                    else
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                }
               
            }
            if (countCheese == 0)
            {
                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
            }
            if (command == "danger" && countCheese!=0)
            {
                cupboard[mouseRow, mouseColumn] = 'M';
                Console.WriteLine($"Mouse will come back later!");

               
            }

            PrintMatrix(rows, cols);




        }

       

        private static bool isInside(int row, int col)
        {
            return row >= 0 && row < cupboard.GetLength(0) && col >= 0 && col < cupboard.GetLength(1);
        }

        private static void PrintMatrix(int rows,int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(cupboard[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}