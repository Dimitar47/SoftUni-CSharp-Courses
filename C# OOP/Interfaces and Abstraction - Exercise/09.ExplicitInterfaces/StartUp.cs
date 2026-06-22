namespace _09.ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command;

            while((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);



                Citizen citizen = new Citizen(name, country, age);
                IPerson person = citizen;
                IResident resident = citizen;


                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }





        }
    }
}
