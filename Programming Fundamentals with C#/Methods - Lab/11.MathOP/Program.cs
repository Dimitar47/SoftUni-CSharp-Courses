using System;

namespace _11.MathOP
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            char sign = char.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            Console.WriteLine(Result(number1,sign,number2));
        }

        private static double Result(double number1, char sign, double number2)
        {
            double result = 0;
            if (sign == '+')
            {
                result = number1 + number2;
            }
            else if (sign == '-')
            {
                result = number1 - number2;
            }
            else if (sign == '*')
            {
                result = number1 * number2;
            }
            else if (sign == '/')
            {
                result = number1 / number2;
            }

            return result;
        }
    }
}
