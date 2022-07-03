using System;

namespace _8.MathPow
{
    class Program
    {
        static void Main(string[] args)
        {
           double number1 = double.Parse(Console.ReadLine());
           double number2 = double.Parse(Console.ReadLine());
           Console.WriteLine(MathPower(number1,number2));
        }

        static double MathPower(double number1,double number2)
        {
            return Math.Pow(number1, number2);
        }
    }
}
