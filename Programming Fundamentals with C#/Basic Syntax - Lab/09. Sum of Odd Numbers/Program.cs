using System;

namespace _09._Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            Console.WriteLine(1);
            
            for(int i = 1; i < n; i ++)
            {
              
                Console.WriteLine(i*2+1);
                sum += i * 2 + 1;

            }
            Console.WriteLine("Sum: {0}",sum+1);
        }
    }
}
