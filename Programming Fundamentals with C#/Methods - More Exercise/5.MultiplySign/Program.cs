using System;

namespace _5.MultiplySign
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());
            PrintSign(number1,number2,number3);
        }

        static void PrintSign(int number1, int number2, int number3)
        {
            if (number1 == 0 || number2 == 0 || number3 == 0)
            {
                Console.WriteLine("zero");
            }

            if ((number1 > 0 && number2 > 0 && number3 > 0) || (number1 < 0 && number2 < 0 && number3 > 0) || (number1<0 && number3<0 && number2>0) || 
                (number2<0 && number3<0 && number1>0 ))

            {
                Console.WriteLine("positive");
            }
            else if((number1<0 && number2<0 && number3<0) ||(number1<0 && number2>0 && number3>0) || (number2<0 && number3>0 && number1>0) || 
                    (number3<0 && number1>0 && number2>0) )
            {
                Console.WriteLine("negative");
            }
            
        }
    }
}
