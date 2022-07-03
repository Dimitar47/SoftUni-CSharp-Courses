using System;

namespace _10.EvenByOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            //GetMultipleOfEvenAndOdds(number);
          
            Console.WriteLine(GetSumOfOddDigits(number) * GetSumOfEvenDigits(number));
        }

        //static void GetMultipleOfEvenAndOdds(int number)
        //{
        //    string text = number.ToString();
        //    int length = text.Length;
        //    for (int i = 0; i < length; i++)
        //    {
        //        if (text[i] % 2 == 0)
        //        {
        //            Console.WriteLine("Evens: " + text[i]);
                    
        //        }
        //        else
        //        {
        //            Console.WriteLine("Odds:" + text[i]);
        //        }
        //    }
        //}

        static int GetSumOfEvenDigits(int number)
        {
            string text = number.ToString();
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if ((number%10) % 2 == 0)
                {
                    sum +=number % 10;
                   
                }
                number = number / 10;
            }

            return sum;
        }

        static int GetSumOfOddDigits(int number)
        {
            string text = number.ToString();
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if ((number%10) % 2 != 0)
                {
                    sum += number % 10;

                }
                number = number / 10;
            }

            return sum;
        }
    }
}
