using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Products
{
    class Program
    {
        static void Main(string[] args)
        {



            //int n = int.Parse(Console.ReadLine());
            //string sum = "";
            //for (int i = 0; i < n; i++)
            //{



            //    string number = Console.ReadLine();
            //    int length = number.Length;
            //    int mainD = int.Parse(number) % 10;
            //    int offset = (mainD - 2) * 3;
            //    if (mainD == 0)
            //    {
            //        offset -= 59;
            //    }
            //    if (mainD == 8 || mainD == 9)
            //    {
            //        offset += 1;
            //    }
            //    int digitIndex = offset + length - 1;
            //    char letter = (char)(digitIndex + 'a');
            //    sum += letter;
            //}
            //Console.WriteLine(sum);





            string[][] smsTable = new string[][]
            {
                new string[] { " " },
                new string[] { },
                new string[] { "a", "b", "c" },
                new string[] { "d", "e", "f" },
                new string[] { "g", "h", "i" },
                new string[] { "j", "k", "l" },
                new string[] { "m", "n", "o" },
                new string[] { "p", "q", "r", "s" },
                new string[] { "t", "u", "v" },
                new string[] { "w", "x", "y", "z" }
            };
            int n = int.Parse(Console.ReadLine());
            string sum = "";
            for (int i = 0; i < n; i++)
            {
                int charCode = int.Parse(Console.ReadLine());
                sum += smsTable[charCode % 10][charCode.ToString().Length - 1];
            }

            Console.WriteLine(sum);
















            //int characterCount = int.Parse(Console.ReadLine());
            //string outputSms = "";
            //for (int i = 0; i < characterCount; i++)
            //{
            //    int charCode = int.Parse(Console.ReadLine());
            //    outputSms += smsTable[charCode % 10][charCode.ToString().Length - 1];
            //}
            //Console.WriteLine(outputSms);

        }
    }
}
