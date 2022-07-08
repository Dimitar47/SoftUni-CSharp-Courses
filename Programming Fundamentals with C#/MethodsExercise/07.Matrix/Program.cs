using System;


namespace _07.Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintMatrix(n);
            
        }

        static void PrintMatrix(int n)
        {
           
           
                for (int i = 0; i < n; i++) //rows
                {
                    for (int j = 0; j < n; j++)
                    {
                       
                            Console.Write(n + " ");
                        
                    }

                    Console.WriteLine();
                  
                }

            
        }

        
    }
}
