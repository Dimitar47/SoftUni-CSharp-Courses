using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        public Dough Dough { get; set; }
        public IReadOnlyCollection<Topping> Toppings => toppings.AsReadOnly();


        public string Name
        {
            get => name;
            set
            {
                if (value.Length >= 1 && value.Length <= 15) 
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
                }
            }
        }


        public Pizza(string name, Dough dough)
        {
            Name = name;
            toppings = new List<Topping>();
            Dough = dough;
        }


        public void AddTopping(Topping topping)
        {
            if (Toppings.Count == 10)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public double PizzaCalculateCalories()
        {
            double totalCalories = Dough.DoughCalculateCalories();

            totalCalories += Toppings.Sum(x => x.ToppingCalculateCalories());

            return totalCalories;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{Name} - {PizzaCalculateCalories():f2} Calories.");


            return stringBuilder.ToString().TrimEnd();
        }


    }
}
