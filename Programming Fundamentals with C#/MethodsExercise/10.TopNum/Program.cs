using System;

namespace _10.TopNum
{
    class Program
    {
        static void Main(string[] args)
        {
            int endValue = int.Parse(Console.ReadLine());
          
            
            for (int i = 1; i <= endValue; i++)
            {
                int j = i;
                int sum = 0;
                int count = 0;
                while (j>0)
                {
                    int currentDigit = j % 10;
                    if (currentDigit % 2 != 0)
                    {
                        count++;
                    }
                    sum += currentDigit;
                    j = j / 10;
                    
                }
                
                if (sum % 8 == 0 && count>=1)
                {

                   Console.WriteLine(i);
                }

            }

           
            
        }

        static int TopNum(int endValue)
        {
            
           

            return 1;
        }

    }
}
