using System.Text;

namespace PersonsInfo
{
    public class Person
    {

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }

        public Person(string firstName,string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{FirstName} {LastName} is {Age} years old.");
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
