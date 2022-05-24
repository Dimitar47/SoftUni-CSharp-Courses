using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double price = 0;
            if(dayOfWeek == "Friday")
            {
                if(typeOfGroup == "Students")
                {
                    price = 8.45 * people;

                    if (people >= 30)
                    {
                        price = price - price * 0.15;
                    }

                }
                else if(typeOfGroup == "Business")
                {
                    price = 10.90 * people;
             
                    if (people >= 100)
                    {
                        price = price  - (price - 10.90 * (people - 10));
                    }
                }
                else if(typeOfGroup == "Regular")
                {

                    price = 15 * people;

                    if (people >= 10 && people <= 20)
                    {
                        price = price - price * 0.05;
                    }
                }
            }
            else if(dayOfWeek == "Saturday")
            {
                if (typeOfGroup == "Students")
                {
                    price = 9.80 * people;

                    if (people >= 30)
                    {
                        price = price - price * 0.15;
                    }
                }
                else if (typeOfGroup == "Business")
                {
                    price = 15.60 * people;

                    if (people >= 100)
                    {
                        price = price - (price - 15.60 * (people - 10));
                    }
                }
                else if (typeOfGroup == "Regular")
                {
                    price = 20 * people; 

                    if(people>=10 && people <= 20)
                    {
                        price = price - price * 0.05;
                    }
                }
            }
            else if (dayOfWeek == "Sunday")
            {
                if (typeOfGroup == "Students")
                {
                    price = 10.46 * people;

                    if (people >= 30)
                    {
                        price = price - price * 0.15;
                    }
                }

                else if (typeOfGroup == "Business")
                {
                    price = 16 * people;

                    if (people >= 100)
                    {
                        price = price - (price - 16 * (people - 10));
                    }
                }

                else if (typeOfGroup == "Regular")
                {
                    price = 22.50 * people;

                    if (people >= 10 && people <= 20)
                    {
                        price = price - price * 0.05;
                    }
                }
            }
            //Otherr way: price -= price/peopleCount*10;

            Console.WriteLine($"Total price: {price:F2}");
        }
    }
}
