using System;

namespace _02._Armory
{
    internal class Program
    {
        private static char[,] armory;
        private static int officerRow;
        private static int officerCol;
        private static int goldCoins = 0;
        private static bool result = true;
        private static int firstMirrorRow = 0;
        private static int firstMirrorCol = 0;
        private static int secondMirrorRow = 0;
        private static int secondMirrorCol = 0;
        private static int countMirrors = 0;
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            armory = new char[size,size];
            for (int row = 0; row < size; row++)
            {
                string tokens = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    armory[row, col] = tokens[col];
                    if (armory[row,col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                    if (armory[row,col] == 'M' && IsFirstMirror(countMirrors))
                    {
                        firstMirrorRow = row; 
                        firstMirrorCol = col;
                        countMirrors++;
                    }
                    else if (armory[row,col] == 'M' && !IsFirstMirror(countMirrors))
                    {
                        secondMirrorRow = row;
                        secondMirrorCol = col;
                    }
                        
                }
            }
            string command = "";
            while (goldCoins<65 && result)
            {
                command = Console.ReadLine();
                if (command == "up")
                {
                    Move(-1, 0);
                }
                else if (command == "down")
                {
                    Move(1, 0);
                }
                else if (command == "left")
                {
                    Move(0, -1);
                }
                else if (command == "right")
                {
                    Move(0, 1);
                }
            }
            if (!result)
            {
                armory[officerRow, officerCol] = '-';
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {goldCoins} gold coins.");
            PrintMatrix(size);
        }
        //1,1
        //3,0

        private static bool IsFirstMirror(int countMirrors)
        {
            return countMirrors == 0;
        }

        private static bool Move(int row, int col)
        {
            result = isInside(officerRow + row, officerCol + col);
            
            if (result)
            {
                armory[officerRow, officerCol] = '-';
                officerRow += row;
                officerCol += col;
                if (char.IsDigit(armory[officerRow, officerCol]))
                {
                    goldCoins += int.Parse(armory[officerRow, officerCol].ToString());
                    armory[officerRow, officerCol] = 'A';
                }
                else if (armory[officerRow,officerCol] == 'M')
                {
                    if (officerRow == firstMirrorRow && officerCol == firstMirrorCol)
                    {
                        armory[officerRow, officerCol] = '-';
                        officerRow = secondMirrorRow;
                        officerCol = secondMirrorCol;
                        armory[officerRow, officerCol] = 'A';
                    }
                    else if(officerRow == secondMirrorRow && officerCol == secondMirrorCol)
                    {
                        armory[officerRow, officerCol] = '-';
                        officerRow = firstMirrorRow;
                        officerCol = firstMirrorCol;
                        armory[officerRow, officerCol] = 'A';
                    }
                }
                else if (armory[officerRow,officerCol] == '-')
                {
                    armory[officerRow, officerCol] = 'A';
                }
                
            }
            return result;
            
        }

        private static bool isInside(int row, int col)
        {
            return row >= 0 && row < armory.GetLength(0) && col >= 0 && col < armory.GetLength(1);
        }

        private static void PrintMatrix(int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(armory[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
