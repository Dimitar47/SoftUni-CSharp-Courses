using System;

namespace _01._Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());
            int number4 = int.Parse(Console.ReadLine());
            int add = number1 + number2;
            int divide = add / number3;
            int multiply = divide * number4;

            
            Console.WriteLine($"{multiply}");
        }
    }
}
