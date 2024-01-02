using System;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string textN1 = Console.ReadLine();

            string result = string.Empty;
            int number2 = int.Parse(Console.ReadLine());
            if (number2 == 0)
            {
                Console.WriteLine(0);
                return;
            }
            int ostatak = 0;
            for (int i = textN1.Length - 1; i >= 0; i--)
            {
                int currentNumber = int.Parse(textN1[i].ToString());
                int multi = (number2 * currentNumber) + ostatak;
                result += multi % 10;
                ostatak = multi / 10;
            }
            if (ostatak != 0)
            {
                result += ostatak;
            }

            for (int i = result.Length - 1; i >= 0; i--)
            {
                Console.Write(result[i]);
            }

            Console.WriteLine();

        }
    }
}
