namespace _05.BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command;

            List<IBirthable> birthables = new List<IBirthable>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = tokens[0];

                
                if (type == nameof(Citizen))
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdate = tokens[4];

                    birthables.Add(new Citizen(name, age, id, birthdate));
                }
                else if (type == nameof(Robot))
                {
                    string model = tokens[1];
                    string id = tokens[2];

                    var robot = new Robot(model, id);
              
                }
                else if (type == nameof(Pet))
                {
                    string name = tokens[1];
                    string birthdate = tokens[2];

                    birthables.Add(new Pet(name, birthdate));
                }
            }
            string year = Console.ReadLine();


            Console.WriteLine(string.Join(Environment.NewLine,birthables.Where(x=>x.Birthdate.Contains(year)).Select(x=>x.Birthdate)));

        }
    }
}
