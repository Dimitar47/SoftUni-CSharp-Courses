using System;

namespace _06._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        char firstChar = (char)('a' + i);
                        char secondChar = (char)('a' +j);
                        char thirdChar = (char)('a' + k);
                        Console.Write(firstChar);
                        Console.Write(secondChar);
                        Console.Write(thirdChar);
                        Console.WriteLine();
                    }
                   
                }
              
            }
        }
    }
}
