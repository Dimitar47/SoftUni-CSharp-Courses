namespace _04.PizzaCalories
{
    public class Topping
    {

        private string toppingType;
        private double weight;

        private const double Meat_Modifier = 1.2;
        private const double Veggies_Modifier = 0.8;
        private const double Cheese_Modifier = 1.1;
        private const double Sauce_Modifier = 0.9;

        public string ToppingType
        {
            get => toppingType;
            set
            {
                string toppingTypeToUpper = char.ToUpper(value[0]) + value.ToLower().Substring(1);
                if (toppingTypeToUpper == "Meat" || toppingTypeToUpper == "Veggies" || toppingTypeToUpper == "Cheese" || toppingTypeToUpper == "Sauce")
                {
                    toppingType = toppingTypeToUpper;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }

        public double Weight
        {
            get => weight;

            set
            {
                if(value>=1 && value <= 50)
                {

                    weight = value;
                }
                else
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
                }
            }
        }

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;    
        }
        public double ToppingCalculateCalories()
        {
            double totalCalories = Base_Calories;


            if (ToppingType == "Meat")
            {
                totalCalories *= Meat_Modifier;
            }
            else if (ToppingType == "Cheese")
            {
                totalCalories *= Cheese_Modifier;
            }

            else if (ToppingType == "Veggies")
            {
                totalCalories *= Veggies_Modifier;
            }
            else if (ToppingType == "Sauce")
            {
                totalCalories *= Sauce_Modifier;
            }
            return totalCalories;

        }
        public double Base_Calories => 2 * Weight;


    }
}
