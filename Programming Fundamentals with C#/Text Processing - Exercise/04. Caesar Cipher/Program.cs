using System;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string encrypt = "";
           for(int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];
                currentChar += (char)3;
                encrypt += currentChar;
            }
            Console.WriteLine(encrypt);
        }
    }
}
