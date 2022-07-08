using System;

namespace _03.CharRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char char1 = Char.Parse(Console.ReadLine());
            char char2 = Char.Parse(Console.ReadLine());
          
          PrintChars(char1,char2);
        }

       private static void PrintChars(char char1, char char2)
        {
            int value1 = char1;
            int value2 = char2;
                if (value2 < value1)
                {
                    for (int i = value2 + 1; i < value1; i++)
                    {
                        Console.Write((char)i + " ");
                    }
                }

                else
                {
                    for (int i = value1 + 1; i < value2; i++)
                    {
                        Console.Write((char)i + " ");
                    }
                }
        }

    }
}
