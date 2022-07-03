using System;
using System.Linq;
using System.Text;

namespace _7.RepeatStr
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(getString(text,number));
        }

        static string getString(string text,int number)
        {
            string newText = "";
            //StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < number; i++)
            {
                newText = text + newText;
                //stringBuilder.Append(text);
            }

            return newText;
            // return stringBuilder.ToString();
        }
    }
}
