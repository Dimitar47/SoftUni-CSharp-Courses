using System;

namespace _02.EnglishName_of_theLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = number % 10;
            Console.WriteLine(Spelling(number));
        }
        public static string Spelling(int number)
        {
            string someting = "";
            if(number == 1)
            {
                someting = "one";
            }else if(number == 2)
            {
                someting = "two";
            }else if(number == 3)
            {
                someting = "three";
            }
            else if (number == 4)
            {
                someting = "four";
            }
            else if (number == 5)
            {
                someting = "five";
            }
            else if (number == 6)
            {
                someting = "six";
            }
            else if (number == 7)
            {
                someting = "seven";
            }
            else if (number == 8)
            {
                someting = "eight";
            }
            else if (number == 9)
            {
                someting = "nine";
            }
            else if(number == 0)
            {
                someting = "zero";
            }
            
            return someting;
        }
    }
}
