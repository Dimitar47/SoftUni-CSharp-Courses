namespace _08.CollectionHierarchy
{
    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int removeCount = int.Parse(Console.ReadLine());

            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();


            List<int> addResults = new();
            List<int> addRemoveResults = new();
            List<int> myListResults = new();


            foreach (string item in input)
            {
                addResults.Add(addCollection.Add(item));
                addRemoveResults.Add(addRemoveCollection.Add(item));
                myListResults.Add(myList.Add(item));
            }


            Console.WriteLine(string.Join(" ", addResults));
            Console.WriteLine(string.Join(" ", addRemoveResults));
            Console.WriteLine(string.Join(" ", myListResults));


            List<string> addRemoveRemoved = new();
            List<string> myListRemoved = new();


            for (int i = 0; i < removeCount; i++)
            {
                addRemoveRemoved.Add(addRemoveCollection.Remove());
                myListRemoved.Add(myList.Remove());
            }


            Console.WriteLine(string.Join(" ", addRemoveRemoved));
            Console.WriteLine(string.Join(" ", myListRemoved));
        }
    }
}
