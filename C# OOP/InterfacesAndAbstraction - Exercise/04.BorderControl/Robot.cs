using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl
{
    public class Robot : IIdentifiable
    {
  
        public Robot(string name,string id)
        {
            Name = name;
            Id = id;
        }
        public string Name { get; private set; }
       public string Id { get; private set; }

       

        public void CheckId(string fakeSubstring)
        {
            if (Id.EndsWith(fakeSubstring))
            {
                Console.WriteLine(Id);
            }
        }
    }
}
