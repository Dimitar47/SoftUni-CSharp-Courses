using System;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine().Split(", ");
            foreach(var userName in userNames)
            {
                bool isValid = true;
                if (userName.Length>=3 && userName.Length <= 16)
                {
                    
                    foreach (char character in userName)
                    {
                        if (Char.IsLetterOrDigit(character) || character == '-' || character == '_' )
                        {

                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                else { isValid = false; }
                if (isValid)
                {
                    Console.WriteLine(userName);
                }
            }
        }
    }
}
