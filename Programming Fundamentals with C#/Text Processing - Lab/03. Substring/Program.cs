using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            while (text.Contains(word))
            {
                int indexOf = text.IndexOf(word);
                text = text.Remove(indexOf, word.Length);
            }
            Console.WriteLine(text);
        }
    }
}