using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;
        
        protected Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size
        {
            get => size;
            private set
            {
               
                size = value;
            }
        }


        public double Price
        {
            get => price;
            private set
            {
                if (Size == "Large")
                {
                    price = value;
                }
                else if(Size == "Middle")
                {
                    price = (2.0 / 3) * value;
                }
                else if(Size == "Small")
                {
                    price = (1.0/3) * value;
                }
            }
        }
        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:F2} lv";
        }

    }
}
