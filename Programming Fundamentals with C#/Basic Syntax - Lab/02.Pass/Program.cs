using System;

namespace _02.Pass
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            string result = grade >= 3.00 ? "Passed!" : "";
            Console.Write(result);
        }
    }
}
