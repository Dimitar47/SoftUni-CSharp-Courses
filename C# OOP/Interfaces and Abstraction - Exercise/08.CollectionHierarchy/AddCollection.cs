namespace _08.CollectionHierarchy
{
    public class AddCollection : CollectionBase, IAdd
    {
        public int Add(string item)
        {
            items.Add(item);

            return items.Count - 1;
        }
    }
}
