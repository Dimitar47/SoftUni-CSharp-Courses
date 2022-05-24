using System;

namespace _05._Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string decrypted = "";
            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                letter = (char)(letter + key);
                decrypted += letter;
            }
            Console.WriteLine(decrypted);
        }
    }
}
