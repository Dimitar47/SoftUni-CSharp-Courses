using System;

namespace _9.Great2Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            if (command =="int")
            {
                int number1 = int.Parse(Console.ReadLine());
                int number2 = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(number1,number2));
            }else if (command == "char")
            {
                char char1 = char.Parse(Console.ReadLine());
                char char2 = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(char1,char2));
            }
            else if(command == "string")
            {
                string str1 = Console.ReadLine();
                string str2 = Console.ReadLine();
                Console.WriteLine(GetMax(str1,str2));
            }
        }

        static int GetMax(int number1, int number2)
        {
            return number1 > number2 ? number1 : number2;
        }

        static string GetMax(string str1, string str2)
        {
            int comparison = str1.CompareTo(str2);
            //int sum1 = 0;
            //foreach (var t in str1)
            //{
            //    sum1 += t;
            //}

            //int sum2 = 0;
            //foreach (var t in str2)
            //{
            //    sum2 += t;
            //}
            return comparison > 0 ? str1 : str2;


            //return sum1>sum2 ? str1 : str2;
        }

        static char GetMax(char char1, char char2)
        {
            return char1 > char2 ? char1 : char2;
        }
    }
}
