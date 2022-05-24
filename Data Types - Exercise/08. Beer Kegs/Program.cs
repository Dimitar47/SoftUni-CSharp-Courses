using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string biggest = "";
            double max = double.MinValue;
            for (int i = 0; i < n; i++)
            {
               
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * radius * radius * height;
                if (volume > max)
                {
                    max = volume;
                    biggest = model;
                }
            }
            Console.WriteLine(biggest);
        }
    }
}
