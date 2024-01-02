using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder characters = new StringBuilder();
            for(int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                {
                    digits.Append(text[i]);
                }
                else if (Char.IsLetter(text[i]))
                {
                    letters.Append(text[i]);
                }
                else
                {
                    characters.Append(text[i]);
                }

            }
            Console.WriteLine(digits.ToString());
            Console.WriteLine(letters.ToString());
            Console.WriteLine(characters.ToString());
        }
    }
}
