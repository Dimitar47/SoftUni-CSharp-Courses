using System;

namespace _02._Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] playingField = new char[size, size];

            int moleRow = -1;
            int moleCol = -1;
            int firstSpecialRow = -1;
            int firstSpecialCol = -1;
            int secondSpecialRow = -1;
            int secondSpecialCol = -1;
            int countSpecials = 1;
            for (int row = 0; row < size; row++)
            {
                string tokens = Console.ReadLine();
                for (int col = 0; col < tokens.Length; col++)
                {
                    playingField[row, col] = tokens[col];
                    if (playingField[row, col] == 'M')
                    {
                        //Debugging purposes playingField[row, col] = '-';
                        moleRow = row;
                        moleCol = col;
                    }
                    if (playingField[row, col] == 'S' && countSpecials == 1)
                    {
                        firstSpecialRow = row;
                        firstSpecialCol = col;
                        countSpecials++;
                    }
                    else if (playingField[row, col] == 'S' && countSpecials == 2)
                    {
                        secondSpecialRow = row;
                        secondSpecialCol = col;
                    }



                }
            }
            string command = "";
            int points = 0;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "left")
                {
                    if (IsValid(moleRow, moleCol - 1, playingField))
                    {
                        playingField[moleRow, moleCol] = '-';
                        if (playingField[moleRow, moleCol - 1] == 'S')
                        {
                            playingField[moleRow, moleCol - 1] = '-';
                            if (firstSpecialRow == moleRow && firstSpecialCol == moleCol - 1)
                            {
                                moleRow = secondSpecialRow;
                                moleCol = secondSpecialCol;
                            }
                            else if (secondSpecialRow == moleRow && secondSpecialCol == moleCol - 1)
                            {
                                moleRow = firstSpecialRow;
                                moleCol = firstSpecialCol;
                            }
                            playingField[moleRow, moleCol] = 'M';
                            points -= 3;
                        }

                        else if (playingField[moleRow, moleCol - 1] != 'S' && playingField[moleRow, moleCol - 1] != '-')
                        {
                            points += int.Parse(playingField[moleRow, moleCol - 1].ToString());
                            playingField[moleRow, moleCol - 1] = 'M';
                            moleCol--;
                        }
                        else if (playingField[moleRow, moleCol - 1] == '-')
                        {
                            playingField[moleRow, moleCol - 1] = 'M';
                            moleCol--;
                        }


                    }
                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }
                else if (command == "right")
                {
                    if (IsValid(moleRow, moleCol + 1, playingField))
                    {
                        playingField[moleRow, moleCol] = '-';
                        if (playingField[moleRow, moleCol + 1] == 'S')
                        {
                            playingField[moleRow, moleCol + 1] = '-';
                            if (firstSpecialRow == moleRow && firstSpecialCol == moleCol + 1)
                            {
                                moleRow = secondSpecialRow;
                                moleCol = secondSpecialCol;
                            }
                            else if (secondSpecialRow == moleRow && secondSpecialCol == moleCol + 1)
                            {
                                moleRow = firstSpecialRow;
                                moleCol = firstSpecialCol;
                            }
                            playingField[moleRow, moleCol] = 'M';
                            points -= 3;
                        }

                        else if (playingField[moleRow, moleCol + 1] != 'S' && playingField[moleRow, moleCol + 1] != '-')
                        {
                            points += int.Parse(playingField[moleRow, moleCol + 1].ToString());
                            playingField[moleRow, moleCol + 1] = 'M';
                            moleCol++;
                        }
                        else if (playingField[moleRow, moleCol + 1] == '-')
                        {
                            playingField[moleRow, moleCol + 1] = 'M';
                            moleCol++;
                        }



                    }
                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }
                else if (command == "up")
                {
                    if (IsValid(moleRow - 1, moleCol, playingField))
                    {
                        playingField[moleRow, moleCol] = '-';
                        if (playingField[moleRow - 1, moleCol] == 'S')
                        {
                            playingField[moleRow - 1, moleCol] = '-';
                            if (firstSpecialRow == moleRow - 1 && firstSpecialCol == moleCol)
                            {
                                moleRow = secondSpecialRow;
                                moleCol = secondSpecialCol;
                            }
                            else if (secondSpecialRow == moleRow - 1 && secondSpecialCol == moleCol)
                            {
                                moleRow = firstSpecialRow;
                                moleCol = firstSpecialCol;
                            }
                            playingField[moleRow, moleCol] = 'M';
                            points -= 3;
                        }

                        else if (playingField[moleRow - 1, moleCol] != 'S' && playingField[moleRow - 1, moleCol] != '-')
                        {
                            points += int.Parse(playingField[moleRow - 1, moleCol].ToString());
                            playingField[moleRow - 1, moleCol] = 'M';
                            moleRow--;
                        }
                        else if (playingField[moleRow - 1, moleCol] == '-')
                        {
                            playingField[moleRow - 1, moleCol] = 'M';
                            moleRow--;
                        }


                    }
                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }
                else if (command == "down")
                {
                    if (IsValid(moleRow + 1, moleCol, playingField))
                    {
                        playingField[moleRow, moleCol] = '-';
                        if (playingField[moleRow + 1, moleCol] == 'S')
                        {
                            playingField[moleRow + 1, moleCol] = '-';
                            if (firstSpecialRow == moleRow + 1 && firstSpecialCol == moleCol)
                            {
                                moleRow = secondSpecialRow;
                                moleCol = secondSpecialCol;
                            }
                            else if (secondSpecialRow == moleRow + 1 && secondSpecialCol == moleCol)
                            {
                                moleRow = firstSpecialRow;
                                moleCol = firstSpecialCol;
                            }
                            playingField[moleRow, moleCol] = 'M';
                            points -= 3;
                        }

                        else if (playingField[moleRow + 1, moleCol] != 'S' && playingField[moleRow + 1, moleCol] != '-')
                        {
                            points += int.Parse(playingField[moleRow + 1, moleCol].ToString());
                            playingField[moleRow + 1, moleCol] = 'M';
                            moleRow++;
                        }
                        else if (playingField[moleRow + 1, moleCol] == '-')
                        {
                            playingField[moleRow + 1, moleCol] = 'M';
                            moleRow++;
                        }



                    }
                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }
                if (points >= 25)
                {
                    break;
                }

            }
            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }
            PrintMatrix(size, playingField);

        }

        static bool IsValid(int moleRow, int moleCol, char[,] playingField)
        {
            bool result = moleRow >= 0 && moleRow < playingField.GetLength(0)
                && moleCol >= 0 && moleCol < playingField.GetLength(1);
            return result;
        }

        static void PrintMatrix(int size, char[,] playingField)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{playingField[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}