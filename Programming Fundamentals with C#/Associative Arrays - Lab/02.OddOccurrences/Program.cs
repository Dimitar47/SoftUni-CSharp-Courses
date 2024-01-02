using System;
using System.Linq;
using System.Collections.Generic;
namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split().ToList();
            var dictionaries = new Dictionary<string, int>();
            var newList = new List<string>();
            foreach(string word in words)
            {
                string wordToLowerCase = word.ToLower();
                if (dictionaries.ContainsKey(wordToLowerCase))
                {
                  
                    dictionaries[wordToLowerCase]++;
                    
                }
                else
                {
                    dictionaries.Add(wordToLowerCase, 1);
                    
                }
            }
           foreach(var dictionary in dictionaries)
            {
                if (dictionary.Value % 2 != 0)
                {
                    Console.Write(dictionary.Key + " ");
                }
            }
        }
    }
}
