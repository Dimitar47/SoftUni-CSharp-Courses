using System;

namespace _04._Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string something = Console.ReadLine();
            string reversed = string.Empty;
            for (int i = something.Length-1; i >= 0; i--)
            {
                reversed = something[i].ToString();
                Console.Write(reversed);
            }
        }
    }
}
