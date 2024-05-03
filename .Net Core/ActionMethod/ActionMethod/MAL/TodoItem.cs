namespace ActionMethod.MAL
{
    /// <summary>
    /// Represents a TODO item.
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// The ID of the TODO item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the TODO item.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description of the TODO item.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Indicates whether the TODO item is completed.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// The date and time when the TODO item was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
