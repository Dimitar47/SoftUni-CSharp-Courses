using System;

namespace Exercise_Basic_Syntax__Conditional_Statements_and_Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            if (age >= 0 && age <= 2)
            {
               Console.WriteLine("baby");
            }
            else if(age>=3 && age <= 13)
            {
                Console.WriteLine("child");
            }
            else if(age>=14 && age <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if(age>=20 && age <= 65)
            {
                Console.WriteLine("adult");
            }
            else if(age>=66)
            {
                Console.WriteLine("elder");
            }


           // string result = age <= 2 ? "baby" : age > 2 && age <= 13 ? "child" : age > 13 && age <= 19 ? "teenager" : age > 19 && age <= 65 ? "adult" : "elder";

            //switch (age)
            //{
            //    case int num when num <= 2:
            //        Console.WriteLine("baby");
            //        break;
            //    case int num when num> 2 && num <= 13:
            //        break;
            //    default:
            //        Console.WriteLine("elder");
            //        break;
            //}
        }
    }
}
