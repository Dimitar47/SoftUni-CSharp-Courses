namespace _04.BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            string command;

            List<IIdentifiable> identifiables = new List<IIdentifiable>();
            while((command = Console.ReadLine()) != "End")
            {

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                IIdentifiable identifiable;
                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];

                    identifiable = new Citizen(name, age, id);
                }
                else
                {
                    string model = tokens[0];
                    string id = tokens[1];
                    identifiable = new Robot(model, id);
                }
                identifiables.Add(identifiable);
            }
            string lastDigits = Console.ReadLine();

            Console.WriteLine(string.Join(Environment.NewLine,identifiables.Where(x=>x.Id.EndsWith(lastDigits)).Select(x=>x.Id)));


        }
    }
}
