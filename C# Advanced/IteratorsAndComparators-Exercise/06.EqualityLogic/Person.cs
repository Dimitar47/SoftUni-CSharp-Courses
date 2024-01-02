using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person? other)
        {
            int result = Name.CompareTo(other.Name);

            if (result != 0)
            {
                return result;
            }

          result = Age.CompareTo(other.Age);
            if (result != 0)
            {
                return result;
            }
            return result;
        }
        public override bool Equals(object? obj)
        {
            Person? other = obj as Person;
            if (other == null)
            {
                return false;   
            }
            return Name == other.Name && Age == other.Age;
        }
        public override int GetHashCode()
        {
            int getHash = Name.GetHashCode() + Age.GetHashCode();
            return getHash;
        }
    }
}
