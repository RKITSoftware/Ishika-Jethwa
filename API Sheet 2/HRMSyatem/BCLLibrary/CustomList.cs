using System.Collections.Generic;

namespace BCLLibrary
{
    /// <summary>
    /// A custom list that extends the functionality of the standard List class. 
    /// This custom list inserts new elements at the beginning (index 0) when using the `Add` method.
    /// It also includes constructors for initializing with or without a collection.
    /// </summary>
    public class CustomList<T> : List<T>
    {
        /// <summary>
        /// Default constructor that initializes an empty CustomList.
        /// </summary>
        public CustomList() : base() { }

        /// <summary>
        /// Constructor that initializes a CustomList with the given collection.
        /// </summary>
        /// <param name="collection">A collection of items to initialize the list with.</param>
        public CustomList(IEnumerable<T> collection) : base(collection) { }

        /// <summary>
        /// Adds an item to the beginning of the list. Overrides the base class `Add` method.
        /// </summary>
        /// <param name="item">The item to be added to the list.</param>
        public new void Add(T item)
        {
            // Insert the new item at the beginning of the list
            Insert(0, item);
        }
    }
}
