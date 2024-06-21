using System.Collections.Generic;
using System.Diagnostics;

namespace BCLDemoLibrary
{
    /// <summary>
    /// A custom list class that extends the functionality of the base List<T>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class CustomList<T> : List<T>
    {
        /// <summary>
        /// Adds an item to the list with custom logic.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        public new void Add(T item)
        {
            // Your custom logic here before calling the base class method
            Trace.WriteLine("Custom logic before adding an item");

            // Call the base class method to perform the actual operation
            Insert(0, item);

            // Your custom logic here after calling the base class method
            Trace.WriteLine("Custom logic after adding an item");
        }

        /// <summary>
        /// Removes the item at the first index in the list.
        /// </summary>
        public new void Remove()
        {
            RemoveAt(0);
        }

        /// <summary>
        /// Retrieves the item at the first index in the list.
        /// </summary>
        /// <returns>The item at the first index.</returns>
        public new T FindIndex()
        {
            return this[0];
        }
    }
}
