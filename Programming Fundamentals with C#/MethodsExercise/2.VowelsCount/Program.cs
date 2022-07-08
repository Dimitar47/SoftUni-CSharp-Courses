using System;
using System.Linq;

namespace _2.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            CountVowels(text);
        }

        static void CountVowels(string text)
        {
            int count = 0;
            foreach (var vowel in text.Where(vowel => "aeiou".Contains(vowel)))
            {
                ;
                count++;
            }

            Console.WriteLine(count);
        }
    }
}
