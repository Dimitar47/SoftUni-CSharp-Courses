using System;
using System.Numerics;

namespace _02.BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
         //   Console.WriteLine(PrintFactorial(n));


        }

        //private static BigInteger PrintFactorial(int n)
        //{
        //    if (n < 1)
        //    {
        //        return 1;
        //    }

        //    return n * PrintFactorial(n - 1);
        //}
    }
}
