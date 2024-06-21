using ServiceStack.DataAnnotations;

namespace ORMDemo.Models
{
    public class DtoPer01
    {
        /// <summary>
        /// Gets or sets the value of the 'r01f02' column.
        /// </summary>
        public string r01102 { get; set; }

        /// <summary>
        /// Gets or sets the primary key value of the 'per01' table.
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int r01101 { get; set; }

        /// <summary>
        /// Gets or sets the value of the 'r01f03' column.
        /// </summary>
        public string r01103 { get; set; }

        /// <summary>
        /// Gets or sets the value of the 'r01f04' column.
        /// </summary>
        public int r01104 { get; set; }
    }
}