using System;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {


            string input = Console.ReadLine();
            int strength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Equals('>'))
                {
                    strength += int.Parse(input[i + 1].ToString());
                }
                else
                {
                    if (strength != 0)
                    {
                        input = input.Remove(i, 1);
                        i--;
                        strength--;
                    }
                }
            }
            Console.WriteLine(input);
        }
        
    }
}







//string text = Console.ReadLine();
//StringBuilder stringBuilder = new StringBuilder();

//int power = 0;
//for (int i = 0; i < text.Length; i++)
//{
//    //1. Not explosion  (not '>' ),character stay
//    //2. Not explosion, character is omitted (prev char was an explosion)
//    //3. Explosion (char == '>') -> get next char, turn into int
//    char currentChar = text[i];
//    if (currentChar == '>')
//    {
//        power += int.Parse(text[i + 1].ToString());
//        stringBuilder.Append('>');
//    }
//    else if (power == 0)
//    {
//        stringBuilder.Append(currentChar);
//    }
//    else
//    {
//        power--;
//    }
//}
//Console.WriteLine(stringBuilder);


