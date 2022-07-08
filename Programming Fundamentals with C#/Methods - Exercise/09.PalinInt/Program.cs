using System;

namespace _09.PalinInt
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                int number = int.Parse(command);
                Console.WriteLine(Palindrome(number));
            }
           
        }

        static string Palindrome(int number)
        {
            string text = number.ToString();
            string convert = "";
            for (int i = text.Length-1; i >=0; i--)
            {
                convert += text[i];
            }

            string result = convert == text ? "true" : "false";
            return result;
        }
    }
}
