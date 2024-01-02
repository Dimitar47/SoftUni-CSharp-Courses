namespace _06.EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
               2
            John 20
            John 20
            */

            int n = int.Parse(Console.ReadLine());
            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();
          
            for (int i = 0; i < n; i++)
            {

                string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                Person person = new Person { Age = age, Name = name };
                hashSet.Add(person);
                sortedSet.Add(person);
            
            }

            Console.WriteLine(hashSet.Count);
            Console.WriteLine(sortedSet.Count);


        }
    }
}