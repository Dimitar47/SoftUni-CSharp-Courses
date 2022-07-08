using System;

namespace _1._Smallest
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());
            Console.WriteLine(PrintSmallest(number1,number2,number3));
        }

        static int PrintSmallest(int number1, int number2, int number3)
        {
            int smallestNum = Math.Min(Math.Min(number1,number2),number3);
            return smallestNum;
        }
    }
}
