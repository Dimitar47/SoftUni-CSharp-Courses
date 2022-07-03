using System;
using System.Linq;
namespace _2._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split().ToArray();

            string[] arr2 = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < arr2.Length; i++)
            {

                for (int j = 0; j < arr1.Length; j++)
                {

                    if (arr2[i] == arr1[j])
                    {
                        Console.Write($"{arr2[i]} ");
                    }

                }

            }

            //Common Elements string[] arr1 = Console.ReadLine().Split().ToArray();
            //string[] arr2 = Console.ReadLine().Split().ToArray();

            //for (int i = 0; i <= arr2.Length-1; i++)
            //{


            //        if (arr1.Contains(arr2[i]))
            //        {

            //            Console.Write(arr2[i] +" ");


            //        }


            //}


        }
    }
}
