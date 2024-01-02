using System;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] wall = new char[size, size];
            int vankoRow = -1;
            int vankoCol = -1;   
            for (int row = 0; row < size; row++)
            {
                string tokens = Console.ReadLine();
                for (int col = 0; col < tokens.Length; col++)
                {
                    wall[row, col] = tokens[col];
                    if (wall[row,col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                      
                      
                        
                    }
                }
            }
          
            int holesMade = 1;
            int rodsHit = 0;
            
            string command = "";
            while((command = Console.ReadLine()) != "End")
            {
                
                if (command == "left")
                {
                    if (IsValid(vankoRow, vankoCol-1, wall))
                    {
                        if (wall[vankoRow, vankoCol-1] == '-')
                        {
                            wall[vankoRow, vankoCol] = '*';
                            wall[vankoRow, vankoCol-1] = 'V';
                            vankoCol--;
                            holesMade++;

                        }
                        else if (wall[vankoRow, vankoCol-1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol-1}]!");
                            wall[vankoRow, vankoCol] = '*';
                            vankoCol--;
                            wall[vankoRow, vankoCol] = 'V';
                        }
                        else if (wall[vankoRow, vankoCol-1] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodsHit++;

                        }
                        else if (wall[vankoRow, vankoCol-1] == 'C')
                        {
                            wall[vankoRow, vankoCol-1] = 'E';
                            wall[vankoRow, vankoCol] = '*';
                            holesMade++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                            PrintMatrix(size, wall);
                            return;

                        }
                      
                    }
                }
                else if(command == "right")
                {
                    if (IsValid(vankoRow, vankoCol + 1, wall))
                    {
                        if (wall[vankoRow, vankoCol + 1] == '-')
                        {
                            wall[vankoRow, vankoCol] = '*';
                            wall[vankoRow, vankoCol + 1] = 'V';
                            vankoCol++;
                            holesMade++;

                        }
                        else if (wall[vankoRow, vankoCol + 1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol + 1}]!");
                            wall[vankoRow, vankoCol] = '*';
                            vankoCol++;
                            wall[vankoRow, vankoCol] = 'V';
                        }
                        else if (wall[vankoRow, vankoCol + 1] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodsHit++;

                        }
                        else if (wall[vankoRow, vankoCol + 1] == 'C')
                        {
                            wall[vankoRow, vankoCol + 1] = 'E';
                            wall[vankoRow, vankoCol] = '*';
                            holesMade++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                            PrintMatrix(size, wall);
                            return;

                        }
                    }
                }
                else if (command == "down")
                {
                    if(IsValid(vankoRow+1,vankoCol,wall))
                    {
                        if (wall[vankoRow+1,vankoCol] == '-')
                        {
                            wall[vankoRow, vankoCol] = '*';
                            wall[vankoRow + 1, vankoCol] = 'V';
                            vankoRow++;
                            holesMade++;

                        }
                        else if (wall[vankoRow + 1, vankoCol]== '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow+1}, {vankoCol}]!");
                            wall[vankoRow, vankoCol] = '*';
                            vankoRow++;
                            wall[vankoRow, vankoCol] = 'V';
                        }
                        else if (wall[vankoRow+1,vankoCol] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodsHit++;
                            
                        }
                        else if (wall[vankoRow+1,vankoCol] == 'C')
                        {
                            wall[vankoRow + 1, vankoCol] = 'E';
                            wall[vankoRow, vankoCol] = '*';
                            holesMade++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                            PrintMatrix(size, wall);
                            return;

                        }
                        
                    }
                }
                else if(command == "up")
                {
                    if (IsValid(vankoRow - 1, vankoCol, wall))
                    {
                        if (wall[vankoRow - 1, vankoCol] == '-')
                        {
                            wall[vankoRow, vankoCol] = '*';
                            wall[vankoRow - 1, vankoCol] = 'V';
                            vankoRow--;
                            holesMade++;

                        }
                        else if (wall[vankoRow - 1, vankoCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow - 1}, {vankoCol}]!");
                            wall[vankoRow, vankoCol] = '*';
                            vankoRow--;
                            wall[vankoRow, vankoCol] = 'V';
                        }
                        else if (wall[vankoRow - 1, vankoCol] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodsHit++;

                        }
                        else if (wall[vankoRow - 1, vankoCol] == 'C')
                        {
                            wall[vankoRow - 1, vankoCol] = 'E';
                            wall[vankoRow, vankoCol] = '*';
                            holesMade++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                            PrintMatrix(size, wall);
                            return;

                        }
                        
                    }
                }
                
            }
            Console.WriteLine($"Vanko managed to make {holesMade} hole(s) and he hit only {rodsHit} rod(s).");
            PrintMatrix(size, wall);

        }

         static bool IsValid(int vankoRow, int vankoCol, char[,] wall)
        {
            bool result = vankoRow >= 0 && vankoRow < wall.GetLength(0) &&
                vankoCol >= 0 && vankoCol < wall.GetLength(1);
            return result;
        }

        static void PrintMatrix(int size, char[,] wall)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{wall[row,col]}");
                }
                Console.WriteLine();
            }
        }
        
    }
}
