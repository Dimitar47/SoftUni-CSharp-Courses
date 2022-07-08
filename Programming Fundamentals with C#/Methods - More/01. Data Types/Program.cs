using System;

namespace _01._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "int":
                    int intNumber = int.Parse(Console.ReadLine());
                    GetInput(intNumber);
                    break;
                case "real":
                    double doubleNumber = double.Parse(Console.ReadLine());
                    GetInput(doubleNumber);
                    break;
                case "string":
                    string text = Console.ReadLine();
                    GetInput(text);
                    break;
            }
        }

        static void GetInput(int number)
        {
            Console.WriteLine(number * 2);
        }

        static void GetInput(double number)
        {
            Console.WriteLine($"{number * 1.5:F2}");
        }

        static void GetInput(string input)
        {
            Console.WriteLine($"${input}$");
        }
    }
}
