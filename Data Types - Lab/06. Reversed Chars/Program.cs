using System;

namespace _06._Reversed_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstCharacter = char.Parse(Console.ReadLine());
            char secondCharacter = char.Parse(Console.ReadLine());
            char thirdCharacter = char.Parse(Console.ReadLine());
            Console.WriteLine($"{thirdCharacter} {secondCharacter} {firstCharacter}");


            //string name = Console.ReadLine();
            //char[] charArr = name.ToCharArray();
            //Array.Reverse(charArr);
            //string reverseName = new string(charArr);
            //Console.WriteLine(reverseName);

        }
    }
}
