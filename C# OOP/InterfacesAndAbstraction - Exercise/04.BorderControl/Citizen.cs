using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl
{
    public class Citizen : IIdentifiable, IBirthdayable, IBuyer
    {

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        public string BirthDate { get; private set; }

        public int Food { get;private set; }

        public Citizen(string name, int age,string id,string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }
        public int BuyFood()
        {
            Food =10;
            return Food;
        }

        public void CheckId(string fakeSubstring)
        {
            if(Id.EndsWith(fakeSubstring))
            {
                Console.WriteLine(Id) ;
            }
        }
        public void CheckAge(string birthYear)
        {
            if(BirthDate.EndsWith(birthYear))
            {
                Console.WriteLine(BirthDate);
            }
        }

       
    }
}
