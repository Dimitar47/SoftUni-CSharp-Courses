using System;


namespace _3.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            if (command =="multiply")
            {
                Console.WriteLine(Multiply(number1, number2));
            }
            else if (command == "add")
            {
                Console.WriteLine(Add(number1,number2));
            }else if (command == "subtract")
            {
                Console.WriteLine(Substract(number1,number2));
            }
            else
            {
                Console.WriteLine(Divide(number1,number2));
            }
        }

        static int Multiply(int number1, int number2)
        {
            return number1 * number2;
        } 
        static int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        static int Substract(int number1, int number2)
        {
            return number1 - number2;
        }

        static int Divide(int number1, int number2)
        {
            return number1 / number2;
        }
    }
}
