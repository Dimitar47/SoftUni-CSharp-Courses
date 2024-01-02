using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> items;
        public Box() 
        
        { 
        items = new List<T>();
        
        }

        public void Add (T item) 
        {
            items.Add(item);
        
        }
        public T Remove ()
        {
            T topMost = items[items.Count - 1];
            items.RemoveAt(items.Count-1);
            return topMost;
        }
       public int Count
        {
            get { return items.Count; }
        }

    }
}
