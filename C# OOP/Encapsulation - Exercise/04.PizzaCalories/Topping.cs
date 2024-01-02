using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private double baseCalories = 2;
        private double totalCalories = 1;
        private double weight;
        private string toppingType;
        public Topping(string toppingType,double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }
        public string ToppingType 
        { 
            get
            {
            return toppingType;
            }
            set
            {
                if(value.ToLower() == "meat")
                {
                    totalCalories *= 1.2;
                }
                else if (value.ToLower() == "veggies")
                {
                    totalCalories *= 0.8;
                }
                else if(value.ToLower()== "cheese")
                {
                    totalCalories *= 1.1;
                }
                else if(value.ToLower() == "sauce")
                {
                    totalCalories *= 0.9;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");

                }
                toppingType = value;
            }
        
        }
        public double Weight
        {
            get { return weight; }
            private set
            {


                if (value < 0 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
                }
                weight = value;

            }
        }
        public double CalculateCalories()
        {
            return totalCalories * Weight*baseCalories;
        }

    }
}
