namespace _03.ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string[] personInfoSplitWithSemi = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < personInfoSplitWithSemi.Length; i++)
            {

                string[] personInfoSplitWithEqual = personInfoSplitWithSemi[i]
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Person person = new Person(personInfoSplitWithEqual[0], int.Parse(personInfoSplitWithEqual[1]));
                    persons.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            List<Product> products = new List<Product>();
            string[] productInfoSplitWithSemi = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productInfoSplitWithSemi.Length; i++)
            {

                string[] productInfoSplitWithEqual = productInfoSplitWithSemi[i]
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Product product = new Product(productInfoSplitWithEqual[0], int.Parse(productInfoSplitWithEqual[1]));
                    products.Add(product);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            //  Person person = new Person()
            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];
                string productName = tokens[1];
                Person person = persons.Where(x => x.Name == personName).FirstOrDefault();
                Product product = products.Where(x => x.Name == productName).FirstOrDefault();

                if (person.Money - product.Cost >= 0)
                {
                    person.Money -= product.Cost;
                    person.Products.Add(product);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }

            }
            foreach (var person in persons)
            {
                if (person.Products.Any())
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Select(x => x.Name).ToList())}");
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }

        }
    }
}