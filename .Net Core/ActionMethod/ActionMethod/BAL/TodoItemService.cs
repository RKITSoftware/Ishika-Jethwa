using ActionMethod.MAL;

namespace ActionMethod.BAL
{
    /// <summary>
    /// Service class for managing TODO items.
    /// </summary>
    public class TodoItemService
    {
        private static List<TodoItem> _todoItems = new List<TodoItem>();
        private static int _idCounter = 1;

        /// <summary>
        /// Retrieves all TODO items.
        /// </summary>
        /// <returns>The list of TODO items.</returns>
        public IEnumerable<TodoItem> GetAllTodoItems()
        {
            return _todoItems;
        }

        /// <summary>
        /// Retrieves a specific TODO item by ID.
        /// </summary>
        /// <param name="id">The ID of the TODO item to retrieve.</param>
        /// <returns>The TODO item with the specified ID.</returns>
        public TodoItem GetTodoItemById(int id)
        {
            return _todoItems.FirstOrDefault(item => item.Id == id);
        }

        /// <summary>
        /// Adds a new TODO item.
        /// </summary>
        /// <param name="todoItem">The TODO item to add.</param>
        /// <returns>The added TODO item.</returns>
        public TodoItem AddTodoItem(TodoItem todoItem)
        {
            todoItem.Id = _idCounter++;
            todoItem.CreatedAt = DateTime.Now;
            _todoItems.Add(todoItem);
            return todoItem;
        }

        /// <summary>
        /// Updates an existing TODO item.
        /// </summary>
        /// <param name="id">The ID of the TODO item to update.</param>
        /// <param name="updatedTodoItem">The updated TODO item.</param>
        /// <returns>True if the TODO item was updated successfully, otherwise false.</returns>
        public bool UpdateTodoItem(int id, TodoItem updatedTodoItem)
        {
            var existingItemIndex = _todoItems.FindIndex(item => item.Id == id);
            if (existingItemIndex == -1)
                return false;

            _todoItems[existingItemIndex] = updatedTodoItem;
            return true;
        }

        /// <summary>
        /// Deletes a TODO item.
        /// </summary>
        /// <param name="id">The ID of the TODO item to delete.</param>
        /// <returns>True if the TODO item was deleted successfully, otherwise false.</returns>
        public bool DeleteTodoItem(int id)
        {
            var existingItem = _todoItems.Find(item => item.Id == id);
            if (existingItem == null)
                return false;

            _todoItems.Remove(existingItem);
            return true;
        }
    }
}
