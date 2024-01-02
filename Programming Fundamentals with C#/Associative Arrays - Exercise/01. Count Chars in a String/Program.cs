using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            
            List<char> characters = new List<char>();
            for (int i = 0; i < command.Length; i++)
            {
                characters.Add(command[i]);
            }
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
           foreach(char character in characters)
            {
                if (dictionary.ContainsKey(character))
                {
                    dictionary[character]++;
                }
                else 
                {
                    if(character != ' ')
                    dictionary.Add(character, 1);
                }
            }
           foreach(var dictionar in dictionary)
            {

                Console.WriteLine($"{dictionar.Key} -> {dictionar.Value}");
            }
























            //string input = Console.ReadLine();
            //Dictionary<char, int> dictionary = new Dictionary<char, int>();
            //for (int i = 0; i < input.Length; i++)
            //{
            //    if (input[i] == ' ')
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        if (dictionary.ContainsKey(input[i]))
            //        {
            //            dictionary[input[i]]++;
            //        }
            //        else
            //        {
            //            dictionary.Add(input[i], 1);
            //        }
            //    }

            //}
            //foreach (var item in dictionary)
            //{
            //    Console.WriteLine($"{item.Key} -> {item.Value}");
            //}
        }
    }
}
