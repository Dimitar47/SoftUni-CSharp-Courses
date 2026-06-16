using System;
using System.Text;

namespace Person
{
    public class Person
    {

        private string name;
        private int age;


        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {

                age = value;
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{this.GetType().Name} -> Name: {Name}, Age: {Age}");

            return stringBuilder.ToString().TrimEnd();
        }


    }
}
