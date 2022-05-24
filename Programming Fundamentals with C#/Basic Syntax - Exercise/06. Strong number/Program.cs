using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int copyNumber = number;

            int n = 0;
            int factorialSum = 0;

            while (number != 0)
            {
                n = number % 10;
                number = number / 10;

                int factorial = 1;
                for (int i = 1; i <= n; i++)
                {
                    factorial = factorial * i;
                }
                factorialSum = factorialSum + factorial;
                
            }
               
            if(factorialSum == copyNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

            
          
         
     

        }
    }
}
