using ServiceStack.DataAnnotations;

namespace ORMDemo.Models
{
    /// <summary>
    /// Represents a model entity for the 'per01' table.
    /// </summary>
    [Alias("per01")]
    public class per01
    {
        /// <summary>
        /// Gets or sets the value of the 'r01f02' column.
        /// </summary>
        public string r01f02 { get; set; }

        /// <summary>
        /// Gets or sets the primary key value of the 'per01' table.
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int r01f01 { get; set; }

        /// <summary>
        /// Gets or sets the value of the 'r01f03' column.
        /// </summary>
        public string r01f03 { get; set; }

        /// <summary>
        /// Gets or sets the value of the 'r01f04' column.
        /// </summary>
        public int r01f04 { get; set; }
    }
}
