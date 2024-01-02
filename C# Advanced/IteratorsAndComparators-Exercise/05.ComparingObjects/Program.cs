namespace _05.ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            List<Person> people = new List<Person>();
            while ((command = Console.ReadLine()) != "END")
            {
                string[] personInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];
                Person person = new Person { Age = age, Name = name ,Town = town};
                people.Add(person);
            }
          
            int n = int.Parse(Console.ReadLine());
            Person person1 = people[n - 1];
            int equalPeople = 0;
            int differentPeople = 0;
            foreach(var person in people)
            {
                if (person.CompareTo(person1) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    differentPeople++;
                }
            
            }
            if(equalPeople == 1)
            {
                Console.WriteLine("No matches");
                return;
            }
            Console.WriteLine($"{equalPeople} {differentPeople} {people.Count}"  );

        }
    }
}