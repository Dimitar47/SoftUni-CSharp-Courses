namespace _08.CollectionHierarchy
{
    public class MyList : CollectionBase, IAdd, IRemove, IUsed
    {
        public int Add(string item)
        {
            items.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            string removed = items[0];

            items.RemoveAt(0);

            return removed;
        }

        public int Used => items.Count;
    }
}
