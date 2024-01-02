using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl
{
    public class Pet : IBirthdayable
    {
        public string Name { get; private set; }
        public string BirthDate { get;private set; }

       

        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
           
        }
        public void CheckAge(string birthYear)
        {
            if (BirthDate.EndsWith(birthYear))
            {
                Console.WriteLine(BirthDate);
            }
        }


    }
}
