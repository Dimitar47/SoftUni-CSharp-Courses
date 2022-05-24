using System;

namespace _6._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int openingBracket = 0;
            int closingBracket = 0;
            for (int i = 1; i <= n; i++)
            {
                string text = Console.ReadLine();
                if (text == "(") 
                {
                    openingBracket++;
                }
                else if(text == ")")
                {
                    closingBracket++;
                    if (openingBracket - closingBracket != 0)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }

                }
            }
            if(openingBracket == closingBracket)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
