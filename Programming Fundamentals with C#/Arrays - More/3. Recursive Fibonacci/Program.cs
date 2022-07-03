using System;

namespace _3._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
           
            

            Console.WriteLine(Fact(number));
           

        }

        public static long Fact(int n)
        {


            if (n <= 2)
            {
                return 1;
            }
            return Fact(n - 1) + Fact(n - 2);
        }



        //static void Main(string[] args)
        //{
        //    int n = int.Parse(Console.ReadLine());

        //    Console.WriteLine(getFibonacci(n, new Dictionary<int, long>()));
        //}

        //private static long getFibonacci(int n, Dictionary<int, long> dict)
        //{
        //    if (n == 1 || n == 2)
        //        return 1;
        //    else
        //    {
        //        if (dict.ContainsKey(n))
        //        {
        //            return dict[n];
        //        }
        //        else
        //        {
        //            dict.Add(n, getFibonacci(n - 1, dict) + getFibonacci(n - 2, dict));
        //            return (getFibonacci(n - 1, dict) + getFibonacci(n - 2, dict));
        //        }
        //    }

        //}
    }
}
