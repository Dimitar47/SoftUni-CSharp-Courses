namespace _08.CollectionHierarchy
{
    public class AddRemoveCollection : CollectionBase, IAdd, IRemove
    {
        public int Add(string item)
        {
            items.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            int lastIndex = items.Count - 1;
            string removed = items[lastIndex];

            items.RemoveAt(lastIndex);

            return removed;
        }
    }
}
