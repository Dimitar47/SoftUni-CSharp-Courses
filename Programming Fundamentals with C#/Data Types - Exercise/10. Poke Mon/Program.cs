using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());
            double fiftyPercent = 0.5 * N;
            int countTarget = 0;
            while (N >= M) 
            {
                N -= M;
                countTarget++;
                if (N == fiftyPercent && Y!=0)
                {
                        N /= Y;                 
                }    
            }
            Console.WriteLine(N);
            Console.WriteLine(countTarget);
        }
    }
}
