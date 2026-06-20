using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        private const double WHITE_MODIFIER = 1.5;
        private const double WHOLEGRAIN_MODIFIER = 1.0;
        private const double CRISPY_MODIFIER = 0.9;
        private const double CHEWY_MODIFIER = 1.1;
        private const double HOMEMADE_MODIFIER = 1.0;
        public string FlourType
        {
            get => flourType;
            set
            {
                string flourTypeToUpper = char.ToUpper(value[0]) + value.ToLower().Substring(1);
                if(flourTypeToUpper == "White" || flourTypeToUpper == "Wholegrain")
                {
                    flourType = flourTypeToUpper;
                }
                else
                {
                    throw new ArgumentException($"Invalid type of dough.");
                }

            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            set
            {
                string bakingTechniqueToUpper = char.ToUpper(value[0]) + value.ToLower().Substring(1);
                if (bakingTechniqueToUpper == "Crispy" || bakingTechniqueToUpper == "Chewy" || bakingTechniqueToUpper == "Homemade")
                {
                    bakingTechnique = bakingTechniqueToUpper;
                }
                else
                {
                    throw new ArgumentException($"Invalid type of dough.");
                }

            }
        }

        public double Weight
        {
            get => weight;
            set
            {
                if (value >= 1 && value <= 200)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException($"Dough weight should be in the range [1..200].");
                }
            }
        }


        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public double DoughCalculateCalories()
        {
            double totalCalories = Base_Calories;


            if(FlourType == "White")
            {
                totalCalories *= WHITE_MODIFIER;
            }
            else if(FlourType == "Wholegrain")
            {
                totalCalories *= WHOLEGRAIN_MODIFIER;
            }

            if (BakingTechnique == "Crispy")
            {
                totalCalories *= CRISPY_MODIFIER;
            }
            else if (BakingTechnique == "Chewy")
            {
                totalCalories *= CHEWY_MODIFIER;
            }
            else if(BakingTechnique == "Homemade")
            {
                totalCalories *= HOMEMADE_MODIFIER;
            }
            return totalCalories;

        }
        public double Base_Calories => 2 * Weight;
    }

}
