namespace _03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] personsSplitBySemiColon = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            try
            {
                for (int i = 0; i < personsSplitBySemiColon.Length; i++)
                {

                    string[] personsSplitByEqualSign = personsSplitBySemiColon[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string personName = personsSplitByEqualSign[0];
                    decimal money = decimal.Parse(personsSplitByEqualSign[1]);
                    Person person = new Person(personName, money);
                    people.Add(person);
                }


                List<Product> products = new List<Product>();
                string[] productsSplitBySemiColon = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < productsSplitBySemiColon.Length; i++)
                {
                    string[] productsSplitByEqualSign = productsSplitBySemiColon[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string productName = productsSplitByEqualSign[0];
                    decimal money = decimal.Parse(productsSplitByEqualSign[1]);
                    Product product = new Product(productName, money);
                    products.Add(product);
                }

                string command;

                while((command = Console.ReadLine()) != "END")
                {
                    string[] token = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string personName = token[0];
                    string productName = token[1];

                    Person person = people.FirstOrDefault(x => x.Name == personName);
                    Product product = products.FirstOrDefault(x => x.Name == productName);

                    person.BuyProduct(product);



                }

                foreach(var person in people)
                {
                    Console.WriteLine(person);
                }
                    

            }
             catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
