using System;

namespace _4.PassValid
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            
            if (CheckDigits(pass) && CheckLength(pass) && CheckCharacters(pass))
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (CheckLength(pass) == false)
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (CheckCharacters(pass) == false)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (CheckDigits(pass) == false)
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
               
               
            }
        }

        static bool CheckLength(string pass)
        {
            bool isTrue = !(pass.Length < 6 || pass.Length > 10);

            return isTrue;


        }
        static bool CheckCharacters(string pass)
        {
            int count = 0;
            bool isTrue = true;
            for (int i = 0; i < pass.Length; i++)
            {
                if (Char.IsLetterOrDigit(pass[i]))
                {
                    count++;
                }
            }

            if (count!=pass.Length)
            {
                isTrue = false;
               
            }

            return isTrue;

        }
        static bool CheckDigits(string pass)
        {
            int countDigits = 0;
            bool isTrue = true;
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] == '0' || pass[i]=='1' ||pass[i] =='2' || pass[i]=='3' || pass[i] == '4' || pass[i] == '5' || pass[i] == '6' || pass[i] == '7' || pass[i] == '8' || pass[i] == '9')
                {
                    countDigits++;
                }
            }

            if (countDigits < 2)
            {
                isTrue = false;
                
            }

            return isTrue;
        }
    }
}
