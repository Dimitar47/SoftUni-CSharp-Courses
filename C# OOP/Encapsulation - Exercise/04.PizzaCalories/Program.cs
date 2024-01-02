using System.Windows.Input;

namespace _04.PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaInfo = Console.ReadLine().Split();
            string pizzaName = pizzaInfo[1];
            try
            {
                string[] doughInfo = Console.ReadLine().Split();
                Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
                Pizza pizza = new Pizza(pizzaName, dough);


                string command = "";
                while ((command = Console.ReadLine()) != "END")
                {

                    string[] tokens = command.Split();
                    Topping topping = new Topping(tokens[1], double.Parse(tokens[2]));
                    pizza.AddTopping(topping);

                }
                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
               
            }


        }
    }
}