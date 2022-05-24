using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
           
            

            for (int num = 1; num <= number; num++)
            {
                bool isSpecialNum = false;
                int sum = 0;
                int digits = num;
                while (digits > 0)
                {
                    sum += digits % 10;
                    digits = digits / 10;
                }
                isSpecialNum = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine("{0} -> {1}", num, isSpecialNum);
               
            }

        }
    }
}
