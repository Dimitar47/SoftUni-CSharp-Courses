namespace _04.PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {

                string[] pizzaTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (pizzaTokens.Length < 2)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                string pizzaName = pizzaTokens[1];
               


                string command = Console.ReadLine();

                string flourType = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];
                string bakingTechnique = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[2];
                double doughWeight = double.Parse(command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[3]);
                Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);



                while ((command = Console.ReadLine()) != "END")
                {
                    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string toppingType = tokens[1];
                    double toppingWeight = double.Parse(tokens[2]);
                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                }
               

                Console.WriteLine($"{pizza}");


            }




            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
    }
}
