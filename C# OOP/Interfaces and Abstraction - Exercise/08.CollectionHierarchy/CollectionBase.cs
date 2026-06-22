using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CollectionHierarchy
{
    public abstract class CollectionBase
    {
        protected readonly List<string> items = new();

        public int Count => items.Count;
    }
}
