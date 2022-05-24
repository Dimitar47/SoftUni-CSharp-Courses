using System;

namespace _05._Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string sum = "";
            for (int i = 0; i < n; i++)
            {

            
            
                string number = Console.ReadLine();
                int length = number.Length;
                int mainD = int.Parse(number) % 10;
                int offset = (mainD - 2) * 3;
                if (mainD == 0)
                {
                    offset -= 59;
                }
                if (mainD == 8 || mainD == 9)
                {
                    offset += 1;
                }
                int digitIndex = offset + length - 1;
                char letter = (char)(digitIndex + 'a');
                sum += letter;
            }
            Console.WriteLine(sum);
        }
    }
}
