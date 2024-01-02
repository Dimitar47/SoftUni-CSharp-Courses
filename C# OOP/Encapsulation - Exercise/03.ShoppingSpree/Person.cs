using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;

        public Person(string name, int money)
        {
            Name = name;
            Money = money;


        }
        public List<Product> Products { get; set; } = new List<Product>();
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public int Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

    }
}
