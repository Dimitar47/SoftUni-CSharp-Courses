using System;
using System.Text;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] array = Console.ReadLine().Split();
            //for (int i = 0; i < array.Length; i++)
            //{
            //    for (int j = 0; j < array[i].Length; j++)
            //    {
            //        Console.Write(array[i]);
            //    }
            //}
            string[] words = Console.ReadLine().Split();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string word in words)
            {
                int repeatTimes = word.Length;
                for (int i = 0; i < repeatTimes; i++)
                    stringBuilder.Append(word);
            }
            Console.WriteLine(stringBuilder.ToString());

        }
    }
}
