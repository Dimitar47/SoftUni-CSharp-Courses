using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index;
        private List<T> items;
        public ListyIterator(List<T> items)
        {
             this.items = items;
        }
        public bool Move()
        {
            if (index < items.Count - 1) { index++; return true; }
            else { return false; }
        }   
        public bool HasNext()
        {
            return index < items.Count - 1;
        }
        public void Print()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation");

            }
            Console.WriteLine(items[index]);

        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
