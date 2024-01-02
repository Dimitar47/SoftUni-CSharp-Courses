using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] text = Console.ReadLine().Split();
            Random random = new Random();
            for (int i = 0; i < text.Length; i++)
            {
                int currentNumber = i;
               int randomPosition =  random.Next(0, text.Length);
                string temp = text[currentNumber];
               text[currentNumber] = text[randomPosition];
                text[randomPosition] = temp;
         
            }
            Console.WriteLine(string.Join(Environment.NewLine, text));


        }
    }
}
