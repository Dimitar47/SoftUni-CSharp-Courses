namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();

                string firstName = cmd[0];
                int age = int.Parse(cmd[1]);

                if (cmd.Length == 4)
                {
                    string id = cmd[2];
                    string birthDate = cmd[3];
                    buyers.Add(new Citizen(firstName, age, id, birthDate));

                }
                else if (cmd.Length == 3)
                {
                    string group = cmd[2];
                    buyers.Add(new Rebel(firstName, age, group));

                }
               
           
           
            }
            int totalFood = 0;
            string name;
            while ((name = Console.ReadLine()) != "End")
            {
                for (int i = 0; i < buyers.Count; i++)
                {
                    string type = buyers[i].GetType().Name;
                    if(type == "Citizen")
                    {
                        Citizen citizen = (Citizen)buyers[i];
                        if (citizen.Name == name)
                        {
                            totalFood+=citizen.BuyFood();
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if(type == "Rebel")
                    {
                        Rebel rebel = (Rebel)buyers[i];
                        if (rebel.Name == name)
                        {
                             totalFood+= rebel.BuyFood();
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            Console.WriteLine(totalFood);
           



        }
    }
}