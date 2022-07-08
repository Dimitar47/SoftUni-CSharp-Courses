using System;

namespace _5.AddSubt
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());
            SumTwo(number1,number2);
            Console.WriteLine(SubtSumTwo(SumTwo(number1,number2),number3));

        }

        static int SumTwo(int number1, int number2)
        {
            return number1 + number2;
        }

        static int SubtSumTwo(int sum,int number3)
        {
            return sum - number3;
        }
    }
}
