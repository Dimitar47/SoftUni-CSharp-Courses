using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack5
{
    class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
           
            return this.Count==0 ;
        }

        public Stack<string> AddRange(Stack<string> elements)
        {
            
            foreach (var item in elements)
            {
                this.Push(item);
               
            }
            return this;
        }
    }
}
