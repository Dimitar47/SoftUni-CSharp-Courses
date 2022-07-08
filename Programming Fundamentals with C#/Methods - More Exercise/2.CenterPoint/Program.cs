using System;
using System.Security.Cryptography.X509Certificates;

namespace _2.CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double X1 = double.Parse(Console.ReadLine());
            double Y1 = double.Parse(Console.ReadLine());
            double X2 = double.Parse(Console.ReadLine());
            double Y2 = double.Parse(Console.ReadLine());
           double resultFirst = (CalculateDistanceFirst(X1, Y1,X2:0,Y2:0));
           double resultSecond =  (CalculateDistanceSecond(X1:0,Y1:0,X2,Y2));

           if (resultFirst > resultSecond)
           {
               Console.WriteLine($"({X2}, {Y2})");
           }
           else
           {
               Console.WriteLine($"({X1}, {Y1})");
            }
        }

        static double CalculateDistanceFirst(double X1, double Y1,double X2,double Y2)
        {
            double result = (Math.Pow(X2 - X1, 2) + Math.Pow(Y2-Y1,2)  );
            return result;
        }

        static double CalculateDistanceSecond(double X1, double Y1, double X2, double Y2)
        {
            double result = (Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
            return result;
        }
    }
}
