using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int snowballs = int.Parse(Console.ReadLine());
            BigInteger max = 0;
         
            int maxSnowballSnow = 0;
            int maxSnowballTime = 0;
            int maxSnowballQuality = 0;

            for (int i = 0; i < snowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
               
                int snowballQuality = int.Parse(Console.ReadLine());
                
                BigInteger snowballvalue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);
                if(snowballvalue > max )
                {
                    maxSnowballQuality = snowballQuality;
                    maxSnowballSnow = snowballSnow;
                    maxSnowballTime = snowballTime;
                    max = snowballvalue;
                }
               
            }
            Console.WriteLine($"{maxSnowballSnow} : {maxSnowballTime} = {max} ({maxSnowballQuality})");
        }
    }
}
