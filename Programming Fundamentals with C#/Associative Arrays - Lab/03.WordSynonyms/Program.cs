using System;
using System.Collections.Generic;

namespace _03.WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (dictionary.ContainsKey(word) == false)
                {
                    dictionary.Add(word, new List<string>());
                }
                
                    dictionary[word].Add(synonym);
                
            }
            foreach (var dictionar in dictionary)
            {
                Console.WriteLine($"{dictionar.Key} - {string.Join(", ",dictionar.Value)}");
            }
        }
    }
}
