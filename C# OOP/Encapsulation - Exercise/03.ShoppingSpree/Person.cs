using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {

        private string name;
        private decimal money;
        private List<Product> products;

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public IReadOnlyCollection<Product> Products => products.AsReadOnly();


        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public void BuyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                Money -= product.Cost;
                Console.WriteLine($"{Name} bought {product.Name}");
                products.Add(product);
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();


            stringBuilder.AppendLine($"{Name} - {(products.Count > 0 ? string.Join(", ", products.Select(x=>x.Name)) : "Nothing bought")}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
