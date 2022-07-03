using System;

namespace _4.PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintingTriangle(int.Parse(Console.ReadLine()));

        }

        static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }

        static void PrintingTriangle(int n)
        {
            for (int line = 1; line <= n; line++)
                PrintLine(1,line);
            for (int line = n-1; line >= 1; line--)
                PrintLine(1,line);
        }


        //static void PrintTriangle(int n)
        //{
        //    for (int i = 1; i <= n; i++)
        //    {
        //        for (int j = 1; j <= i; j++)
        //        {
        //            Console.Write("{0} ", j);
        //        }

        //        Console.WriteLine();
        //    }


        //    for (int i = 1; i <= n - 1; i++)
        //    {



        //        for (int j = 1; j <= n - i; j++)
        //        {

        //            Console.Write("{0} ", j);

        //        }

        //        Console.WriteLine();
        //    }


    }
}
