using System.Collections.Generic;
using System.Diagnostics;

namespace BCLLibrary
{
    public class CustomList<T> : List<T>
    {
        public new void Add(T item)
        {
            // Your custom logic here before calling the base class method
            Trace.WriteLine("Custom logic before adding an item");

            // Call the base class method to perform the actual operation
            Insert(0, item);

            // Your custom logic here after calling the base class method
            Trace.WriteLine("Custom logic after adding an item");
        }
        public new void Remove()
        {
            RemoveAt(0);
        }
        public new T FindIndex()
        {
            return this[0];

        }
    }
}
