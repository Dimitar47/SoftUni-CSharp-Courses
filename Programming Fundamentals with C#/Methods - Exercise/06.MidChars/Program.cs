using System;

namespace _06.MidChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            MidChars(text);
        }

        static string MidChars(string text)
        {
            string newText = "";
            if (text.Length % 2 != 0)
            {
                Console.WriteLine(text[text.Length/2]);
            }
            else
            {
                for (int i = text.Length / 2 - 1; i <= text.Length / 2; i++)
                {
                    newText += text[i];
                }

                Console.WriteLine(newText);
            }
            return text;
        }
    }
}
