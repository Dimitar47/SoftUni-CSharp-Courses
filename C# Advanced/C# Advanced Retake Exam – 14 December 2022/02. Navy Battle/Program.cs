namespace _02._Navy_Battle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] battleField = new char[size,size];
            int submarineRow = -1;
            int submarineCol = -1;   
            for (int row = 0; row < size; row++)
            {
                string tokens = Console.ReadLine();
                for (int col = 0; col < tokens.Length; col++)
                {
                    battleField[row, col] = tokens[col];
                    if (battleField[row,col] == 'S')
                    {
                        
                        submarineRow = row;
                        submarineCol = col;
                    }
                }

            }
            int minesHit = 0;
            int cruisersDestroyed = 0;
            while (minesHit<3 && cruisersDestroyed<3)
            {
                string direction= Console.ReadLine();
                if (direction == "left")
                {
                  

                       
                            battleField[submarineRow, submarineCol] = '-';
                           
                        
                         if (battleField[submarineRow, submarineCol - 1] == '*')
                        {
                            minesHit++;
                            battleField[submarineRow, submarineCol - 1] = '-';

                        }
                        else if (battleField[submarineRow, submarineCol - 1] == 'C')
                        {
                            cruisersDestroyed++;
                            battleField[submarineRow, submarineCol - 1] = '-';
                        }
                        submarineCol--;
                      
                    
                }
                else if(direction == "right")
                {
                   

                       
                            battleField[submarineRow, submarineCol] = '-';
                        
                       
                         if (battleField[submarineRow, submarineCol + 1] == '*')
                        {
                            minesHit++;
                            battleField[submarineRow, submarineCol + 1] = '-';

                        }
                        else if (battleField[submarineRow, submarineCol + 1] == 'C')
                        {
                            cruisersDestroyed++;
                            battleField[submarineRow, submarineCol + 1] = '-';
                        }
                        submarineCol++;
                     
                    
                }
                else if(direction == "up")
                {
                   

                        
                            battleField[submarineRow, submarineCol] = '-';
                     
                            
                         if (battleField[submarineRow-1, submarineCol] == '*')
                        {
                            minesHit++;
                            battleField[submarineRow-1, submarineCol] = '-';

                        }
                        else if (battleField[submarineRow-1, submarineCol] == 'C')
                        {
                            cruisersDestroyed++;
                            battleField[submarineRow-1, submarineCol] = '-';
                        }
                        
                        submarineRow--;
                    
                }
                else if (direction == "down")
                {
                   
                        
                            battleField[submarineRow, submarineCol] = '-';
                          
                          
                        
                        if (battleField[submarineRow + 1, submarineCol] == '*')
                        {
                            minesHit++;
                            battleField[submarineRow + 1, submarineCol] = '-';

                        }
                        else if (battleField[submarineRow + 1, submarineCol] == 'C')
                        {
                            cruisersDestroyed++;
                            battleField[submarineRow + 1, submarineCol] = '-';
                        }
                        submarineRow++;
                       
                    
                }
            }
            if (minesHit == 3)
            {
              
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
            }
            else if(cruisersDestroyed==3)
            {
               
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
            }
            battleField[submarineRow, submarineCol] = 'S';
            PrintMatrix(battleField, size);
        }
        
      

        static void PrintMatrix(char[,] battleField, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{battleField[row,col]}");
                }
                Console.WriteLine();
            }
        }
    }
}