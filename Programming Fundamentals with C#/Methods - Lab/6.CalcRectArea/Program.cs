using System;

namespace _6.CalcRectArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            Console.WriteLine(getRectArea(number1,number2));
        }

        static double getRectArea(double number1, double number2)
        {
            return number1 * number2;
        }
    }
}
