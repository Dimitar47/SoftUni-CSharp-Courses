namespace PersonInfo
{
    public class Citizen : IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }


        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }


    }
}
