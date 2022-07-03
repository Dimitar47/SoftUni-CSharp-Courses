using System;

namespace _00.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
           PrintTriangle(int.Parse(Console.ReadLine()));


        }
        static void PrintTriangle(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("{0} ", j);
                }

                Console.WriteLine();
            }

            
            for (int i = 1; i <= n-1; i++)
            {
               
                

                for (int j = 1; j <= n-i; j++)
                {
                    
                    Console.Write("{0} ", j);
                    
                }
                
                Console.WriteLine();
            }

        }

    }
}
