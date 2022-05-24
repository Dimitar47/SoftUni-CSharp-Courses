using System;

namespace _3._Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            double difference = Math.Abs(number1 - number2);
            
            if (difference < eps)
            {
                Console.WriteLine("True");
            }
            else 
            {
                Console.WriteLine("False");
            }
           
        }
    }
}
