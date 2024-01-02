using System;
using System.Collections.Generic;

namespace _05.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {


            string[] allPeopleSplitBySemiColumn = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] allProductsSplitBySemiColumn = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            for (int i = 0; i < allPeopleSplitBySemiColumn.Length; i++)
            {
                string[] allPeopleSplitByEqual = allPeopleSplitBySemiColumn[i].Split("=");
                Person person = new Person();
                person.Name = allPeopleSplitByEqual[0];
                person.Money = int.Parse(allPeopleSplitByEqual[1]);
                people.Add(person);


            }
            for (int i = 0; i < allProductsSplitBySemiColumn.Length; i++)
            {
                string[] allProductsSplitByEqual = allProductsSplitBySemiColumn[i].Split("=");
                Product product = new Product();
                product.Name = allProductsSplitByEqual[0];
                product.Cost = int.Parse(allProductsSplitByEqual[1]);
                products.Add(product);

            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }
                string[] commandArray = command.Split();
                string name = commandArray[0];
                string exampleProduct = commandArray[1];

                foreach (Person person in people)
                {
                    foreach (Product product in products)
                    {
                        if (person.Name == name && product.Name == exampleProduct)
                        {
                            if (person.Money >= product.Cost)
                            {
                                person.Money -= product.Cost;
                                person.bagOfProducts.Add(product.Name);
                                Console.WriteLine($"{person.Name} bought {product.Name}");
                            }
                            else
                            {
                                Console.WriteLine($"{person.Name} can't afford {product.Name}");
                            }
                        }
                    }
                }
            }
            foreach (Person person in people)
            {
                if (person.bagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                    break;
                }

                Console.WriteLine($"{person.Name} - {string.Join(", ", person.bagOfProducts)}");

            }

        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public List<string> bagOfProducts { get; set; } = new List<string>();
    }
    class Product
    {
        public string Name { get; set; }
        public int Cost { get; set; }
    }
}
