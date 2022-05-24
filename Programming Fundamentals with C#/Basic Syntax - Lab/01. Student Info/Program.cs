using System;

namespace Basic_Syntax__Conditional_Statements_and_Loops___Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = Convert.ToInt32(Console.ReadLine());
            double grade = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Name: {name}, Age: {age}, Grade: {grade:F2}");
        }
    }
}
