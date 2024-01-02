using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double totalCalories=1;
        private const double baseCalories = 2;
        private double weight;
        public Dough(string flourType, string bakingTechnique,double weight)        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;

        }
        public string FlourType 
        {
            get 
            { 
                return flourType; 
            } 
            set 
            {   if(value.ToLower() == "white")
                {
                    totalCalories *= 1.5;
                }
                else if(value.ToLower() == "wholegrain")
                {
                    totalCalories *= 1.0;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value; 
            }
        }
        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            set
            {
                if(value.ToLower() == "crispy")
                {
                    totalCalories *= 0.9;
                
                }
                else if(value.ToLower() == "chewy")
                {
                    totalCalories *= 1.1;
                }
                else if(value.ToLower() == "homemade")
                {
                    totalCalories *= 1.0;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        public double Weight { get { return weight; }
            private set
            {


                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
                
            }
        }

        public double CalculateCalories()
        {
            return baseCalories * Weight * totalCalories;
        }
    }
}
