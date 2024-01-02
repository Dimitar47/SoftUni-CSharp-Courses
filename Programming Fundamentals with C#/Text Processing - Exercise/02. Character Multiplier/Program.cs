using System;
using System.Linq;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split();
            int maxSum = 0;
            Console.WriteLine( Multiply(text[0], text[1],maxSum));

        }
        static int Multiply(string firstString,string secondString,int sum)
        {
            int maxLength = Math.Max(firstString.Length, secondString.Length);
            string maxString = firstString.Length > secondString.Length ? firstString : secondString;
            for (int i = 0; i < maxLength; i++)
            {

                if (i > firstString.Length - 1 || i > secondString.Length - 1)
                {
                    sum += maxString[i];
                }
                else
                {
                    int currentSum = firstString[i] * secondString[i];
                    sum += currentSum;
                }
               
            }
            return sum;
        }
    }
}

//using System;

//namespace _00.Demo
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {

//            string[] input = Console.ReadLine().Split();

//            string first = input[0];
//            string second = input[1];

//            long sum = CalculateSum(first, second);

//            Console.WriteLine(sum);
//        }

//        private static long CalculateSum(string first, string second)
//        {

//            char[] firstArr = first.ToCharArray();
//            char[] secondArr = second.ToCharArray();
//            long sum = 0;
//            int minLength = Math.Min(firstArr.Length, secondArr.Length);
//            int maxLength = Math.Max(firstArr.Length, secondArr.Length);

//            for (int i = 0; i < minLength; i++)
//            {

//                sum += firstArr[i] * secondArr[i];
//            }

//            if (maxLength == firstArr.Length)
//            {
//                for (int i = minLength; i < maxLength; i++)
//                {
//                    sum += firstArr[i];
//                }
//            }
//            else
//            {
//                for (int i = minLength; i < maxLength; i++)
//                {
//                    sum += secondArr[i];
//                }
//            }

//            return sum;
//        }
//    }
//}