namespace _09.ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public string Name { get; private set; }

        public string Country { get; private set; }

        public int Age { get; private set; }

        public Citizen(string name,string country,int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        string IPerson.GetName()
        {
            return $"{Name}";
        }
        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }
    }
}
