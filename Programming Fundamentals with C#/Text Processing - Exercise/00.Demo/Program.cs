using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _00.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                
                    string numSubstring = text[i].Substring(1, text[i].Length - 2);
                    double number = double.Parse(numSubstring);
                for (int j = 0; j < text[i].Length; j+=text[i].Length-1)
                {

                        int index = text[i][j] % 32;
                    if (j == 0)
                    {
                        if (Char.IsUpper(text[i][j]))
                        {
                            number /= index;
                        }
                        else
                        {
                            number *= index;
                        }
                    }
                    else
                    {
                        if (Char.IsUpper(text[i][j]))
                        {
                            number -= index;
                        }
                        else
                        {
                            number += index;
                        }
                    }
                   
                }
                sum += number;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}












//char currentSymbol = 'A';
//int currentPosition = (int)currentSymbol % 32;  //Get Position of the letter in the English Alphabet (1-26)
//Console.WriteLine(currentPosition);